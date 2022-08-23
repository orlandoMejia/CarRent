using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Assigment.Queries
{
    public record AssigmentQuery([Required] Guid Id) : IRequest<AssigmentDto>;
}
