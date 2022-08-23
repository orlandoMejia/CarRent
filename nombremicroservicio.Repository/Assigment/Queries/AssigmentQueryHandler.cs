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

namespace nombremicroservicio.Repository.Assigment.Queries
{
    public class AssigmentQueryHandler : IRequestHandler<AssigmentQuery, AssigmentDto>, IDisposable
    {

        private readonly IGenericRepository<Entities.Assigment> _AssigmentRepository;
        private readonly IMapper _mapper;

        public AssigmentQueryHandler(IGenericRepository<Entities.Assigment> clientRepository, IMapper mapper)
        {
            _AssigmentRepository = clientRepository;
        }

        public async Task<AssigmentDto> Handle(AssigmentQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request object needed to handle this task");
            try
            {
                var assigment = await _AssigmentRepository.GetByIdAsync(request.Id);
                if (assigment == null)
                    throw new AssigmentException();
                return new AssigmentDto { Date = assigment.Date };
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
            this._AssigmentRepository.Dispose();
        }

    }
}
