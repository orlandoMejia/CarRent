using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.DriveWay.Command
{
    public record UpdateDriveWayCommand(
        [Required] Guid Guid,
        [StringLength(255)]
        string Name,
        [StringLength(255)]
        string Address,
        [StringLength(255)]
        string Phone,
        [StringLength(255)]
        string Number
    ) : IRequest;
}
