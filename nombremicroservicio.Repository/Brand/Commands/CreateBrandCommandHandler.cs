using MediatR;
using nombremicroservicio.Infrastructure.Services;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Brand.Command
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, GuidResultDto>
    {
        readonly BrandService _clientService;

        public CreateBrandCommandHandler(BrandService clientService)
        {
            _clientService = clientService;

        }


        async Task<GuidResultDto> IRequestHandler<CreateBrandCommand, GuidResultDto>.Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clientService.RegisterBrandAsync(new Entities.Brand
            {
                Name = request.Name,
            });
            return new GuidResultDto { id = cliente.Id };
        }

    }
}
