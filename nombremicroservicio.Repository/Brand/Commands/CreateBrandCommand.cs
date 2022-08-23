using MediatR;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Brand.Command
{
    public record CreateBrandCommand(
        [Required, MaxLength(255)] string Name
    ) : IRequest<GuidResultDto>;
}
