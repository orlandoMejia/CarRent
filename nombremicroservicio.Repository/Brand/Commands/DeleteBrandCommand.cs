using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Brand.Command
{
    public record DeleteBrandCommand(
        [Required] Guid Guid
    ) : IRequest;
}
