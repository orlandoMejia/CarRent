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

namespace nombremicroservicio.Repository.Executive.Queries
{
    public class ExecutiveQueryHandler : IRequestHandler<ExecutiveQuery, ExecutiveDto>, IDisposable
    {

        private readonly IGenericRepository<Entities.Executive> _ExecutiveRepository;
        private readonly IMapper _mapper;

        public ExecutiveQueryHandler(IGenericRepository<Entities.Executive> executiveRepository, IMapper mapper)
        {
            _ExecutiveRepository = executiveRepository;
        }

        public async Task<ExecutiveDto> Handle(ExecutiveQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request object needed to handle this task");
            var executive = await _ExecutiveRepository.GetByIdAsync(request.Id);
            if (executive == null) 
                throw new ArgumentNullException(nameof(executive));
            try
            {
                return new ExecutiveDto { 
                    Address = executive.Address,
                    Phone = executive.Phone,
                    Celphone = executive.Celphone,
                    IdentificationNumber = executive.IdentificationNumber,
                    LastNames = executive.LastNames,
                    Names = executive.Names,
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
            this._ExecutiveRepository.Dispose();
        }

    }
}
