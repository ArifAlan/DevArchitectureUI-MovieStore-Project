using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Actors.Commands
{
    public class DeleteActorCommand:IRequest<IResult>
    {
        public int Id { get; set; }


        public class DeleteActorCommandHandler : IRequestHandler<DeleteActorCommand,IResult>
        {
            private readonly IActorRepository _actorRepository;

            public DeleteActorCommandHandler(IActorRepository actorRepository)
            {
                _actorRepository = actorRepository;
            }

            public async Task<IResult> Handle(DeleteActorCommand request, CancellationToken cancellationToken)
            {
                var actorToDelete = _actorRepository.Get(p => p.Id == request.Id);
                
                _actorRepository.Delete(actorToDelete);
                await _actorRepository.SaveChangesAsync();
                return new SuccessResult("Actor silindi");
            }
        }
    }
}
