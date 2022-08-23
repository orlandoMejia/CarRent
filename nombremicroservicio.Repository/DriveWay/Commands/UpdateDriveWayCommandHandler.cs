using MediatR;
using nombremicroservicio.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.DriveWay.Command
{
    public class UpdateDriveWayCommandHandler : AsyncRequestHandler<UpdateDriveWayCommand>
    {
        readonly DriveWayService _driveWayService;

        public UpdateDriveWayCommandHandler(DriveWayService driveWayService)
        {
            _driveWayService = driveWayService;

        }

        protected override async Task Handle(UpdateDriveWayCommand request, CancellationToken cancellationToken)
        {
            await _driveWayService.UpdateDriveWayAsync(new Entities.DriveWay
            {
                Id = request.Guid,
                Name = request.Name,
            });
        }
    }
}
