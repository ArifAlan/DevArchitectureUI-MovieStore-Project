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
    public class DeleteFavTypeOfMovieCommand:IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteFavTypeOfMovieCommandHandler : IRequestHandler<DeleteFavTypeOfMovieCommand, IResult>
        {
            private readonly IFavTypeOfMovieRepository _favTypeOfMovieRepository;

            public DeleteFavTypeOfMovieCommandHandler(IFavTypeOfMovieRepository favTypeOfMovieRepository)
            {
                _favTypeOfMovieRepository = favTypeOfMovieRepository;
            }

            public async Task<IResult> Handle(DeleteFavTypeOfMovieCommand request, CancellationToken cancellationToken)
            {
                var favTypeOfMovieToDelete = _favTypeOfMovieRepository.Get(p => p.Id == request.Id);

                _favTypeOfMovieRepository.Delete(favTypeOfMovieToDelete);
                await _favTypeOfMovieRepository.SaveChangesAsync();
                return new SuccessResult("FavTypeOfMovie silindi");
            }
        }
    }
}
