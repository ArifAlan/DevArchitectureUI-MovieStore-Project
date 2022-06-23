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
    public class DeleteMovieActorCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteMovieActorCommandHandler : IRequestHandler<DeleteMovieActorCommand, IResult>
        {
            private readonly IMovieActorRepository _movieActorRepository;

            public DeleteMovieActorCommandHandler(IMovieActorRepository movieActorRepository)
            {
                _movieActorRepository = movieActorRepository;
            }

            public async Task<IResult> Handle(DeleteMovieActorCommand request, CancellationToken cancellationToken)
            {
                var deleteMovieActor = _movieActorRepository.Get(x=>x.Id==request.Id);

                _movieActorRepository.Delete(deleteMovieActor);
                await _movieActorRepository.SaveChangesAsync();

                return new SuccessResult("MovieActor deleted");
            }
        }
    }
}
