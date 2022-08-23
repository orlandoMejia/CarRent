using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Brand.Queries
{
    public record BrandQuery([Required] Guid Id) : IRequest<BrandDto>;
}
