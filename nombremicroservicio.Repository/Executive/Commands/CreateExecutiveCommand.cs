using MediatR;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Executive.Command
{
    public record CreateExecutiveCommand(        
        [Required]
        [StringLength(255)]
        string IdentificationNumber,
        [Required]
        [StringLength(255)]
        string Names,
        [Required]
        [StringLength(255)]
        string LastNames,
        [Required]
        [StringLength(255)]
        string Address,
        [Required]
        [StringLength(255)]
        string Phone,
        [Required]
        [StringLength(255)]
        string Celphone,
        [Required]
        [StringLength(255)]
        string IdDriveWay,
        [Required]
        [StringLength(255)]
        string Age
    ) : IRequest<GuidResultDto>;
}
