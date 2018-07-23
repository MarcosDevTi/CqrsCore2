using AutoMapper;

namespace CqrsCore2.SharedKernel.AutoMapper
{
    public interface ICustomMapper
    {
        void Mappings(IMapperConfigurationExpression config);
    }
}
