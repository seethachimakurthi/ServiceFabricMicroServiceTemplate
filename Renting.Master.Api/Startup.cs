using System;
using System.IO;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Renting.Master.Core;
using Renting.Master.Core.Interfaces;
using Renting.Master.Core.Services;
using Renting.Master.Domain;
using Renting.Master.Domain.IRepository;
using Renting.Master.Domain.Repository;
using Swashbuckle.AspNetCore.Swagger;
using Renting.Master.Domain.Helpers;

namespace Renting.Master.Api
{
    public class Startup
    {

        private static IContainer ApplicationContainer { get; set; }
        public IConfiguration Configuration { get; }
        public IConfiguration jsonConfig { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            jsonConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }       

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {            
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Version = "v1", Title = "My API", });                
            });
            services.AddDbContext<LibraryContext>(options =>
               options.UseSqlServer(jsonConfig.GetConnectionString("LibraryConnection")));

            services.AddApplicationInsightsTelemetry(jsonConfig);
            //IoC
            CreateDependencyInjection(services);
            //Initialize Mapping            
            MappingConfig.Initialize();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        public void CreateDependencyInjection(IServiceCollection services)
        {
            // create a Autofac container builder
            ContainerBuilder builder = new ContainerBuilder();
            // read service collection to Autofac
            builder.Populate(services);
            // use and configure Autofac       +    
            builder.RegisterType<LibraryContext>().As<IQueryableUnitOfWork>().WithParameter("schema", jsonConfig.GetConnectionString("SchemaName"));
            builder.RegisterType<LoggerHelper>().As<ILoggerHelper>();
            builder.RegisterType<VehicleBrandService>().As<IVehicleBrandService>();
            builder.RegisterType<VehicleBrandRepository>().As<IVehicleBrandRepository>();
            // build the Autofac container
            ApplicationContainer = builder.Build();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
