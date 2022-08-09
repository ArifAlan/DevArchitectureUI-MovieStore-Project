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
    public class GetNewsMoviesDetailsQuery:IRequest<IDataResult<IEnumerable<MovieDetailDto>>>
    {
        public class GetNewsMoviesDetailsQueryHandler : IRequestHandler<GetNewsMoviesDetailsQuery, IDataResult<IEnumerable<MovieDetailDto>>>
        {
            private readonly IMovieRepository _movieRepository;

            public GetNewsMoviesDetailsQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IDataResult<IEnumerable<MovieDetailDto>>> Handle(GetNewsMoviesDetailsQuery request, CancellationToken cancellationToken)
            {
                var result = await _movieRepository.GetNewsMoviesDetails();

                return new SuccessDataResult<IEnumerable<MovieDetailDto>>(result);
            }
        }
    }
}
