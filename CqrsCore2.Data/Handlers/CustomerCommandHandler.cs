using AutoMapper;
using CqrsCore2.App.Cqrs.Command.Models;
using CqrsCore2.Domain;
using CqrsCore2.SharedKernel.Cqrs.Command;

namespace CqrsCore2.Data.Handlers
{
    public class CustomerCommandHandler :
        ICommandHandler<CreateCustomer>,
        ICommandHandler<DeleteCustomer>
    {
        private readonly CqrsCore2Context _context;

        public CustomerCommandHandler(CqrsCore2Context context)
        {
            _context = context;
        }

        public void Handle(CreateCustomer command)
        {
            _context.Customers.Add(Mapper.Map<Customer>(command));
            _context.SaveChanges();
        }

        public void Handle(DeleteCustomer command)
        {
            _context.Customers.Remove(_context.Customers.Find(command.Id));
            _context.SaveChanges();
        }
    }
}
