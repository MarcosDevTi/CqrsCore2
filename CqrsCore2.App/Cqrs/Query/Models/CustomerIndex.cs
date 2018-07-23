using AutoMapper;
using CqrsCore2.Domain;
using CqrsCore2.SharedKernel.AutoMapper;
using System;

namespace CqrsCore2.App.Cqrs.Query.Models
{
    public class CustomerIndex : ICustomMapper
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public void Mappings(IMapperConfigurationExpression config)
        {
            config.CreateMap<Customer, CustomerIndex>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.FirstName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.EmailAdress));
        }
    }
}
