using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Linq;
using Renting.Master.Core.Interfaces;
using Renting.Master.Core.Services;
using Renting.Master.Domain.Entities;
using Renting.Master.Domain.IRepository;
using Renting.Master.Core;

namespace Renting.Master.Core.Test
{
    [TestClass]
    public class VehicleBrandServiceTest
    {

        private IVehicleBrandRepository brandRepository;
        private IVehicleBrandService brandService;
        private VehicleBrand brandEntity;
        private Renting.Master.Core.Dtos.VehicleBrand brandDto;
        private List<VehicleBrand> brandList;
        private List<Renting.Master.Core.Dtos.VehicleBrand> brandDtoList;

        [TestInitialize]
        public void Initialize()
        {
            Mapper.Reset();
            MappingConfig.Initialize();
            brandRepository = Substitute.For<IVehicleBrandRepository>();
            brandService = new VehicleBrandService(brandRepository);
            brandEntity = new VehicleBrand { Name = "Renault", Id = 1 };
            //brandDto = Mapper.Map<Renting.Master.Core.Dtos.VehicleBrand>(brandEntity);
            brandList = new List<VehicleBrand>
            {
                brandEntity
            };
        }

        [TestMethod]
        public void GetAllBrandsByRepositoryTest()
        {           
            brandRepository.GetAll().Returns(brandList);
            var result = brandRepository.GetAll().ToList();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void GetAllBrandsByServiceTest()
        {            
            brandRepository.GetAll().Returns(brandList);
            var result = brandService.GetAll();
            Assert.IsTrue(result.Any());
        }
    }
}
