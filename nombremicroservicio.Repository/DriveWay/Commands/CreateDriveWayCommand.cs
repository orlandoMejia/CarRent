using MediatR;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.DriveWay.Command 
{ 
    public record CreateDriveWayCommand(
        [Required]
        [StringLength(255)]
        string Name,
        [Required]
        [StringLength(255)]
        string Address,
        [Required]
        [StringLength(255)]
        string Phone,
        [Required]
        [StringLength(255)]
        string Number
    ) : IRequest<GuidResultDto>;
}
