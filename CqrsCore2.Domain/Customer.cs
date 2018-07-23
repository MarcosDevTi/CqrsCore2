using CqrsCore2.Domain.ValueObjects;
using System;

namespace CqrsCore2.Domain
{
    public class Customer
    {
        protected Customer()
        {
        }
        public Customer(string firstName, string lastName, string email)
        {
            Id = Guid.NewGuid();
            Name = new Name(firstName, lastName);
            Email = new Email(email);
        }

        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
    }
}
