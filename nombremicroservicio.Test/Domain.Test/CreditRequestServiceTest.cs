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
    public class CreditRequestServiceTest
    {


        IGenericRepository<CreditRequest> _creditRequestRepository;
        IGenericRepository<Client> _clientRequestRepository;

        CreditRequestService _creditRequestService;

        [TestInitialize]
        public void Init()
        {
            _creditRequestRepository = Substitute.For<IGenericRepository<CreditRequest>>();
            _creditRequestService = new CreditRequestService(_creditRequestRepository, _clientRequestRepository);
        }

        [TestMethod, ExpectedException(typeof(CreditRequestException))]
        public async Task FailToRegisterCreditRequest()
        {
            CreditRequest new_creditRequest = null;

            await _creditRequestService.RegisterCreditRequestAsync(new_creditRequest);
        }

        [TestMethod, ExpectedException(typeof(CreditRequestException))]
        public async Task FailToRegisterCreditDateRequest()
        {
            Client new_client = new()
            {
                Id = Guid.NewGuid(),
                Names = "Carlos",
                LastNames = "Maya",
                Address = "Cra 23 # 1-22",
                Age = "22"

            };

            CreditRequest new_creditRequest = null;

            await _creditRequestService.RegisterCreditRequestAsync(new_creditRequest);

        }


        [TestMethod]
        public async Task SuccessToRegisterCreditRequest()
        {
            CreditRequest creditRequest_exist = new()
            {
                Id = Guid.NewGuid(),
                CreateDate = DateTime.Now,
                Quota = "",
                Entry = "",
                Months = "48",
                Observation = "No",
                Place = "Medellin",
                Vehicle = "Rh12"

            };

            _creditRequestRepository.AddAsync(Arg.Any<CreditRequest>()).Returns(Task.FromResult(
                new CreditRequestDataBuilder()
                .WithCreateDate(creditRequest_exist.CreateDate)
                .WithPlace(creditRequest_exist.Place)
                .WithVehicle(creditRequest_exist.Vehicle)
                .WithMonths(creditRequest_exist.Months)
                .WithQuota(creditRequest_exist.Quota)
                .WithEntry(creditRequest_exist.Entry)
                .WithRequestType(creditRequest_exist.RequestType)
                .WithClient(creditRequest_exist.IdClient)
                .WithExecutive(creditRequest_exist.IdExecutive)
                .WithBrand(creditRequest_exist.IdBrand)
                .WithDriveWay(creditRequest_exist.IdDriveWay)
                .Build()
            ));

            var result = await _creditRequestService.RegisterCreditRequestAsync(creditRequest_exist);

            Assert.IsTrue(result is CreditRequest && result?.Id is not null);
        }
    }
}
