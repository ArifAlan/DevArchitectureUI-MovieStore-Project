using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Movies.Queries
{
    public class GetMoviesQuery : IRequest<IDataResult<IEnumerable<Movie>>>
    {
        public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IDataResult<IEnumerable<Movie>>>
        {
            private readonly IMovieRepository _movieRepository;

            public GetMoviesQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

          
            public async Task<IDataResult<IEnumerable<Movie>>> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
            {
                var movieList = await _movieRepository.GetListAsync();

                return new SuccessDataResult<IEnumerable<Movie>>(movieList);
            }
        }
    }
}
