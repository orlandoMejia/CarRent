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
    public class ClientServiceTest
    {


        IGenericRepository<Client> _clientRepository;
        ClientService _clientService;
        Mock<IGenericRepository<Client>> _brandRepoMoq = default!;


        [TestInitialize]
        public void Init()
        {
            _brandRepoMoq = new Mock<IGenericRepository<Client>>();

            _clientRepository = Substitute.For<IGenericRepository<Client>>();
            _clientService = new ClientService(_clientRepository);
        }

        [TestMethod, ExpectedException(typeof(ClientException))]
        public async Task FailToRegisterClient()
        {
            Client new_client = null;

            await _clientService.RegisterClientAsync(new_client);
        }


        

        [TestMethod]
        public async Task SuccessToRegisterClientAsync()
        {
            Client client_exist = new()
            {
                Names = "Carlos",
                LastNames = "Madrid"
            };

            _clientRepository.AddAsync(Arg.Any<Client>()).Returns(Task.FromResult(
                new ClientDataBuilder()
                .WithIdentificationNumber(client_exist.IdentificationNumber)
                .Build()
            ));

            var result = await _clientService.RegisterClientAsync(client_exist);

            Assert.IsTrue(result is Client && result?.Id is not null);
        }


        [TestMethod, ExpectedException(typeof(ClientException))]
        public async Task NotFoundToUpdateClient()
        {
            ClientService service = new ClientService(_brandRepoMoq.Object);

            Client brand_not_exist = new()
            {
                Names = "Nombre Cliente",
            };
            var result = await service.UpdateClientAsync(brand_not_exist);
        }

        [TestMethod, ExpectedException(typeof(ClientException))]
        public async Task NotFoundToDeleteClient()
        {
            ClientService service = new ClientService(_brandRepoMoq.Object);

            Client brand_not_exist = new()
            {
                Names = "Nombre Cliente",
            };
            await service.DeleteClientAsync(brand_not_exist.Id);
        }
    }
}
