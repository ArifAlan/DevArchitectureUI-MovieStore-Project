using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.FavTypeOfMovies.Commands
{
    public class UpdateFavTypeOfMovieCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }

        public class UpdateFavTypeOfMovieCommandHandler : IRequestHandler<UpdateFavTypeOfMovieCommand, IResult>
        {
            private readonly IFavTypeOfMovieRepository _favTypeOfMovieRepository;

            public UpdateFavTypeOfMovieCommandHandler(IFavTypeOfMovieRepository favTypeOfMovieRepository)
            {
                _favTypeOfMovieRepository = favTypeOfMovieRepository;
            }

            public async Task<IResult> Handle(UpdateFavTypeOfMovieCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyFavTypeOfMovie = _favTypeOfMovieRepository.Get(p => p.Id == request.Id);
                isThereAnyFavTypeOfMovie.MovieId=request.MovieId;
                isThereAnyFavTypeOfMovie.CustomerId=request.CustomerId;

                _favTypeOfMovieRepository.Update(isThereAnyFavTypeOfMovie);
                await _favTypeOfMovieRepository.SaveChangesAsync();
                return new SuccessResult("FavTypeOfMovie güncellendi");
            }
        }
    } 
}
    

