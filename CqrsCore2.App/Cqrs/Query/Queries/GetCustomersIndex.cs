using CqrsCore2.App.Cqrs.Query.Models;
using CqrsCore2.SharedKernel.Cqrs.Query;
using System.Collections.Generic;

namespace CqrsCore2.App.Cqrs.Query.Queries
{
    public class GetCustomersIndex : IQuery<IReadOnlyList<CustomerIndex>>
    {

    }
}
