using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static nombremicroservicio.Entities.CreditRequest;

namespace nombremicroservicio.Repository.CreditRequest.Command
{
    public record UpdateCreditRequestCommand(
        [Required] Guid Guid,
        [MaxLength(255)] string Name,
        DateTime CreateDate,
        [MaxLength(255)] string Place,
        [MaxLength(255)] string Vehicle,
        [MaxLength(255)] string Months,
        [MaxLength(255)] string Quota,
        [MaxLength(255)] string Entry,
        CreditRequestType RequestType,
        [MaxLength(255)] Entities.Client Client,
        Entities.Executive Executive,
        Entities.Brand Brand,
        Entities.DriveWay DriveWay,
        [StringLength(255)] string Observation
    ) : IRequest;
}
