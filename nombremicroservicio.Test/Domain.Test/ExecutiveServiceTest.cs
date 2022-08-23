using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class ExecutiveServiceTest
    {


        IGenericRepository<Executive> _executiveRepository;
        ExecutiveService _executiveService;

        [TestInitialize]
        public void Init()
        {
            _executiveRepository = Substitute.For<IGenericRepository<Executive>>();
            _executiveService = new ExecutiveService(_executiveRepository);
        }

        [TestMethod, ExpectedException(typeof(ExecutiveException))]
        public async Task FailToRegisterExecutive()
        {
            Executive new_executive = null;

            await _executiveService.RegisterExecutiveAsync(new_executive);
        }
        

        [TestMethod]
        public async Task SuccessToRegisterExecutive()
        {
            Executive executive_exist = new()
            {
                Names = "Carlos",
                LastNames = "Madrid"
            };

            _executiveRepository.AddAsync(Arg.Any<Executive>()).Returns(Task.FromResult(
                new ExecutiveDataBuilder()
                .WithAddress(executive_exist.Address)
                .WithAge(executive_exist.Age)
                .Build()
            ));

            var result = await _executiveService.RegisterExecutiveAsync(executive_exist);

            Assert.IsTrue(result is Executive && result?.Id is not null);
        }
    }
}
