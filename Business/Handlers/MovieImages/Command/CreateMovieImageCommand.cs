using Business.Constants;
using Core.Utilities.Helpers.FileHelper.Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.MovieImages.Command
{
    public class CreateMovieImageCommand:IRequest<IResult>
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string ImagePath { get; set; } //resim adı
       



        public class CreateMovieImageCommandHandler : IRequestHandler<CreateMovieImageCommand, IResult>
        {
            private readonly IMovieImageRepository _movieImageRepository;

            private readonly IFileHelper _fileHelper;
            public CreateMovieImageCommandHandler(IMovieImageRepository movieImageRepository, IFileHelper fileHelper)
            {
                _movieImageRepository = movieImageRepository;
                _fileHelper = fileHelper;
            }

            public async Task<IResult> Handle(CreateMovieImageCommand request, CancellationToken cancellationToken)
            {
               
                var movieImage = new MovieImage
                {
                    MovieId = request.MovieId,
                    ImagePath = request.ImagePath,
                    DateTime=DateTime.Now,
                   
                };
                
                _movieImageRepository.Add(movieImage);
                await _movieImageRepository.SaveChangesAsync();
                return new SuccessResult("MovieImage eklendi.");
            }
        }
    }
}
