using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Genres.Queries
{
    public class GetGenresQuery : IRequest<IDataResult<IEnumerable<Genre>>>
    {
        class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, IDataResult<IEnumerable<Genre>>>
        {
            private readonly IGenreRepository _genreRepository;

            public GetGenresQueryHandler(IGenreRepository genreRepository)
            {
                _genreRepository = genreRepository;
            }

            public async Task<IDataResult<IEnumerable<Genre>>> Handle(GetGenresQuery request, CancellationToken cancellationToken)
            {
                var genreList = await _genreRepository.GetListAsync();

                return new SuccessDataResult<IEnumerable<Genre>>(genreList);
            }
        }
    }
}
