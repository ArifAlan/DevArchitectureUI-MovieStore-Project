using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Movies.Queries
{
    public class GetMoviesDetailsTotalPageByActorIdQuery : IRequest<IDataResult<Decimal>>
    {
        public int ActorId { get; set; }
        public class GetMoviesDetailsTotalPageByActorIdQueryHandler : IRequestHandler<GetMoviesDetailsTotalPageByActorIdQuery, IDataResult<Decimal>>
        {
            private readonly IMovieRepository _movieRepository;

            public GetMoviesDetailsTotalPageByActorIdQueryHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IDataResult<decimal>> Handle(GetMoviesDetailsTotalPageByActorIdQuery request, CancellationToken cancellationToken)
            {
                var data = await _movieRepository.GetMoviesDetailsByActorId(request.ActorId);
                decimal countOfData = data.Count;
                decimal newValue = countOfData / 12;
                decimal total = Math.Ceiling(newValue);

                return new SuccessDataResult<Decimal>(total);
            }
        }
    }
}
