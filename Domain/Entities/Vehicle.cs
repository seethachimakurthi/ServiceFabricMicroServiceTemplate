namespace Renting.Master.Domain.Entities
{
    public class Vehicle : EntityBase
    {
        public string Description {get; set; }
        public VehicleBrand BrandId { get; set; }
        public VehicleType TypeId { get; set; }
    }
}
