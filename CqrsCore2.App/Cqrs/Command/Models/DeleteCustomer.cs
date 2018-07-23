using CqrsCore2.SharedKernel.Cqrs.Command;
using System;

namespace CqrsCore2.App.Cqrs.Command.Models
{
    public class DeleteCustomer : ICommand
    {
        public DeleteCustomer(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; private set; }
    }
}
