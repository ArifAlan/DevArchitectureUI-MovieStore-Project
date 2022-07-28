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
    public class GetMovieQuery : IRequest<IDataResult<Movie>>
    {
        public int Id { get; set; }
        public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, IDataResult<Movie>>
        {
            private readonly IMovieRepository _movieRepository;

            public GetMovieQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IDataResult<Movie>> Handle(GetMovieQuery request, CancellationToken cancellationToken)
            {
               var movie = await _movieRepository.GetAsync(p => p.Id == request.Id);
                return new SuccessDataResult<Movie>(movie);
            }
        }
    }
}
