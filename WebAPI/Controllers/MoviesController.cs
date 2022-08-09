using Business.Handlers.Movies.Commands;
using Business.Handlers.Movies.Queries;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : BaseApiController
    {

        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]CreateMovieCommand createMovieCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(createMovieCommand));
        }


        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateMovieCommand updateMovieCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(updateMovieCommand));
        }


        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpDelete]
        
        public async Task<IActionResult> Delete([FromBody] DeleteMovieCommand deleteMovieCommand)
        {
            return GetResponseOnlyResultMessage(await Mediator.Send(deleteMovieCommand));
        }

        /// <summary>
        /// It brings the details according to its id.
        /// </summary>
        /// <remarks>bla bla bla </remarks>
        /// <return>Users List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int movieId)
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetMovieQuery { Id = movieId }));
        }

        /// <summary>
        /// List Users
        /// </summary>
        /// <remarks>bla bla bla Users</remarks>
        /// <return>Users List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Movie>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetMoviesQuery()));
        }

        /// <summary>
        /// List Users
        /// </summary>
        /// <remarks>bla bla bla Users</remarks>
        /// <return>Users List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MovieDetailDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getmoviesdetailslist")]
        public async Task<IActionResult> GetMoviesDetailsList(int currentPage)
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetMoviesDetailsQuery { CurrentPage=currentPage}));
        }

        /// <summary>
        /// List Users
        /// </summary>
        /// <remarks>bla bla bla Users</remarks>
        /// <return>Users List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDetailDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getbyidmoviedetails")]
        public async Task<IActionResult> GetMovieDetails(int movieId)
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetMovieDetailsQuery{ Id=movieId}));
        }

        /// <summary>
        /// List Users
        /// </summary>
        /// <remarks>bla bla bla Users</remarks>
        /// <return>Users List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDetailDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("gettopmoviesdetails")]
        public async Task<IActionResult> GetTopMoviesDetails()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetTopMoviesDetailsQuery() ));
        }

        /// <summary>
        /// List Users
        /// </summary>
        /// <remarks>bla bla bla Users</remarks>
        /// <return>Users List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDetailDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getnewsmoviesdetails")]
        public async Task<IActionResult> GetNewsMoviesDetails()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetNewsMoviesDetailsQuery()));
        }

        /// <summary>
        /// List Users
        /// </summary>
        /// <remarks>bla bla bla Users</remarks>
        /// <return>Users List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDetailDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getactionMoviesDetails")]
        public async Task<IActionResult> GetActionMoviesDetails()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetActionMoviesDetailsQuery()));
        }

        /// <summary>
        /// List Users
        /// </summary>
        /// <remarks>bla bla bla Users</remarks>
        /// <return>Users List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDetailDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getcomedymoviesdetails")]
        public async Task<IActionResult> GetComedyMoviesDetails()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetComedyMoviesDetailsQuery()));
        }

        /// <summary>
        /// List Users
        /// </summary>
        /// <remarks>bla bla bla Users</remarks>
        /// <return>Users List</return>
        /// <response code="200"></response>
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MovieDetailDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [HttpGet("getmoviestotalpage")]
        public async Task<IActionResult> GetMoviesTotalPage()
        {
            return GetResponseOnlyResultData(await Mediator.Send(new GetMoviesTotalPageQuery()));
        }
    }
}
