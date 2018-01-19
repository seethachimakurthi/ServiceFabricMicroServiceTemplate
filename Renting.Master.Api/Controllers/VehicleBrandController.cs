using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Renting.Master.Core.Interfaces;
using Renting.Master.Core.Dtos;
using Renting.Master.Domain.IRepository;
using System;
using System.Text;
using System.Threading.Tasks;
using Renting.Master.Core.Messages;

namespace Renting.Master.Api.Controllers
{
    [Route("api/vehicle/brands")]
    public class VehicleBrandController : Controller
    {
        private readonly IVehicleBrandService vehicleBrandService;
        private readonly IBusQueueClientService sbClient;

        public VehicleBrandController(IVehicleBrandService vehicleBrandService, IBusQueueClientService sbClient)
        {
            this.vehicleBrandService = vehicleBrandService;
            this.sbClient = sbClient;
        }

        [HttpGet]
        public IEnumerable<VehicleBrand> GetAll()
        {            
            return vehicleBrandService.GetAll();
        }

        [HttpPost]
        public async Task CreateAsync([FromBody]VehicleBrand brand)
        {
            await sbClient.SendObject("q1", new GenericMessage<VehicleBrand> { MessageBody = brand, MessageType = 1 });
        }        

        [HttpGet, Route("/Error")]
        public ContentResult Error()
        {
            return Content("La petición no ha sido procesada.");
        }
    }
}
