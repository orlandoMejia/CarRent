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

    public class DeleteDriveWayCommandHandler : AsyncRequestHandler<DeleteDriveWayCommand>
    {
        readonly DriveWayService _driveWayService;

        public DeleteDriveWayCommandHandler(DriveWayService driveWayService)
        {
            _driveWayService = driveWayService;

        }

        protected override async Task Handle(DeleteDriveWayCommand request, CancellationToken cancellationToken)
        {
            await _driveWayService.DeleteDriveWayAsync(request.Guid);
        }
    }
}
