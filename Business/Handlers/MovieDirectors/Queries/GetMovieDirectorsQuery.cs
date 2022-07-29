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
    public class GetMovieDirectorsQuery : IRequest<IDataResult<IEnumerable<MovieDirector>>>
    {
        public class GetMovieDirectorsQueryHandler : IRequestHandler<GetMovieDirectorsQuery, IDataResult<IEnumerable<MovieDirector>>>
        {
            private readonly IMovieDirectorRepository _movieDirectorRepository;

            public GetMovieDirectorsQueryHandler(IMovieDirectorRepository movieDirectorRepository)
            {
                _movieDirectorRepository = movieDirectorRepository;
            }

            public async Task<IDataResult<IEnumerable<MovieDirector>>> Handle(GetMovieDirectorsQuery request, CancellationToken cancellationToken)
            {
                var movieDirectorsList = await _movieDirectorRepository.GetListAsync();

                return new SuccessDataResult<IEnumerable<MovieDirector>>(movieDirectorsList);
            }
        }
    }
}
