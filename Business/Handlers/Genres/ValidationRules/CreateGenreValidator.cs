using Business.Handlers.Genres.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.Genres.ValidationRules
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Genre  adı  minimum 2 karakter olmalıdır");
          

        }
    }

    public class UpdateGenreValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Genre  adı  minimum 2 karakter olmalıdır");


        }
    }
}
