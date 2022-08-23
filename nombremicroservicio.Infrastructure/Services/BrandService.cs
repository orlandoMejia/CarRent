using nombremicroservicio.Domain.Exceptions;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombremicroservicio.Infrastructure.Services
{
    public class BrandService : IDisposable
    {
        readonly IGenericRepository<Brand> _repository;
        public BrandService(IGenericRepository<Brand> repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository),
                "El repositorio de Marca no esta disponible");
        }

        

        public async Task<Brand> RegisterBrandAsync(Brand brand)
        {
            if (brand != null)
                try
                {
                    return await _repository.AddAsync(brand);

                }
                catch (Exception)
                {

                    throw new BrandDuplicateExceptions();
                }
            throw new BrandException();
        }

        public async Task<Brand> UpdateBrandAsync(Brand brand)
        {
            var oldBrand = await _repository.GetByIdAsync(brand.Id);

            if (oldBrand == null)
                throw new BrandException("No se ha encontrado la marca");

            oldBrand.Name = brand.Name;
           

            await _repository.UpdateAsync(oldBrand);
            return oldBrand;
        }

        public async Task DeleteBrandAsync(Guid brandId)
        {
            var brandDelete = await _repository.GetByIdAsync(brandId);
            if (brandDelete == null)
                throw new BrandException("No se ha encontrado la marca");

            await _repository.DeleteAsync(brandDelete);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            this._repository.Dispose();
        }
    }
}
