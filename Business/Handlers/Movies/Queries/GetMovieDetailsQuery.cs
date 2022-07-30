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
    public class GetMovieDetailsQuery : IRequest<IDataResult<MovieDetailDto>>
    {
        public int Id { get; set; }

        public class GetMovieDetailsQueryHandler : IRequestHandler<GetMovieDetailsQuery, IDataResult<MovieDetailDto>>
        {
            private readonly IMovieRepository _movieRepository;

            public GetMovieDetailsQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IDataResult<MovieDetailDto>> Handle(GetMovieDetailsQuery request, CancellationToken cancellationToken)
            {
                var movieDetail = await _movieRepository.GetMovieDetails(request.Id);

                return new SuccessDataResult<MovieDetailDto>(movieDetail);  
            }
        }
    }
}
