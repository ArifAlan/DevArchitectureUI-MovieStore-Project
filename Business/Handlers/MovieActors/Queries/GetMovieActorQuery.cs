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
    public class GetMovieActorQuery : IRequest<IDataResult<MovieActor>>
    {
        public int Id { get; set; }

        public class GetMovieActorQueryHandler : IRequestHandler<GetMovieActorQuery, IDataResult<MovieActor>>
        {
            private readonly IMovieActorRepository _movieActorRepository;

            public GetMovieActorQueryHandler(IMovieActorRepository movieActorRepository)
            {
                _movieActorRepository = movieActorRepository;
            }

            public async Task<IDataResult<MovieActor>> Handle(GetMovieActorQuery request, CancellationToken cancellationToken)
            {
                var movieActor = await _movieActorRepository.GetAsync(p => p.Id == request.Id);

                return new SuccessDataResult<MovieActor>(movieActor);
            }
        }
    }
}
