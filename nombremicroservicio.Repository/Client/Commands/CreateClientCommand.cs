using MediatR;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Client.Command 
{ 
    public record CreateClientCommand(
        string IdentificationNumber,
        [Required]
        [StringLength(255)]
        string Names,
        [Required]
        [StringLength(255)]
        string Age,
        DateTime BirthDate,
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
        string MaterialStatus,
        [Required]
        [StringLength(255)]
        string SpoceIdentification,
        [Required]
        [StringLength(255)]
        string SpoceName,
        [Required]
        [StringLength(255)]
        string CreditSubject
    ) : IRequest<GuidResultDto>;
}
