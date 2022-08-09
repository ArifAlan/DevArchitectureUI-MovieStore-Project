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
    public class GetComedyMoviesDetailsQuery : IRequest<IDataResult<IEnumerable<MovieDetailDto>>>
    {
        public class GetComedyMoviesDetailsQueryHandler : IRequestHandler<GetComedyMoviesDetailsQuery, IDataResult<IEnumerable<MovieDetailDto>>>
        {
            private readonly IMovieRepository _movieRepository;

            public GetComedyMoviesDetailsQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IDataResult<IEnumerable<MovieDetailDto>>> Handle(GetComedyMoviesDetailsQuery request, CancellationToken cancellationToken)
            {
                var result = await _movieRepository.GetComedyMoviesDetails();

                return new SuccessDataResult<IEnumerable<MovieDetailDto>>(result);
            }
        }
    }
}
