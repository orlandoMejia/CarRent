using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Executive.Command
{
    public record UpdateExecutiveCommand(
        [Required] 
        Guid Guid,
        [StringLength(255)]
        string IdentificationNumber,
        [StringLength(255)]
        string Names,
        [StringLength(255)]
        string LastNames,
        [StringLength(255)]
        string Address,
        [StringLength(255)]
        string Phone,
        [StringLength(255)]
        string Celphone,
        [StringLength(255)]
        Entities.DriveWay DriveWay) : IRequest;
}
