using Business.Handlers.Customers.ValidationRules;
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

namespace Business.Handlers.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, IResult>
        {
            private readonly ICustomerRepository _customerRepository;
            public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }
            [ValidationAspect(typeof(CreateCustomerValidator), Priority = 2)]
            public async Task<IResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
            {
                var customer = new Customer
                {
                    Name = request.Name,
                    Surname = request.Surname,
                };

                _customerRepository.Add(customer);
                await _customerRepository.SaveChangesAsync();
                return new SuccessResult("Added customer");

            }
        }
    }
}
