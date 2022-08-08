using Business.Handlers.Actors.ValidationRules;
using Core.Aspects.Autofac.Validation;
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
    public class UpdateActorCommand:IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }


        public class UpdateActorCommandHandler : IRequestHandler<UpdateActorCommand, IResult>
        {
            private readonly IActorRepository _actorRepository;

            public UpdateActorCommandHandler(IActorRepository actorRepository)
            {
                _actorRepository = actorRepository;
            }
            [ValidationAspect(typeof(UpdateActorValidator), Priority = 1)]
            public async Task<IResult> Handle(UpdateActorCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyActor = await _actorRepository.GetAsync(p => p.Id == request.Id);
                isThereAnyActor.Name=request.Name;  
                isThereAnyActor.Surname=request.Surname;

                _actorRepository.Update(isThereAnyActor);
                await _actorRepository.SaveChangesAsync();
                return new SuccessResult("Actor Güncellendi");


            }
        }
    }
}
