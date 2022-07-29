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
    public class GetMovieGenreQuery : IRequest<IDataResult<MovieGenre>>
    {
        public int Id { get; set; }
        public class GetMovieGenreQueryHandler : IRequestHandler<GetMovieGenreQuery, IDataResult<MovieGenre>>
        {
            private readonly IMovieGenreRepository _movieGenreRepository;

            public GetMovieGenreQueryHandler(IMovieGenreRepository movieGenreRepository)
            {
                _movieGenreRepository = movieGenreRepository;
            }

            public async Task<IDataResult<MovieGenre>> Handle(GetMovieGenreQuery request, CancellationToken cancellationToken)
            {
                var movieGenre = await _movieGenreRepository.GetAsync(p => p.Id==request.Id);

                return new SuccessDataResult<MovieGenre>(movieGenre);
            }
        }
    }
}
