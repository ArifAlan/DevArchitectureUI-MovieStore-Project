using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.MovieGenres.Commands
{
    public class CreateMovieGenreCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }


        public class CreateMovieGenreCommandHandler : IRequestHandler<CreateMovieGenreCommand, IResult>
        {
            private readonly IMovieGenreRepository _movieGenreRepository;

            public CreateMovieGenreCommandHandler(IMovieGenreRepository movieGenreRepository)
            {
                _movieGenreRepository = movieGenreRepository;
            }

            public async Task<IResult> Handle(CreateMovieGenreCommand request, CancellationToken cancellationToken)
            {
                var movieGenre = new MovieGenre
                {
                    MovieId = request.MovieId,
                    GenreId = request.GenreId,
                };
                _movieGenreRepository.Add(movieGenre);
                await _movieGenreRepository.SaveChangesAsync();

                return new SuccessResult("MovieGenre eklendi");
            }
        }
    }
}
