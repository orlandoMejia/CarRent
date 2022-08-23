using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Client.Command
{
    public record DeleteClientCommand(
        [Required] Guid Guid
    ) : IRequest;
}
