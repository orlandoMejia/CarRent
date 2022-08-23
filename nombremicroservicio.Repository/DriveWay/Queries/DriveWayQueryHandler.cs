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

namespace nombremicroservicio.Repository.DriveWay.Queries
{
    public class DriveWayQueryHandler : IRequestHandler<DriveWayQuery, DriveWayDto>, IDisposable
    {

        private readonly IGenericRepository<Entities.DriveWay> _DriveWayRepository;
        private readonly IMapper _mapper;

        public DriveWayQueryHandler(IGenericRepository<Entities.DriveWay> clientRepository, IMapper mapper)
        {
            _DriveWayRepository = clientRepository;
        }

        public async Task<DriveWayDto> Handle(DriveWayQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request object needed to handle this task");
            try
            {
                var driveWay = await _DriveWayRepository.GetByIdAsync(request.Id);
                if (driveWay == null)
                    throw new ArgumentNullException("El patio no existe");
                return new DriveWayDto { Name = driveWay.Name, Address = driveWay.Address,
                    Number = driveWay.Number, Phone = driveWay.Phone};

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
            this._DriveWayRepository.Dispose();
        }

    }
}
