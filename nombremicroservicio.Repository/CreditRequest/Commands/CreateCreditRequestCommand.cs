using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static nombremicroservicio.Entities.CreditRequest;
using nombremicroservicio.Entities;
using nombremicroservicio.Repository.Dtos;

namespace nombremicroservicio.Repository.CreditRequest.Command
{
    public record CreateCreditRequestCommand(
        [Required, MaxLength(255)] string Name,
        [Required]  DateTime CreateDate,
        [Required, MaxLength(255)] string Place,
        [Required, MaxLength(255)] string Vehicle,
        [Required, MaxLength(255)] string Months,
        [Required, MaxLength(255)] string Quota,
        [Required, MaxLength(255)] string Entry,
        [Required] CreditRequestType RequestType,
        [Required] Guid IdClient,
        [Required] Guid IdExecutive,
        [Required] Guid IdBrand,
        [Required] Guid IdDriveWay,
        [StringLength(255)] string Observation 
    ) : IRequest<GuidResultDto>;
}
