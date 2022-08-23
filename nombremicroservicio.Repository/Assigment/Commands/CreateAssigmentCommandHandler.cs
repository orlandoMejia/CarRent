using MediatR;
using nombremicroservicio.Domain.Interfaces;
using nombremicroservicio.Infrastructure.Services;
using nombremicroservicio.Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace nombremicroservicio.Repository.Assigment.Command
{
    public class CreateAssigmentCommandHandler : IRequestHandler<CreateAssigmentCommand, GuidResultDto>
    {
        readonly AssigmentService _assigmentService;
        readonly IGenericRepository<Entities.DriveWay> _repositoryDriveWay;
        readonly IGenericRepository<Entities.Client> _repositoryClient;

        public CreateAssigmentCommandHandler(AssigmentService assigmentService, IGenericRepository<Entities.DriveWay> repositoryDriveWay, IGenericRepository<Entities.Client> repositoryClient)
        {
            _assigmentService = assigmentService;
            _repositoryDriveWay = repositoryDriveWay;
            _repositoryClient = repositoryClient;
        }

        async Task<GuidResultDto> IRequestHandler<CreateAssigmentCommand, GuidResultDto>.Handle(CreateAssigmentCommand request, CancellationToken cancellationToken)
        {

            var client = await _repositoryClient.GetByIdAsync(request.IdClient);
            if (client == null)
                throw new ArgumentException("El cliente no existe");
            var driveWay = await _repositoryDriveWay.GetByIdAsync(request.IdDriveWay);
            if (driveWay == null)
                throw new ArgumentException("El patio no existe");
            var assigmente = await _assigmentService.RegisterAssigmentAsync(new Entities.Assigment
            {
                Date = request.Date,
                Client = client,
                DriveWay = driveWay
            });
            return new GuidResultDto { id = assigmente.Id };
        }

    }
}
