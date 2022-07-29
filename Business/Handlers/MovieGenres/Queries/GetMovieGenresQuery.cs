using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.MovieGenres.Queries
{
    public class GetMovieGenresQuery : IRequest<IDataResult<IEnumerable<MovieGenre>>>
    {
        public class GetMovieGenresQueryHandler : IRequestHandler<GetMovieGenresQuery, IDataResult<IEnumerable<MovieGenre>>>
        {
            private readonly IMovieGenreRepository _movieGenreRepository;

            public GetMovieGenresQueryHandler(IMovieGenreRepository movieGenreRepository)
            {
                _movieGenreRepository = movieGenreRepository;
            }

            public async Task<IDataResult<IEnumerable<MovieGenre>>> Handle(GetMovieGenresQuery request, CancellationToken cancellationToken)
            {
                var movieGenresList = await _movieGenreRepository.GetListAsync();

                return new SuccessDataResult<IEnumerable<MovieGenre>>(movieGenresList);
            }
        }
    }
}
