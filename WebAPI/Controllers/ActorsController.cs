using Business.Handlers.Actors.Commands;
using Business.Handlers.Actors.Queries;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : BaseApiController
    {
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost()]
        public async Task<IActionResult> Add([FromBody] CreateActorCommand createActorCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createActorCommand));
        }

        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteActorCommand deleteActorCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteActorCommand));
        }

        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateActorCommand updateActorCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateActorCommand));
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Actor))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int Id)
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetActorQuery { Id = Id }));
        }
        [Produces("application/json", "text/plain")]

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Actor>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetActorsQuery()));
        }
    }
}