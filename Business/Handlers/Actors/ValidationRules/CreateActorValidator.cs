using Business.Handlers.Actors.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.Actors.ValidationRules
{
    public class CreateActorValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Actor adı minimum 2 karakter olmalıdır");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Actor  soyadı minimum 2 karakter olmalıdır");
           
        }
    }

    public class UpdateActorValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Actor adı minimum 2 karakter olmalıdır");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Actor  soyadı minimum 2 karakter olmalıdır");
        }
    }
}
