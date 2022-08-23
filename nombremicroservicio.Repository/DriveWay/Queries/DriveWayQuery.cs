using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.DriveWay.Queries
{
    public record DriveWayQuery([Required] Guid Id) : IRequest<DriveWayDto>;
}
