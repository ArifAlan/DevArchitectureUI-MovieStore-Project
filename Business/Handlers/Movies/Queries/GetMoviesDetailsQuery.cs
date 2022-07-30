using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Movies.Queries
{
    public class GetMoviesDetailsQuery :IRequest<IDataResult<IEnumerable<MovieDetailDto>>>
    {
        class GetMoviesDetailsQueryHandler : IRequestHandler<GetMoviesDetailsQuery, IDataResult<IEnumerable<MovieDetailDto>>>
        {
            private readonly IMovieRepository _movieRepository;

            public GetMoviesDetailsQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IDataResult<IEnumerable<MovieDetailDto>>> Handle(GetMoviesDetailsQuery request, CancellationToken cancellationToken)
            {
                var moviesDetails = await _movieRepository.GetMoviesDetails();

                return new SuccessDataResult<IEnumerable<MovieDetailDto>>(moviesDetails);
            }
        }
    }
}
