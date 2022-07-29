using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.FavTypeOfMovies.Queries
{
    public class GetFavTypeOfMoviesQuery : IRequest<IDataResult<IEnumerable<FavTypeOfMovie>>>
    {
        public class GetFavTypeOfMoviesHandler : IRequestHandler<GetFavTypeOfMoviesQuery, IDataResult<IEnumerable<FavTypeOfMovie>>>
        {
            private readonly IFavTypeOfMovieRepository _favTypeOfMovieRepository;

            public GetFavTypeOfMoviesHandler(IFavTypeOfMovieRepository favTypeOfMovieRepository)
            {
                _favTypeOfMovieRepository = favTypeOfMovieRepository;
            }

            public async Task<IDataResult<IEnumerable<FavTypeOfMovie>>> Handle(GetFavTypeOfMoviesQuery request, CancellationToken cancellationToken)
            {
                var FayTypeOfMovies = await _favTypeOfMovieRepository.GetListAsync();

                return new SuccessDataResult<IEnumerable<FavTypeOfMovie>>(FayTypeOfMovies);
            }
        }
    }
}
