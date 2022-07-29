using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Handlers.Customers.Queries
{
    public class GetCustomerQuery : IRequest<IDataResult<Customer>>
    {
        public int Id { get; set; }
        public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, IDataResult<Customer>>
        {
            private readonly ICustomerRepository _customerRepository;

            public GetCustomerQueryHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<IDataResult<Customer>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
            {
                var customer = await _customerRepository.GetAsync(p => p.Id == request.Id);

                return new SuccessDataResult<Customer>(customer);
            }
        }
    }
}
