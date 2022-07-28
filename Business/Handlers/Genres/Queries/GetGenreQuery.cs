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
    public class GetGenreQuery : IRequest<IDataResult<Genre>>
    {
        public int Id { get; set; }

        class GetGenreQueryHandler : IRequestHandler<GetGenreQuery, IDataResult<Genre>>
        {
            private readonly IGenreRepository _genreRepository;

            public GetGenreQueryHandler(IGenreRepository genreRepository)
            {
                _genreRepository = genreRepository;
            }

            public async Task<IDataResult<Genre>> Handle(GetGenreQuery request, CancellationToken cancellationToken)
            {
                var genre = await _genreRepository.GetAsync(p => p.Id == request.Id);

                return new SuccessDataResult<Genre>(genre);
            }
        }
    }
}
