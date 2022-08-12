using Business.Helpers;
using Core.Entities.Concrete;
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
    public class GetMoviesDetailsQuery : IRequest<IDataResult<IEnumerable<MovieDetailDto>>>
    {
        public int CurrentPage { get; set; }
        public class GetMoviesDetailsQueryHandler : IRequestHandler<GetMoviesDetailsQuery, IDataResult<IEnumerable<MovieDetailDto>>>
        {
            private readonly IMovieRepository _movieRepository;

            public GetMoviesDetailsQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IDataResult<IEnumerable<MovieDetailDto>>> Handle(GetMoviesDetailsQuery request, CancellationToken cancellationToken)
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


                var totalMoviesDetails = await _movieRepository.GetMoviesDetails();
                var countMovieDetailsData = totalMoviesDetails.Count;



                var result = await _movieRepository.GetMoviesDetailsWithPagination(limit, skipData);

                return new SuccessDataResult<IEnumerable<MovieDetailDto>>(result);
            }
        }
    }
}
