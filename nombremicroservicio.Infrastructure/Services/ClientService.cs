using nombremicroservicio.Domain.Exceptions;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace nombremicroservicio.Infrastructure.Services
{
    public class ClientService : IDisposable
    {
        readonly IGenericRepository<Client> _repository;

        public ClientService(IGenericRepository<Client> repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository),
                "El repositorio de Clientes no esta disponible");
        }

        public async Task<Client> RegisterClientAsync(Client client)
        {
            if (client != null)
            {
                var clientsNumber = await _repository.GetByIdAsync(client.Id);
                if(clientsNumber == null)
                    return await _repository.AddAsync(client);
                throw new ClientDuplicateExceptions();
            }
            throw new ClientException();
        }

        public async Task<Client> UpdateClientAsync(Client client)
        {
            var oldClient = await _repository.GetByIdAsync(client.Id);

            if (oldClient == null)
                throw new ClientException("No se ha encontrado el cliente");

            oldClient.IdentificationNumber = client.IdentificationNumber;
            oldClient.Names = client.Names;
            oldClient.Age = client.Age;
            oldClient.BirthDate = client.BirthDate;
            oldClient.LastNames = client.LastNames;
            oldClient.Address = client.Address;
            oldClient.Phone = client.Phone;
            oldClient.MaterialStatus = client.MaterialStatus;
            oldClient.SpoceIdentification = client.SpoceIdentification;
            oldClient.SpoceName = client.SpoceName;
            oldClient.CreditSubject = client.CreditSubject;

           

            await _repository.UpdateAsync(oldClient);
            return oldClient;
        }

        public async Task DeleteClientAsync(Guid clientId)
        {
            var clientDelete = await _repository.GetByIdAsync(clientId);
            if (clientDelete == null)
                throw new ClientException("No se ha encontrado el cliente");

            await _repository.DeleteAsync(clientDelete);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            this._repository.Dispose();
        }
    }
}
