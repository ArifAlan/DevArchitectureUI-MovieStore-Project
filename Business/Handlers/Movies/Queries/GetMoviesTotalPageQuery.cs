using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Movies.Queries
{
    public class GetMoviesTotalPageQuery : IRequest<IDataResult<decimal>>
    {
        public class GetMoviesTotalPageQueryHandler : IRequestHandler<GetMoviesTotalPageQuery, IDataResult<decimal>>
        {
            private readonly IMovieRepository _movieRepository;

            public GetMoviesTotalPageQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IDataResult<decimal>> Handle(GetMoviesTotalPageQuery request, CancellationToken cancellationToken)
            {
                var movies = await _movieRepository.GetMoviesDetails();
                decimal countOfMovies = movies.Count;
                decimal newValue = countOfMovies / 12;

                var totalPage = Math.Ceiling(newValue);

                return new SuccessDataResult<decimal>(totalPage);
            }
        }
    }
}
