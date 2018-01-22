﻿namespace Renting.Master.Domain.Entities
{
    public class EntityBase<TId> where TId : struct
    {
        public TId Id { get; set; }
    }
}