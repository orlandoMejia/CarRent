using MediatR;
using Microsoft.AspNetCore.Mvc;
using nombremicroservicio.Entities;
using nombremicroservicio.Infrastructure.Services;
using nombremicroservicio.Repository.CreditRequest.Command;
using nombremicroservicio.Repository.CreditRequest.Queries;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Threading.Tasks;

namespace nombremicroservicio.API.Controllers
{
    [ApiController]
    [Route("credito")]
    public class CreditRequestController
    {
        readonly IMediator _mediator = default!;

        public CreditRequestController(IMediator mediator)
            => _mediator = mediator
            ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{id}")]
        public async Task<CreditRequestDto> Get(Guid id) => await _mediator.Send(new CreditRequestQuery(id));
            
        [HttpPost]
        public async Task<GuidResultDto> Post(CreateCreditRequestCommand creditReq) => await _mediator.Send(creditReq);

        [HttpPut]
        public async Task<GuidResultDto> Put(UpdateCreditRequestCommand creditReq)
        {

            var creditReqUpdateRequest = new UpdateCreditRequestCommand(
                creditReq.Guid, creditReq.Name, creditReq.CreateDate, creditReq.Place, creditReq.Vehicle, creditReq.Months,
                creditReq.Quota, creditReq.Entry, creditReq.RequestType, creditReq.Client, creditReq.Executive, creditReq.Brand,
                creditReq.DriveWay, creditReq.Observation                
            );

            await _mediator.Send(creditReqUpdateRequest);

            return new GuidResultDto { id = creditReq.Guid };
        }
        [HttpDelete("{id}")]
        public async Task Delete(Guid id) => await _mediator.Send(new DeleteCreditRequestCommand(id));
    }
}
