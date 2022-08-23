using MediatR;
using nombremicroservicio.Domain.Exceptions;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Infrastructure.Services;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Executive.Command
{
    public class CreateExecutiveCommandHandler : IRequestHandler<CreateExecutiveCommand, GuidResultDto>
    {
        readonly ExecutiveService _executiveService;
        readonly IGenericRepository<Entities.DriveWay> _driveWayRepository;

        public CreateExecutiveCommandHandler(ExecutiveService executiveService, IGenericRepository<Entities.DriveWay> driveWayRepository)
        {
            _executiveService = executiveService;
            _driveWayRepository = driveWayRepository;
        }

        async Task<GuidResultDto> IRequestHandler<CreateExecutiveCommand, GuidResultDto>.Handle(CreateExecutiveCommand request, CancellationToken cancellationToken)
        {
            var driveWay = await _driveWayRepository.GetByIdAsync(Guid.Parse( request.IdDriveWay));

            if (driveWay == null)
                throw new DriveWayException("No existe el patio");

            var executive = await _executiveService.RegisterExecutiveAsync(new Entities.Executive
            {
                Names = request.Names,
                DriveWay = driveWay,
                Address = request.Address,
                Age = request.Age,
                Phone = request.Phone,
                Celphone = request.Celphone,
                IdentificationNumber = request.IdentificationNumber,
                LastNames = request.LastNames,
                
            });

            return new GuidResultDto { id = executive.Id };
        }
    }
}
