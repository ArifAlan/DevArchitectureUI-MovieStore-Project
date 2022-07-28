using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Directors.Queries
{
    public class GetDirectorQuery : IRequest<IDataResult<Director>>
    {
        public int Id { get; set; }
        public class GetDirectorQueryHandler : IRequestHandler<GetDirectorQuery, IDataResult<Director>>
        {
            private readonly IDirectorRepository _directorRepository;

            public GetDirectorQueryHandler(IDirectorRepository directorRepository)
            {
                _directorRepository = directorRepository;
            }

            public async Task<IDataResult<Director>> Handle(GetDirectorQuery request, CancellationToken cancellationToken)
            {
                var director = await _directorRepository.GetAsync(p=> p.Id == p.Id);

                return new SuccessDataResult<Director>(director);
            }
        }
    }
}
