using MediatR;
using Microsoft.AspNetCore.Mvc;
using nombremicroservicio.Entities;
using nombremicroservicio.Infrastructure.Services;
using nombremicroservicio.Repository.DriveWay.Command;
using nombremicroservicio.Repository.DriveWay.Queries;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Threading.Tasks;

namespace nombremicroservicio.API.Controllers
{
    [ApiController]
    [Route("patio")]
    public class DriveWayController
    {
        readonly IMediator _mediator = default!;

        public DriveWayController(IMediator mediator)
            => _mediator = mediator
            ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{id}")]
        public async Task<DriveWayDto> Get(Guid id) => await _mediator.Send(new DriveWayQuery(id));

        [HttpPost]
        public async Task<GuidResultDto> Post(CreateDriveWayCommand driveWay) => await _mediator.Send(driveWay);

        [HttpPut]
        public async Task<GuidResultDto> Put(UpdateDriveWayCommand driveWay)
        {

            var driveWayUpdateRequest = new UpdateDriveWayCommand(
                driveWay.Guid, driveWay.Name, driveWay.Address, driveWay.Phone, driveWay.Number
            );

            await _mediator.Send(driveWayUpdateRequest);

            return new GuidResultDto { id = driveWay.Guid };
        }
        [HttpDelete("{id}")]
        public async Task Delete(Guid id) => await _mediator.Send(new DeleteDriveWayCommand(id));
    }
}
