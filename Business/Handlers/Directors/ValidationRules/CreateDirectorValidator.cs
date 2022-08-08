using Business.Handlers.Directors.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.Directors.ValidationRules
{
    public class CreateDirectorValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Director  adı  minimum 2 karakter olmalıdır");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Director soyadı   minimum 2 karakter olmalıdır");

        }
    }

    public class UpdateDirectorValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Director  adı  minimum 2 karakter olmalıdır");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Director soyadı   minimum 2 karakter olmalıdır");
        }
    }
}
