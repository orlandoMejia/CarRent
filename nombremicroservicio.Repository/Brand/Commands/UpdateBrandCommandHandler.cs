using MediatR;
using nombremicroservicio.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Brand.Command
{
    public class UpdateBrandCommandHandler : AsyncRequestHandler<UpdateBrandCommand>
    {
        readonly BrandService _brandService;

        public UpdateBrandCommandHandler(BrandService brandService)
        {
            _brandService = brandService;

        }

        protected override async Task Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandService.UpdateBrandAsync(new Entities.Brand
            {
                Id = request.Guid,
                Name = request.Name,
            });
        }
    }
}
