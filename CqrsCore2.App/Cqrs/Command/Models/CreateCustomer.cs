using AutoMapper;
using CqrsCore2.Domain;
using CqrsCore2.SharedKernel.AutoMapper;
using CqrsCore2.SharedKernel.Cqrs.Command;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CqrsCore2.App.Cqrs.Command.Models
{
    public class CreateCustomer : ICommand, ICustomMapper
    {
        [DisplayName("First Name"), Required]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public void Mappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<CreateCustomer, Customer>()
                .ConstructUsing(s => new Customer(s.FirstName, s.LastName, s.Email))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
