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
    public class DriveWayService : IDisposable
    {
        readonly IGenericRepository<DriveWay> _repository;
        public DriveWayService(IGenericRepository<DriveWay> repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository),
                "El repositorio de Marca no esta disponible");
        }

        public async Task<DriveWay> RegisterDriveWayAsync(DriveWay driveWay)
        {
            if (driveWay != null)
                return await _repository.AddAsync(driveWay);
            throw new DriveWayException();
        }

        public async Task<DriveWay> UpdateDriveWayAsync(DriveWay driveWay)
        {
            var oldDriveWay = await _repository.GetByIdAsync(driveWay.Id);

            if (oldDriveWay == null)
                throw new DriveWayException("No se ha encontrado la marca");

            oldDriveWay.Name = driveWay.Name;
           

            await _repository.UpdateAsync(oldDriveWay);
            return oldDriveWay;
        }

        public async Task DeleteDriveWayAsync(Guid driveWayId)
        {
            var driveWayDelete = await _repository.GetByIdAsync(driveWayId);
            if (driveWayDelete == null)
                throw new DriveWayException("No se ha encontrado la marca");

            await _repository.DeleteAsync(driveWayDelete);
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
