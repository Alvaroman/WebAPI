using AutoMapper;
using FooBar.Domain.Ports;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.Application.ParkingLot.Queries
{
    public class ParkingLotQueryAllHandler : IRequestHandler<ParkingLotAllQuery,IEnumerable<ParkingLotDto>>
    {
        private readonly IGenericRepository<Domain.Entities.ParkingLot> _repository;
        private readonly IMapper _mapper;

        public ParkingLotQueryAllHandler(IGenericRepository<Domain.Entities.ParkingLot> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ParkingLotDto>> Handle(ParkingLotAllQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");
            var parkingLots = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<ParkingLotDto>>(parkingLots);
        }
    }
}
