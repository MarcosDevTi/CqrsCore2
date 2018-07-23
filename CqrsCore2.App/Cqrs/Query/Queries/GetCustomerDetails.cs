using CqrsCore2.App.Cqrs.Query.Models;
using CqrsCore2.SharedKernel.Cqrs.Query;
using System;

namespace CqrsCore2.App.Cqrs.Query.Queries
{
    public class GetCustomerDetails : IQuery<CustomerDetails>
    {
        public GetCustomerDetails(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
