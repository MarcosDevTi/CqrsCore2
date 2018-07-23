using CqrsCore2.Data;
using CqrsCore2.SharedKernel.Cqrs.Command;
using CqrsCore2.SharedKernel.Cqrs.Query;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace CqrsCore2.IoC.Extentions
{
    public static class CqrsExtentions
    {
        public static void AddCqrs(this IServiceCollection service, Func<AssemblyName, bool> filter = null)
        {
            var handlers = new[] { typeof(IQueryHandler<,>), typeof(ICommandHandler<>) };

            var target = typeof(CqrsCore2Context).Assembly;
            bool LoadFilters(AssemblyName x) => true;

            var assemblies = target.GetReferencedAssemblies()
                .Where(filter ?? LoadFilters)
                .Select(Assembly.Load)
                .ToList();

            assemblies.Add(target);

            var allTypes = assemblies.SelectMany(a => a.GetExportedTypes());

            var types = from t in allTypes
                        from i in t.GetInterfaces()
                        where i.IsConstructedGenericType &&
                              handlers.Contains(i.GetGenericTypeDefinition())
                        select new { i, t };

            foreach (var tp in types) service.AddScoped(tp.i, tp.t);


        }
    }
}
