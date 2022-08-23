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
    public class AssigmentServiceTest
    {


        IGenericRepository<Entities.Assigment> _assigmentRepository;
        AssigmentService _assigmentService;

        [TestInitialize]
        public void Init()
        {
            _assigmentRepository = Substitute.For<IGenericRepository<Assigment>>();
            _assigmentService = new AssigmentService(_assigmentRepository);
        }

        [TestMethod, ExpectedException(typeof(AssigmentException))]
        public async Task FailToRegisterAssigment()
        {
            Assigment new_assigment = null;

            await _assigmentService.RegisterAssigmentAsync(new_assigment);
        }

        

        [TestMethod]
        public async Task SuccessToRegisterAssigment()
        {
            Assigment assigment_exist = new()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
            };

            _assigmentRepository.AddAsync(Arg.Any<Entities.Assigment>()).Returns(Task.FromResult(
                new AssigmentDataBuilder()
                .WithDate(assigment_exist.Date)
                .Build()
            ));

            var result = await _assigmentService.RegisterAssigmentAsync(assigment_exist);

            Assert.IsTrue(result is Assigment && result?.Id is not null);
        }
    }
}
