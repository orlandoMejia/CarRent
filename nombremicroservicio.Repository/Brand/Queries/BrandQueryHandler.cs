using AutoMapper;
using MediatR;
using nombremicroservicio.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Brand.Queries
{
    public class BrandQueryHandler : IRequestHandler<BrandQuery, BrandDto>, IDisposable
    {

        private readonly IGenericRepository<Entities.Brand> _BrandRepository;
        private readonly IMapper _mapper;

        public BrandQueryHandler(IGenericRepository<Entities.Brand> brandRepository, IMapper mapper)
        {
            _BrandRepository = brandRepository;
        }

        public async Task<BrandDto> Handle(BrandQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException("request", "request object needed to handle this task");
            try
            {
                var brand = await _BrandRepository.GetByIdAsync(request.Id);
                if (brand == null)
                    throw new ArgumentNullException("La Marca no existe");
                return new BrandDto { Name = brand.Name };

            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            this._BrandRepository.Dispose();
        }

    }
}
