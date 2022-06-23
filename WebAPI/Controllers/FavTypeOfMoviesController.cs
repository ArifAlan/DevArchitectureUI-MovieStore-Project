using Business.Handlers.FavTypeOfMovies.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavTypeOfMoviesController : BaseApiController
    {
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFavTypeOfMovieCommand createFavTypeOfMovieCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createFavTypeOfMovieCommand));
        }

        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]

        public async Task<IActionResult> Delete([FromBody] DeleteFavTypeOfMovieCommand deleteFavTypeOfMovieCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteFavTypeOfMovieCommand));
        }

        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFavTypeOfMovieCommand updateFavTypeOfMovieCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateFavTypeOfMovieCommand));
        }
    }
}
