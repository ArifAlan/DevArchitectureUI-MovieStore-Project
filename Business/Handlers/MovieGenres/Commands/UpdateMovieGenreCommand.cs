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
    public class UpdateMovieGenreCommand: IRequest<IResult>
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int GenreId { get; set; }

        public class UpdateMovieGenreCommandHandler : IRequestHandler<UpdateMovieGenreCommand, IResult>
        {
            private readonly IMovieGenreRepository _movieGenreRepository;
            public UpdateMovieGenreCommandHandler(IMovieGenreRepository movieGenreRepository)
            {
                _movieGenreRepository = movieGenreRepository;
            }

            public async Task<IResult> Handle(UpdateMovieGenreCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyMovieGenre = _movieGenreRepository.Get(x => x.Id == request.Id);
                isThereAnyMovieGenre.MovieId = request.MovieId;
                isThereAnyMovieGenre.GenreId = request.GenreId;

                _movieGenreRepository.Update(isThereAnyMovieGenre);
                await _movieGenreRepository.SaveChangesAsync();
                return new SuccessResult("Updated MovieGenre");
            }
        }

    }
}
