using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMovieRepository : IEntityRepository<Movie>
    {
        Task<MovieDetailDto> GetMovieDetails(int movieId);

        Task<List<MovieDetailDto>> GetMoviesDetails();

        Task<List<MovieDetailDto>> GetTopMoviesDetails();

        Task<List<MovieDetailDto>> GetNewsMoviesDetails();

        Task<List<MovieDetailDto>> GetActionMoviesDetails();

        Task<List<MovieDetailDto>> GetComedyMoviesDetails();

        Task<List<MovieDetailDto>> GetMoviesDetailsWithPagination(int limit, int skip);

        Task<List<MovieDetailDto>> GetMoviesDetailsByGenreId(int genreId);

        Task<List<MovieDetailDto>> GetMoviesDetailsWithPaginationByGenreId(int limit, int skip, int genreId);

        Task<List<MovieDetailDto>> GetMoviesDetailsByActorId(int actorId);

        Task<List<MovieDetailDto>> GetMoviesDetailsWithPaginationByActorId(int limit, int skip, int actorId);   
    }
}
