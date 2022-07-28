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
    public class GetActorsQuery : IRequest<IDataResult<IEnumerable<Actor>>>
    {
        class GetQActorsQueryHandler : IRequestHandler<GetActorsQuery, IDataResult<IEnumerable<Actor>>>
        {
            private readonly IActorRepository _actorRepository;
            public async Task<IDataResult<IEnumerable<Actor>>> Handle(GetActorsQuery request, CancellationToken cancellationToken)
            {
                var actorList = await _actorRepository.GetListAsync();

                return new SuccessDataResult<IEnumerable<Actor>>(actorList);
            }
        }
    }
}
