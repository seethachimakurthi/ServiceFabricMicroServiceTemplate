using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Renting.Master.Domain
{
    public class ConfigProvider : IConfigProvider
    {
        private IConfigurationRoot configuration;

        public ConfigProvider()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            configuration = builder.Build();
            
        }

        public string GetVal(string key)
        {
            return configuration.GetSection(key).Value;
        }
    }
}
