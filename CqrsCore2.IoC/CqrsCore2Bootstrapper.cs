using CqrsCore2.App.Cqrs.Command.Models;
using CqrsCore2.Data;
using CqrsCore2.Data.Handlers;
using CqrsCore2.IoC.Extentions;
using CqrsCore2.SharedKernel.AutoMapper;
using CqrsCore2.SharedKernel.Cqrs;
using CqrsCore2.SharedKernel.Cqrs.Command;
using CqrsCore2.SharedKernel.Cqrs.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CqrsCore2.IoC
{
    public static class CqrsCore2Bootstrapper
    {

        public static void Register(IServiceCollection service, IConfiguration configuration)
        {
            AutoMapperConfig.Register<CreateCustomer>();

            service.AddCqrs<CustomerQueryHandler>(filter: null, typeof(IQueryHandler<,>), typeof(ICommandHandler<>));
            service.AddScoped<IProcessor, Processor>();
            service.AddDbContext<CqrsCore2Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CqrsCore2")));
        }
    }
}
