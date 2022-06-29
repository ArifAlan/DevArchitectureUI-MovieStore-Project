using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.MovieGenres.Commands
{
    public class DeleteMovieGenreCommand: IRequest<IResult>
    {
        public int Id { get; set; }

    public class DeleteMovieGenreCommandHandler : IRequestHandler<DeleteMovieGenreCommand, IResult>
    {
        private readonly IMovieGenreRepository _movieGenreRepository;

        public DeleteMovieGenreCommandHandler(IMovieGenreRepository movieGenreRepository)
        {
            _movieGenreRepository = movieGenreRepository;
        }

        public async Task<IResult> Handle(DeleteMovieGenreCommand request, CancellationToken cancellationToken)
        {
            var movieGenreToDelete = _movieGenreRepository.Get(p => p.Id == request.Id);

            _movieGenreRepository.Delete(movieGenreToDelete);
            await _movieGenreRepository.SaveChangesAsync();
            return new SuccessResult("MovieGenre silindi");
        }
    }
    }
}
