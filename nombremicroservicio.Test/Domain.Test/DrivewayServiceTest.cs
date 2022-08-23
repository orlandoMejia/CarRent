using Microsoft.VisualStudio.TestTools.UnitTesting;
using nombremicroservicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nombremicroservicio.Entities;
using nombremicroservicio.Domain.Interfaces;
using NSubstitute;
using nombremicroservicio.Infrastructure.Services;
using nombremicroservicio.Domain.Exceptions;

namespace nombremicroservicio.Test
{
    [TestClass]
    public class DrivewayServiceTest
    {


        IGenericRepository<Entities.DriveWay> _driveWayRepository;
        DriveWayService _driveWayService;

        [TestInitialize]
        public void Init()
        {
            _driveWayRepository = Substitute.For<IGenericRepository<DriveWay>>();
            _driveWayService = new DriveWayService(_driveWayRepository);
        }

        [TestMethod, ExpectedException(typeof(DriveWayException))]
        public async Task FailToRegisterDriveway()
        {
            DriveWay new_driveWay = null;

            await _driveWayService.RegisterDriveWayAsync(new_driveWay);
        }

        

        [TestMethod]
        public async Task SuccessToRegisterDriveway()
        {
            DriveWay driveWay_exist = new()
            {
                Id = Guid.NewGuid(),
                Address = "Cra 1 #",
            };

            _driveWayRepository.AddAsync(Arg.Any<Entities.DriveWay>()).Returns(Task.FromResult(
                new DrivewayDataBuilder()
                .WithAddress(driveWay_exist.Address)
                .Build()
            ));

            var result = await _driveWayService.RegisterDriveWayAsync(driveWay_exist);

            Assert.IsTrue(result is DriveWay && result?.Id is not null);
        }
    }
}
