using Business.Handlers.MovieDirectors.Command;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieDirectorsController : BaseApiController
    {
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateMovieDirectorCommand createMovieDirectorCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createMovieDirectorCommand));
        }

        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMovieDirectorCommand updateMovieDirectorCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateMovieDirectorCommand));
        }


        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]

        public async Task<IActionResult> Delete([FromBody] DeleteMovieDirectorCommand deleteMovieDirectorCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteMovieDirectorCommand));
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDirector))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int Id)
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetMovieDirectorQuery { Id = Id }));
        }
        [Produces("application/json", "text/plain")]

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieDirector>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetMovieDirectorsQuery()));
        }
    }
}
