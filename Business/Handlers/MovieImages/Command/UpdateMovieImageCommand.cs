using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.MovieImages.Command
{
    public class UpdateMovieImageCommand:IRequest<IResult>
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string ImagePath { get; set; } //resim adı


        public class UpdateMovieImageCommandHnadler : IRequestHandler<UpdateMovieImageCommand, IResult>
        {
            private readonly IMovieImageRepository _movieImageRepository;

            public UpdateMovieImageCommandHnadler(IMovieImageRepository movieImageRepository)
            {
                _movieImageRepository = movieImageRepository;
            }

            public async Task<IResult> Handle(UpdateMovieImageCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyMovieImage = await _movieImageRepository.GetAsync(x => x.Id == request.Id);
                isThereAnyMovieImage.MovieId = request.MovieId;
                isThereAnyMovieImage.ImagePath = request.ImagePath;
                isThereAnyMovieImage.DateTime = DateTime.Now;

                _movieImageRepository.Update(isThereAnyMovieImage);
                await _movieImageRepository.SaveChangesAsync();
                return new SuccessResult("movieImage updated");
            }
        }
    }
}
