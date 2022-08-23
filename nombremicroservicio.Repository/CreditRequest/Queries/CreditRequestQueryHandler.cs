using AutoMapper;
using MediatR;
using nombremicroservicio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.CreditRequest.Queries
{
    public class CreditRequestQueryHandler : IRequestHandler<CreditRequestQuery, CreditRequestDto>, IDisposable
    {

        private readonly IGenericRepository<Entities.CreditRequest> _CreditRequestRepository;
        private readonly IMapper _mapper;

        public CreditRequestQueryHandler(IGenericRepository<Entities.CreditRequest> creditRequestRepository, IMapper mapper)
        {
            _CreditRequestRepository = creditRequestRepository;
        }

        public async Task<CreditRequestDto> Handle(CreditRequestQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request object needed to handle this task");
            try
            {
                return _mapper.Map<CreditRequestDto>(await _CreditRequestRepository.GetByIdAsync(request.Id));

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
            this._CreditRequestRepository.Dispose();
        }

    }
}
