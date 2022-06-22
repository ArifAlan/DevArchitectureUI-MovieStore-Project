using Core.Utilities.Results;
using DataAccess.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    class UpdateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, IResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IResult> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var isThereAnyCustomer = await _customerRepository.GetAsync(x => x.Id == request.Id);

            isThereAnyCustomer.Name=request.Name;
            isThereAnyCustomer.Surname=request.Surname;

            _customerRepository.Update(isThereAnyCustomer);
            await _customerRepository.SaveChangesAsync();
            return new SuccessResult("updated customer");
        }
    }
}
