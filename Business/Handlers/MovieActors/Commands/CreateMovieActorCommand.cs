using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.MovieActors.Commands
{
    public class CreateMovieActorCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public class CreateMovieActorHandler : IRequestHandler<CreateMovieActorCommand, IResult>
        {
            private readonly IMovieActorRepository _movieActorRepository;

            public CreateMovieActorHandler(IMovieActorRepository movieActorRepository)
            {
                _movieActorRepository = movieActorRepository;
            }

            public async Task<IResult> Handle(CreateMovieActorCommand request, CancellationToken cancellationToken)
            {
                var movieActor = new MovieActor
                {
                    MovieId = request.MovieId,
                    ActorId = request.ActorId,
                };

                _movieActorRepository.Add(movieActor);
                await _movieActorRepository.SaveChangesAsync();

                return new SuccessResult("MovieActor added");
            }
        }
    }
}
