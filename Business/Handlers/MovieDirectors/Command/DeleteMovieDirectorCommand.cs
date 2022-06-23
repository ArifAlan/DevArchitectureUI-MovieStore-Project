using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.MovieDirectors.Command
{
    public class DeleteMovieDirectorCommand : IRequest<IResult>
    {
        public int Id { get; set; }


        public class DeleteMovieDirectorCommandHandler : IRequestHandler<DeleteMovieDirectorCommand, IResult>
        {
            private readonly IMovieDirectorRepository _movieDirectorRepository;

            public DeleteMovieDirectorCommandHandler(IMovieDirectorRepository movieDirectorRepository)
            {
                _movieDirectorRepository = movieDirectorRepository;
            }

            public async Task<IResult> Handle(DeleteMovieDirectorCommand request, CancellationToken cancellationToken)
            {
                var movieDirectorToDelete = _movieDirectorRepository.Get(p => p.Id == request.Id);

                _movieDirectorRepository.Delete(movieDirectorToDelete);
                await _movieDirectorRepository.SaveChangesAsync();
                return new SuccessResult("MovieDirector silindi");
            }
        }
    }
}
