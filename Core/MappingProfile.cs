using AutoMapper;
using Renting.Master.Domain.Entities;

namespace Renting.Master.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VehicleBrand, Dtos.VehicleBrand>();
            CreateMap<Dtos.VehicleBrand, VehicleBrand>();
        }
    }
}
