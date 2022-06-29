using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.MovieDirectors.Command
{
    public class CreateMovieDirectorCommand:IRequest<IResult>
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int DirectorId { get; set; }


        public class CreateMovieDirectorCommandHandler : IRequestHandler<CreateMovieDirectorCommand, IResult>
        {
            private readonly IMovieDirectorRepository _movieDirectorRepository;

            public CreateMovieDirectorCommandHandler(IMovieDirectorRepository movieDirectorRepository)
            {
                _movieDirectorRepository = movieDirectorRepository;
            }

            public async Task<IResult> Handle(CreateMovieDirectorCommand request, CancellationToken cancellationToken)
            {
                var movieDirector = new MovieDirector
                {
                    MovieId = request.MovieId,  
                    DirectorId = request.DirectorId,
                };
                _movieDirectorRepository.Add(movieDirector);
                await _movieDirectorRepository.SaveChangesAsync();
                return new SuccessResult("MovieDirector eklendi.");
            }
        }
    }
}
