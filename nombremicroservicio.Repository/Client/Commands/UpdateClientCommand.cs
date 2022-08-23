using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Client.Command
{
    public record UpdateClientCommand(
        [Required] Guid Guid,
        string IdentificationNumber,
        [StringLength(255)]
        string Names,
        [StringLength(255)]
        string Age,
        DateTime BirthDate,
        [StringLength(255)]
        string LastNames,
        [StringLength(255)]
        string Address,
        [StringLength(255)]
        string Phone,
        [StringLength(255)]
        string MaterialStatus,
        [StringLength(255)]
        string SpoceIdentification,
        [StringLength(255)]
        string SpoceName,
        [StringLength(255)]
        string CreditSubject
    ) : IRequest;
}
