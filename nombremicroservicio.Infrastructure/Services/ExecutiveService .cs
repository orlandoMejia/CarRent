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
    public class ExecutiveService : IDisposable
    {
        readonly IGenericRepository<Executive> _repository;

        public ExecutiveService(IGenericRepository<Executive> repository)
        {
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository),
                "El repositorio de Executivees no esta disponible");
        }

        public async Task<Executive> RegisterExecutiveAsync(Executive executive)
        {
            if (executive != null)
                try
                {
                    return await _repository.AddAsync(executive);

                }
                catch (Exception)
                {

                    throw new ExecutiveDuplicateExceptions();
                }
            throw new ExecutiveException();
        }

        public async Task<Executive> UpdateExecutiveAsync(Executive executive)
        {
            var oldExecutive = await _repository.GetByIdAsync(executive.Id);

            if (oldExecutive == null)
                throw new ExecutiveException("No se ha encontrado el executivee");

            oldExecutive.IdentificationNumber = executive.IdentificationNumber;
            oldExecutive.Names = executive.Names;
            oldExecutive.LastNames = executive.LastNames;
            oldExecutive.Address = executive.Address;
            oldExecutive.Phone = executive.Phone;
            oldExecutive.Celphone = executive.Celphone;
            oldExecutive.DriveWay = executive.DriveWay;
            oldExecutive.Age = executive.Age;

           

            await _repository.UpdateAsync(oldExecutive);
            return oldExecutive;
        }

        public async Task DeleteExecutiveAsync(Guid executiveId)
        {
            var executiveDelete = await _repository.GetByIdAsync(executiveId);
            if (executiveDelete == null)
                throw new ExecutiveException("No se ha encontrado el executivee");

            await _repository.DeleteAsync(executiveDelete);
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
