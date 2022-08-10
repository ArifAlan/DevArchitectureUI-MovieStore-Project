using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Movies.Queries
{
    public class GetMoviesDetailsTotalPageByGenreIdQuery : IRequest<IDataResult<Decimal>>
    {
        public int GenreId { get; set; }
        public class GetMoviesDetailsTotalPageByGenreIdQueryHandler : IRequestHandler<GetMoviesDetailsTotalPageByGenreIdQuery, IDataResult<Decimal>>
        {
            private readonly IMovieRepository _movieRepository;

            public GetMoviesDetailsTotalPageByGenreIdQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IDataResult<decimal>> Handle(GetMoviesDetailsTotalPageByGenreIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _movieRepository.GetMoviesDetailsByGenreId(request.GenreId);
                decimal countOfData = data.Count;
                decimal newValue = countOfData / 8;
                decimal total = Math.Ceiling(newValue);

                return new SuccessDataResult<decimal>(total);
            }
        }
    }
}
