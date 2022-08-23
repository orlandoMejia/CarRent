using MediatR;
using Microsoft.AspNetCore.Mvc;
using nombremicroservicio.Entities;
using nombremicroservicio.Infrastructure.Services;
using nombremicroservicio.Repository.Brand.Command;
using nombremicroservicio.Repository.Brand.Queries;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Threading.Tasks;

namespace nombremicroservicio.API.Controllers
{
    [ApiController]
    [Route("marca")]
    public class BrandController
    {
        readonly IMediator _mediator = default!;

        public BrandController(IMediator mediator)
            => _mediator = mediator
            ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{id}")]
        public async Task<BrandDto> Get(Guid id) => await _mediator.Send(new BrandQuery(id));

        [HttpPost]
        public async Task<GuidResultDto> Post(CreateBrandCommand brand) => await _mediator.Send(brand);

        [HttpPut]
        public async Task<GuidResultDto> Put(UpdateBrandCommand brand)
        {

            var brandUpdateRequest = new UpdateBrandCommand(
                brand.Guid,  brand.Name                
            );

            await _mediator.Send(brandUpdateRequest);

            return new GuidResultDto { id = brand.Guid };
        }
        [HttpDelete("{id}")]
        public async Task Delete(Guid id) => await _mediator.Send(new DeleteBrandCommand(id));
    }
}
