using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Assigment.Command
{
    public record UpdateAssigmentCommand(
        [Required] Guid Guid,
        DateTime Date,
        Guid IdClient,
        Guid IdDriveWay
    ) : IRequest;
}
