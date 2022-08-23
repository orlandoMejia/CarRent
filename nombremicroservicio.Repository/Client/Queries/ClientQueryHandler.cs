using AutoMapper;
using MediatR;
using nombremicroservicio.Domain.Exceptions;
using nombremicroservicio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Client.Queries
{
    public class ClientQueryHandler : IRequestHandler<ClientQuery, ClientDto>, IDisposable
    {

        private readonly IGenericRepository<Entities.Client> _ClientRepository;
        private readonly IMapper _mapper;

        public ClientQueryHandler(IGenericRepository<Entities.Client> clientRepository, IMapper mapper)
        {
            _ClientRepository = clientRepository;
        }

        public async Task<ClientDto> Handle(ClientQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request object needed to handle this task");
            try
            {
                var client = await _ClientRepository.GetByIdAsync(request.Id);
                if (client == null)
                    throw new ClientException();
                return new ClientDto { 
                    Address = client.Address,
                    Age = client.Age,
                    BirthDate = client.BirthDate,
                    CreditSubject = client.CreditSubject,
                    IdentificationNumber = client.IdentificationNumber,
                    LastNames = client.LastNames,
                    MaterialStatus = client.MaterialStatus,
                    Names = client.Names,
                    Phone = client.Phone,
                    SpoceIdentification = client.SpoceIdentification,
                    SpoceName = client.SpoceName,
                };

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            this._ClientRepository.Dispose();
        }

    }
}
