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

    public class DeleteBrandCommandHandler : AsyncRequestHandler<DeleteBrandCommand>
    {
        readonly BrandService _brandService;

        public DeleteBrandCommandHandler(BrandService brandService)
        {
            _brandService = brandService;

        }

        protected override async Task Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandService.DeleteBrandAsync(request.Guid);
        }
    }
}
