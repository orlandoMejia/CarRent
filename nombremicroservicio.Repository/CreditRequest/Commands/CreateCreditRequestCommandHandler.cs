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

namespace nombremicroservicio.Repository.CreditRequest.Command
{
    public class CreateCreditRequestCommandHandler : IRequestHandler<CreateCreditRequestCommand, GuidResultDto>
    {
        readonly CreditRequestService _creditRequestService;
        readonly IGenericRepository<Entities.DriveWay> _driveWayRepository;
        readonly IGenericRepository<Entities.Executive> _executiveRepository;
        readonly IGenericRepository<Entities.Brand> _brandRepository;
        readonly IGenericRepository<Entities.Client> _clientRepository;

        public CreateCreditRequestCommandHandler(CreditRequestService creditRequestService, IGenericRepository<Entities.DriveWay> driveWayRepository,
            IGenericRepository<Entities.Executive> executiveRepository, IGenericRepository<Entities.Brand> brandRepository,
            IGenericRepository<Entities.Client> clientRepository)
        {
            _creditRequestService = creditRequestService;
            _driveWayRepository = driveWayRepository;
            _executiveRepository = executiveRepository;
            _brandRepository = brandRepository;
            _clientRepository = clientRepository;
        }

        async Task<GuidResultDto> IRequestHandler<CreateCreditRequestCommand, GuidResultDto>.Handle(CreateCreditRequestCommand request, CancellationToken cancellationToken)
        {
            var executive = await _executiveRepository.GetByIdAsync(request.IdExecutive);
            if (executive == null)
                throw new ArgumentException("No exixte el vendedor");
            var client = await _clientRepository.GetByIdAsync(request.IdClient);
            if (client == null)
                throw new ArgumentException("No existe el cliente");
            var brand = await _brandRepository.GetByIdAsync(request.IdBrand);
            if (brand == null)
                throw new ArgumentException("No existe la marca");
            var driveWay = await _driveWayRepository.GetByIdAsync(request.IdDriveWay);
            if (driveWay == null)
                throw new ArgumentException("No existe el patio");

            var creditRequest = await _creditRequestService.RegisterCreditRequestAsync(new Entities.CreditRequest
            {
                CreateDate = request.CreateDate,
                Place = request.Place,
                Vehicle = request.Vehicle,
                Months = request.Months,
                Quota = request.Quota,
                Entry = request.Entry,
                RequestType = request.RequestType,
                Id = request.IdClient,
                IdExecutive = request.IdExecutive,
                IdBrand = request.IdBrand,
                IdDriveWay = request.IdDriveWay,
                IdClient = request.IdClient,
                Observation = request.Observation,

            });

            return new GuidResultDto { id = creditRequest.Id };
        }
    }
}
