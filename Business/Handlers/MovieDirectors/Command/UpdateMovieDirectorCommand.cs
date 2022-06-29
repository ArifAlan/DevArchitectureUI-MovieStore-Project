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
    public class UpdateMovieDirectorCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int DirectorId { get; set; }


        public class UpdateMovieDirectorCommandHandler : IRequestHandler<UpdateMovieDirectorCommand, IResult>
        {
            private readonly IMovieDirectorRepository _movieDirectorRepository;

            public UpdateMovieDirectorCommandHandler(IMovieDirectorRepository movieDirectorRepository)
            {
                _movieDirectorRepository = movieDirectorRepository;
            }

            public async Task<IResult> Handle(UpdateMovieDirectorCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyMovieDirector = _movieDirectorRepository.Get(p => p.Id == request.Id);
                isThereAnyMovieDirector.DirectorId = request.DirectorId;
                isThereAnyMovieDirector.MovieId = request.MovieId;

                _movieDirectorRepository.Update(isThereAnyMovieDirector);
                await _movieDirectorRepository.SaveChangesAsync();
                return new SuccessResult("MovieDirector güncellendi");
            }
        }
    }
}
