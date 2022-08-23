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
    public class AssigmentService : IDisposable
    {
        readonly IGenericRepository<Assigment> _repository;
        public AssigmentService(IGenericRepository<Assigment> repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository),
                "El repositorio de Marca no esta disponible");
        }

        public async Task<Assigment> RegisterAssigmentAsync(Assigment assigment)
        {
            if (assigment != null)
                return await _repository.AddAsync(assigment);
            throw new AssigmentException();
        }

        public async Task<Assigment> UpdateAssigmentAsync(Assigment assigment)
        {
            var oldAssigment = await _repository.GetByIdAsync(assigment.Id);

            if (oldAssigment == null)
                throw new AssigmentException("No se ha encontrado la asignación");

            oldAssigment.Date = assigment.Date;
            oldAssigment.DriveWay = assigment.DriveWay;
            oldAssigment.Client = assigment.Client;
           

            await _repository.UpdateAsync(oldAssigment);
            return oldAssigment;
        }

        public async Task DeleteAssigmentAsync(Guid assigmentId)
        {
            var assigmentDelete = await _repository.GetByIdAsync(assigmentId);
            if (assigmentDelete == null)
                throw new AssigmentException("No se ha encontrado la marca");

            await _repository.DeleteAsync(assigmentDelete);
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
