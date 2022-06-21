using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Movies.Commands
{
    public class UpdateMovieCommand:IRequest<IResult>
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }


        public class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand, IResult>
        {
            private readonly IMovieRepository _movieRepository;

            public UpdateMovieCommandHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            public async Task<IResult> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyMovie = await _movieRepository.GetAsync(u => u.Id == request.Id);
                isThereAnyMovie.MovieName = request.MovieName;
                isThereAnyMovie.Price = request.Price;
                isThereAnyMovie.ReleaseDate = request.ReleaseDate;

                _movieRepository.Update(isThereAnyMovie);
                await _movieRepository.SaveChangesAsync();
                return new SuccessResult(Messages.Updated);
            }
        }
    }
}
