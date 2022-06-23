using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.MovieActors.Commands
{
    public class UpdateMovieActorCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int ActorId { get; set; }
        public int MovieId { get; set; }

        public class UpdateMovieActorCommandHandler : IRequestHandler<UpdateMovieActorCommand, IResult>
        {
            private readonly IMovieActorRepository _movieActorRepository;

            public UpdateMovieActorCommandHandler(IMovieActorRepository movieActorRepository)
            {
                _movieActorRepository = movieActorRepository;
            }

            public async Task<IResult> Handle(UpdateMovieActorCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyMovieActor = _movieActorRepository.Get(x => x.Id == request.Id);

                isThereAnyMovieActor.ActorId = request.ActorId;
                isThereAnyMovieActor.MovieId = request.MovieId;

                _movieActorRepository.Update(isThereAnyMovieActor);
                await _movieActorRepository.SaveChangesAsync();

                return new SuccessResult("Updated MovieActor");
            }
        }
    }
}
