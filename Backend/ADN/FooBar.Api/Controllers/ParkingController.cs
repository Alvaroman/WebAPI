using FooBar.Application.ParkingLot.Queries;
using FooBar.Application.ParkingLot.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FooBar.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingController
    {
        readonly IMediator _mediator = default!;

        public ParkingController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        
        [HttpGet]
        public async Task<IEnumerable<ParkingLotDto>> Get() => await _mediator.Send(new ParkingLotAllQuery());
        
        [HttpGet("{id}")]
        public async Task<ParkingLotDto> Get(Guid id) => await _mediator.Send(new ParkingLotQuery(id));

        [HttpGet("{id}/cost")]
        public async Task<decimal> GetCost(Guid id) => await _mediator.Send(new ParkingLotCostQuery(id));

        [HttpPost]
        public async Task Post(ParkingLotCreateCommand parking) => await _mediator.Send(parking);

        [HttpPut("{id}/release")]
        public async Task<decimal> Release(Guid id) => await _mediator.Send(new ParkingLotReleaseAsyncCommand(id));

    }
}
