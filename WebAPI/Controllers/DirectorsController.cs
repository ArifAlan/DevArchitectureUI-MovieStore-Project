using Business.Handlers.Directors.Commands;
using Business.Handlers.Directors.Queries;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : BaseApiController
    {
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateDirectorCommand createMovieCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createMovieCommand));
        }


        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDirectorCommand updateMovieCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateMovieCommand));
        }


        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]

        public async Task<IActionResult> Delete([FromBody] DeleteDirectorCommand deleteMovieCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteMovieCommand));
        }
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Director))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int Id)
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetDirectorQuery { Id = Id }));
        }
        [Produces("application/json", "text/plain")]

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Director>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetDirectorsQuery()));
        }
    }
}
