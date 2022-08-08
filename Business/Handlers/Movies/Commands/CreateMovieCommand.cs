using Business.Handlers.Movies.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Movies.Commands
{
    public class CreateMovieCommand:IRequest<IResult>
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal IMDbRating { get; set; }
        public string Description { get; set; }


        public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, IResult>
        {
            private readonly IMovieRepository _movieRepository;

            
            public CreateMovieCommandHandler(IMovieRepository movieRepository)
            {
                _movieRepository = movieRepository;
            }

            [ValidationAspect(typeof(CreateMovieValidator), Priority = 1)]
            public async Task<IResult> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
            {
                var addedMovie = new Movie
                {
                    MovieName = request.MovieName,
                    Price = request.Price,  
                    ReleaseDate = request.ReleaseDate,  
                    Description = request.Description,
                    IMDbRating = request.IMDbRating,    

                };
                _movieRepository.Add(addedMovie);
                await _movieRepository.SaveChangesAsync();
                return new SuccessResult("Movie Eklendi");

            }
        }
    }
}
