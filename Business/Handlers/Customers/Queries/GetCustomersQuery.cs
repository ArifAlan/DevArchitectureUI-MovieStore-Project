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
    public class GetCustomersQuery : IRequest<IDataResult<IEnumerable<Customer>>>
    {
        public class GetCustomerQueryHandler : IRequestHandler<GetCustomersQuery, IDataResult<IEnumerable<Customer>>>
        {
            private readonly ICustomerRepository _customerRepository;

            public GetCustomerQueryHandler(ICustomerRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<IDataResult<IEnumerable<Customer>>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
            {
                var customerList = await _customerRepository.GetListAsync();

                return new SuccessDataResult<IEnumerable<Customer>>(customerList);
            }
        }
    }
}
