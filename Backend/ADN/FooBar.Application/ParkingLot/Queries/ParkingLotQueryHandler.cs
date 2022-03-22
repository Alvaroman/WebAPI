using AutoMapper;
using FooBar.Domain.Ports;
using MediatR;

namespace FooBar.Application.ParkingLot.Queries
{
    public class ParkingLotQueryHandler : IRequestHandler<ParkingLotQuery, ParkingLotDto>
    {
        private readonly IGenericRepository<Domain.Entities.ParkingLot> _repository;
        private readonly IMapper _mapper;

        public ParkingLotQueryHandler(IGenericRepository<Domain.Entities.ParkingLot> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ParkingLotDto> Handle(ParkingLotQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");
            var parkingModel = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ParkingLotDto>(parkingModel);
        }
    }
}
