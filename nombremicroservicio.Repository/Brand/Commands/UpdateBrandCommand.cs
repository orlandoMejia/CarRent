using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Brand.Command
{
    public record UpdateBrandCommand(
        [Required] Guid Guid,
        [Required, MaxLength(255)] string Name
    ) : IRequest;
}
