using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Actors.Queries
{
    public class GetActorQuery : IRequest<IDataResult<Actor>>
    {
        public int Id { get; set; }
        class GetActorQueryHandler : IRequestHandler<GetActorQuery, IDataResult<Actor>>
        {
            private readonly IActorRepository _actorRepository;

            public GetActorQueryHandler(IActorRepository actorRepository)
            {
                _actorRepository = actorRepository;
            }

            public async Task<IDataResult<Actor>> Handle(GetActorQuery request, CancellationToken cancellationToken)
            {
                var actor = await _actorRepository.GetAsync(p => p.Id == request.Id);
                return new SuccessDataResult<Actor>(actor);
            }
        }
    }
}
