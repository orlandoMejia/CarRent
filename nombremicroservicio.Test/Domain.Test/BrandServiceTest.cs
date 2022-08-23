using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using nombremicroservicio.Domain.Exceptions;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using nombremicroservicio.Infrastructure.Services;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Test
{
    [TestClass]
    public class BrandServiceTest
    {


        IGenericRepository<Brand> _brandRepository = default!;
        BrandService _brandService = default!;
        Mock<IGenericRepository<Brand>> _brandRepoMoq = default!;

        [TestInitialize]
        public void Init()
        {
            _brandRepoMoq = new Mock<IGenericRepository<Brand>>();
            _brandRepository = Substitute.For<IGenericRepository<Brand>>();
            _brandService = new BrandService(_brandRepository);
        }

        [TestMethod, ExpectedException(typeof(BrandException))]
        public async Task FailToRegisterBrand()
        {
            Brand new_brand = null;

            await _brandService.RegisterBrandAsync(new_brand);
        }

        

        [TestMethod]
        public async Task SuccessToRegisterBrand()
        {
            Brand brand_exist = new()
            {
                Name = "Mazda",

            };

            _brandRepository.AddAsync(Arg.Any<Brand>()).Returns(Task.FromResult(
                new BrandDataBuilder()
                .WithNames(brand_exist.Name)
                .Build()
            ));

            var result = await _brandService.RegisterBrandAsync(brand_exist);

            Assert.IsTrue(result is Brand && result?.Id is not null);
        }

        [TestMethod, ExpectedException(typeof(BrandException))]
        public async Task NotFoundToUpdateBrand()
        {
            BrandService service = new BrandService(_brandRepoMoq.Object);

            Brand brand_not_exist = new()
            {
                Name = "Nombre Marca",
            };
            var result = await service.UpdateBrandAsync(brand_not_exist);
        }

        [TestMethod, ExpectedException(typeof(BrandException))]
        public async Task NotFoundToDeleteBrand()
        {
            BrandService service = new BrandService(_brandRepoMoq.Object);

            Brand brand_not_exist = new()
            {
                Name = "Nombre Marca",
            };
            await service.DeleteBrandAsync(brand_not_exist.Id);
        }
    }
}
