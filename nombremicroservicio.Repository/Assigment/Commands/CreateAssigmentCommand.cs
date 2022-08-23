using MediatR;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Assigment.Command 
{ 
    public record CreateAssigmentCommand(
        [Required]
        DateTime Date,
        [Required]
        Guid IdClient,
        [Required]
        Guid IdDriveWay

    ) : IRequest<GuidResultDto>;
}
