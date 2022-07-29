using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.MovieDirectors.Queries
{
    public class GetMovieDirectorQuery : IRequest<IDataResult<MovieDirector>>
    {
        public int Id { get; set; }

        class GetMovieDirectorQueryHandler : IRequestHandler<GetMovieDirectorQuery, IDataResult<MovieDirector>>
        {
            private readonly IMovieDirectorRepository _movieDirectorRepository;

            public GetMovieDirectorQueryHandler(IMovieDirectorRepository movieDirectorRepository)
            {
                _movieDirectorRepository = movieDirectorRepository;
            }

            public async Task<IDataResult<MovieDirector>> Handle(GetMovieDirectorQuery request, CancellationToken cancellationToken)
            {
                var movieDirector = await _movieDirectorRepository.GetAsync(p => p.Id == request.Id);

                return new SuccessDataResult<MovieDirector>(movieDirector);
            }
        }
    }
}
