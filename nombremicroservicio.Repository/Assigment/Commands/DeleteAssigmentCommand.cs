using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Assigment.Command
{
    public record DeleteAssigmentCommand(
        [Required] Guid Guid
    ) : IRequest;
}
