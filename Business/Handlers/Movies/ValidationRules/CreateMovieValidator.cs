using Business.Handlers.Movies.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.Movies.ValidationRules
{
    public class CreateMovieValidator : AbstractValidator<CreateMovieCommand>
    {
        public CreateMovieValidator()
        {
            RuleFor(x => x.MovieName).MinimumLength(2).WithMessage("Movie adı  minimum 2 karakter olmalıdır"); 
           RuleFor(x => x.Description).MinimumLength(40).WithMessage("Description  minimum 40 karakter olmalıdır");
            RuleFor(x => x.IMDbRating).NotEmpty().WithMessage("IMDbRating  boş olamaz");
            RuleFor(c => c.Price).GreaterThan(0).WithMessage("IMDbRating  boş olamaz");
        }
    }

    public class UpdateMovieValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieValidator()
        {
            RuleFor(x => x.MovieName).MinimumLength(2).WithMessage("Movie adı  minimum 2 karakter olmalıdır");
            RuleFor(x => x.Description).MinimumLength(40).WithMessage("Description  minimum 40 karakter olmalıdır");
            RuleFor(x => x.IMDbRating).NotEmpty().WithMessage("IMDbRating  boş olamaz");
            RuleFor(c => c.Price).GreaterThan(0).WithMessage("IMDbRating  boş olamaz");
        }
    }
}
