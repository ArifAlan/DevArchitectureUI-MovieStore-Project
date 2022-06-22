using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Actors.Commands
{
    public class CreateActorCommand:IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }


        public class CreateActorCommandHandler : IRequestHandler<CreateActorCommand, IResult>
        {
            private readonly IActorRepository _actorRepository;

            public CreateActorCommandHandler(IActorRepository actorRepository)
            {
                _actorRepository = actorRepository;
            }

            public async Task<IResult> Handle(CreateActorCommand request, CancellationToken cancellationToken)
            {
                var addedActor = new Actor
                {
                    Name = request.Name,
                    Surname = request.Surname,
                };
                _actorRepository.Add(addedActor);    
                await _actorRepository.SaveChangesAsync();
                return new SuccessResult("Actor Eklendi");
            }
        }
    }
}
