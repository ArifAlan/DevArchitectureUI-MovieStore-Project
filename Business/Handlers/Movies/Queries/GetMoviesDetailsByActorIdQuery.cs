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
    public class GetMoviesDetailsByActorIdQuery : IRequest<IDataResult<IEnumerable<MovieDetailDto>>>
    {
        public int ActorId { get; set; }
        public int CurrentPage { get; set; }

        public class GetMoviesDetailsByActorIdQueryHandler : IRequestHandler<GetMoviesDetailsByActorIdQuery, IDataResult<IEnumerable<MovieDetailDto>>>
        {
            private readonly IMovieRepository _movieRepository;

            public GetMoviesDetailsByActorIdQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IDataResult<IEnumerable<MovieDetailDto>>> Handle(GetMoviesDetailsByActorIdQuery request, CancellationToken cancellationToken)
            {
                int limit = 12;
                int skipData;

                if (request.CurrentPage == 1 || request.CurrentPage == 0)
                {
                    skipData = 0;
                }
                else
                {
                    skipData = (Math.Abs(request.CurrentPage - 1) * limit);
                }
                
                var result = await _movieRepository.GetMoviesDetailsWithPaginationByActorId(limit, skipData, request.ActorId);

                return new SuccessDataResult<IEnumerable<MovieDetailDto>>(result);


            }
        }
    }
}
