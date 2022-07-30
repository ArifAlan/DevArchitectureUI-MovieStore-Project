using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMovieRepository:IEntityRepository<Movie>
    {
        Task<MovieDetailDto> GetMovieDetails(int movieId);

        Task<List<MovieDetailDto>> GetMoviesDetails();

    }
}
