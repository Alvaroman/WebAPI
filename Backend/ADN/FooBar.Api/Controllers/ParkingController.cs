using FooBar.Application.Person.Commands;
using FooBar.Application.Person.Queries;
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

        [HttpGet("{id}")]
        public async Task<ParkingLotDto> Get(Guid id) => await _mediator.Send(new ParkingLotQuery(id));
        [HttpPost]
        public async Task Post(ParkingLotCreateCommand parking) => await _mediator.Send(parking);
        [HttpPut("release/{id}")]
        public async Task Post(Guid id) => await _mediator.Send(new ParkingLotReleaseAsyncCommand(id));

    }
}
