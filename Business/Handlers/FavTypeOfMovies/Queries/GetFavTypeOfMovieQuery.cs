using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.FavTypeOfMovies.Queries
{
    public class GetFavTypeOfMovieQuery : IRequest<IDataResult<FavTypeOfMovie>>
    {
        public int Id { get; set; }

        public class GetFavTypeOfMovieHandler : IRequestHandler<GetFavTypeOfMovieQuery, IDataResult<FavTypeOfMovie>>
        {
            private readonly IFavTypeOfMovieRepository _favTypeOfMovieRepository;

            public GetFavTypeOfMovieHandler(IFavTypeOfMovieRepository favTypeOfMovieRepository)
            {
                _favTypeOfMovieRepository = favTypeOfMovieRepository;
            }

            public async Task<IDataResult<FavTypeOfMovie>> Handle(GetFavTypeOfMovieQuery request, CancellationToken cancellationToken)
            {
                var favTypeOfMovie = await _favTypeOfMovieRepository.GetAsync(p => p.Id == request.Id);

                return new SuccessDataResult<FavTypeOfMovie>(favTypeOfMovie);
            }
        }
    }
}
