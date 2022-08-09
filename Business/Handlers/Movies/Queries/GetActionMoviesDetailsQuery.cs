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
    public class GetActionMoviesDetailsQuery : IRequest<IDataResult<IEnumerable<MovieDetailDto>>>
    {
        public class GetActionMoviesDetailsQueryHandler : IRequestHandler<GetActionMoviesDetailsQuery, IDataResult<IEnumerable<MovieDetailDto>>>
        {
            private readonly IMovieRepository _movieRepository;

            public GetActionMoviesDetailsQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IDataResult<IEnumerable<MovieDetailDto>>> Handle(GetActionMoviesDetailsQuery request, CancellationToken cancellationToken)
            {
                var result = await _movieRepository.GetActionMoviesDetails();

                return new SuccessDataResult<IEnumerable<MovieDetailDto>>(result);
            }
        }
    }
}
