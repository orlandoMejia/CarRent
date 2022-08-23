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
    public class CreditRequestService : IDisposable
    {
        readonly IGenericRepository<CreditRequest> _creditRepository;
        readonly IGenericRepository<Client> _clientRepository;

        public CreditRequestService(IGenericRepository<CreditRequest> creditRepository, IGenericRepository<Client> clientRepository)
        {
            _creditRepository = creditRepository;
            _clientRepository = clientRepository;
        }

        public async Task<CreditRequest> RegisterCreditRequestAsync(CreditRequest creditRequest)
        {
            if (creditRequest != null)
            {
                var validateCreditRequest = await _creditRepository.GetAsync(
                    credit => credit.CreateDate > DateTime.Now.Date &&
                    credit.Id == creditRequest.IdClient 

                );
                if (validateCreditRequest.Count() > 0)
                    throw new CreditRequestException();
                return await _creditRepository.AddAsync(creditRequest);

            }
            throw new CreditRequestException();
        }

        public async Task<CreditRequest> UpdateCreditRequestAsync(CreditRequest creditRequest)
        {
            var oldCreditRequest = await _creditRepository.GetByIdAsync(creditRequest.Id);

            if (oldCreditRequest == null)
                throw new CreditRequestException("No se ha encontrado la solicitud de credito");

            oldCreditRequest.CreateDate = creditRequest.CreateDate;
            oldCreditRequest.Place = creditRequest.Place;
            oldCreditRequest.Vehicle = creditRequest.Vehicle;
            oldCreditRequest.Months = creditRequest.Months;
            oldCreditRequest.Quota = creditRequest.Quota;
            oldCreditRequest.Entry = creditRequest.Entry;
            oldCreditRequest.Observation = creditRequest.Observation;

            await _creditRepository.UpdateAsync(oldCreditRequest);
            return oldCreditRequest;
        }

        public async Task DeleteCreditRequestAsync(Guid creditRequestId)
        {
            var creditRequestDelete = await _creditRepository.GetByIdAsync(creditRequestId);
            if (creditRequestDelete == null)
                throw new CreditRequestException("No se ha encontrado el creditRequeste");

            await _creditRepository.DeleteAsync(creditRequestDelete);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            this._creditRepository.Dispose();
        }
    }
}
