using MediatR;
using nombremicroservicio.Infrastructure.Services;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.DriveWay.Command
{
    public class CreateDriveWayCommandHandler : IRequestHandler<CreateDriveWayCommand, GuidResultDto>
    {
        readonly DriveWayService _driveWayService;

        public CreateDriveWayCommandHandler(DriveWayService driveWayService)
        {
            _driveWayService = driveWayService;

        }


        async Task<GuidResultDto> IRequestHandler<CreateDriveWayCommand, GuidResultDto>.Handle(CreateDriveWayCommand request, CancellationToken cancellationToken)
        {
            var driveWaye = await _driveWayService.RegisterDriveWayAsync(new Entities.DriveWay
            {
                Name = request.Name,
                Address = request.Address,
                Number = request.Number,
                Phone = request.Phone,
            });
            return new GuidResultDto { id = driveWaye.Id };
        }

    }
}
