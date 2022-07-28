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
    public class GetDirectorsQuery : IRequest<IDataResult<IEnumerable<Director>>>
    {
        public class GetDirectoryQueryHandler : IRequestHandler<GetDirectorsQuery, IDataResult<IEnumerable<Director>>>
        {
            private readonly IDirectorRepository _directorRepository;

            public GetDirectoryQueryHandler(IDirectorRepository directorRepository)
            {
                _directorRepository = directorRepository;
            }

            public  async Task<IDataResult<IEnumerable<Director>>> Handle(GetDirectorsQuery request, CancellationToken cancellationToken)
            {
                var directorList = await _directorRepository.GetListAsync();

                return new SuccessDataResult<IEnumerable<Director>>(directorList);
            }
        }
    }
}
