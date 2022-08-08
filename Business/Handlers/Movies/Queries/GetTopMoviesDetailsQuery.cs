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
    public class GetTopMoviesDetailsQuery:IRequest<IDataResult<IEnumerable<MovieDetailDto>>>
    {
        public class GetTopMoviesDetailsQueryHandler : IRequestHandler<GetTopMoviesDetailsQuery, IDataResult<IEnumerable<MovieDetailDto>>>
        {
            private readonly IMovieRepository _movieRepository;

            public GetTopMoviesDetailsQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IDataResult<IEnumerable<MovieDetailDto>>> Handle(GetTopMoviesDetailsQuery request, CancellationToken cancellationToken)
            {
                var result = await _movieRepository.GetTopMoviesDetails();
                return new SuccessDataResult<IEnumerable<MovieDetailDto>>(result);
            }
        }
        
    }
}
