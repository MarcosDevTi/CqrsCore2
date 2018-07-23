using AutoMapper;
using AutoMapper.QueryableExtensions;
using CqrsCore2.App.Cqrs.Query.Models;
using CqrsCore2.App.Cqrs.Query.Queries;
using CqrsCore2.SharedKernel.Cqrs.Query;
using System.Collections.Generic;
using System.Linq;

namespace CqrsCore2.Data.Handlers
{
    public class CustomerQueryHandler :
        IQueryHandler<GetCustomersIndex, IReadOnlyList<CustomerIndex>>,
        IQueryHandler<GetCustomerDetails, CustomerDetails>
    {
        private readonly CqrsCore2Context _context;

        public CustomerQueryHandler(CqrsCore2Context context)
        {
            _context = context;
        }

        public IReadOnlyList<CustomerIndex> Handle(GetCustomersIndex query)
        {
            return _context.Customers.ProjectTo<CustomerIndex>()
                .ToList();
        }


        public CustomerDetails Handle(GetCustomerDetails query)
        {
            var customer = _context.Customers.Find(query.Id);
            return Mapper.Map<CustomerDetails>(customer);
        }
    }
}
