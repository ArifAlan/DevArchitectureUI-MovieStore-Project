using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.FavTypeOfMovies.Commands
{
    public  class CreateFavTypeOfMovieCommand:IRequest<IResult>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }


        public class CreateFavTypeOfMovieCommandHandler : IRequestHandler<CreateFavTypeOfMovieCommand, IResult>
        {
            private readonly IFavTypeOfMovieRepository _favTypeOfMovieRepository;

            public CreateFavTypeOfMovieCommandHandler(IFavTypeOfMovieRepository favTypeOfMovieRepository)
            {
                _favTypeOfMovieRepository = favTypeOfMovieRepository;
            }

            public async Task<IResult> Handle(CreateFavTypeOfMovieCommand request, CancellationToken cancellationToken)
            {
                var favTypeOfMovie = new FavTypeOfMovie
                {
                    CustomerId = request.CustomerId,
                    MovieId = request.MovieId,  
                };
                _favTypeOfMovieRepository.Add(favTypeOfMovie);
                await _favTypeOfMovieRepository.SaveChangesAsync();
                return new SuccessResult("FavTypeOfMovie eklendi");
            }
        }
    }
}
