using Business.Handlers.Customers.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Handlers.Customers.ValidationRules
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Customer  adı  minimum 2 karakter olmalıdır");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Customer soyadı  minimum 2 karakter olmalıdır");

        }
    }

    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Customer  adı  minimum 2 karakter olmalıdır");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Customer soyadı  minimum 2 karakter olmalıdır");
        }
    }
}
