﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Renting.Master.Core.Interfaces;
using Renting.Master.Core.Dtos;
using Renting.Master.Domain.IRepository;

namespace Renting.Master.Api.Controllers
{
    [Route("api/vehicle")]
    public class VehicleBrandController : Controller
    {
        private readonly IVehicleBrandService vehicleBrandService;
        private readonly IVehicleBrandRepository repo;

        public VehicleBrandController(IVehicleBrandService vehicleBrandService, IVehicleBrandRepository repo)
        {
            this.vehicleBrandService = vehicleBrandService;
            this.repo = repo;
        }

        // GET api/values
        [HttpGet, Route("brands")]
        public IEnumerable<VehicleBrand> GetAll()
        {
            return vehicleBrandService.GetAll();
        }

        [HttpGet, Route("foo")]
        public IEnumerable<Domain.Entities.VehicleBrand> ReturnString()
        {
            return repo.GetAll();
        }

        /*
        // GET api/books/5
        [HttpGet("{id}")]
        public Book FindById(long id)
        {
            return bookServices.FindById(id);
        }

        // POST api/values
        [HttpPost]
        public async Task CreateAsync([FromBody]Book book)
        {
            await bookServices.AddAsync(book);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task UpdateAsync(long id, [FromBody]Book book)
        {
            book.Id = id;
            await bookServices.UpdateAsync(book);
        }

        // DELETE api/values/5
        /* [HttpDelete("{id}")]
         public async Task DeleteAsync(long id)
         {
             await bookServices.DeleteAsync(id);
         }*/

        [HttpGet, Route("/Error")]
        public ContentResult Error()
        {
            return Content("La petición no ha sido procesada.");
        }
    }
}
