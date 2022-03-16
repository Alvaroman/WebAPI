using FooBar.Application.Person.Commands;
using FooBar.Application.Person.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FooBar.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PersonController
    {

        readonly IMediator _mediator = default!;

        public PersonController(IMediator mediator) => _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpGet("{id}")]
        public async Task<PersonDto> Get(Guid id) => await _mediator.Send(new PersonQuery(id));

        [HttpPost]
        public async Task Post(PersonCreateCommand person) => await _mediator.Send(person);

        [HttpPut("{id}")]
        public async Task Put(PersonCreateCommand person, Guid id)
        {

            var personUpdateRequest = new PersonUpdateAsyncCommand(
                id, person.FirstName, person.LastName, person.Email, person.DateOfBirth
            );

            await _mediator.Send(personUpdateRequest);
        }

    }
}