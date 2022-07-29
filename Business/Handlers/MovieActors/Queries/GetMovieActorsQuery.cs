using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.MovieActors.Queries
{
    public class GetMovieActorsQuery : IRequest<IDataResult<IEnumerable<MovieActor>>>
    {
        public class GetMovieActorsQueryHandler : IRequestHandler<GetMovieActorsQuery, IDataResult<IEnumerable<MovieActor>>>
        {
            private readonly IMovieActorRepository _movieActorRepository;

            public GetMovieActorsQueryHandler(IMovieActorRepository movieActorRepository)
            {
                _movieActorRepository = movieActorRepository;
            }

            public async Task<IDataResult<IEnumerable<MovieActor>>> Handle(GetMovieActorsQuery request, CancellationToken cancellationToken)
            {
                var movieActorsList = await _movieActorRepository.GetListAsync();

                return new SuccessDataResult<IEnumerable<MovieActor>>(movieActorsList);
            }
        }
    }
}
