using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.DriveWay.Command
{
    public record DeleteDriveWayCommand(
        [Required] Guid Guid
    ) : IRequest;
}
