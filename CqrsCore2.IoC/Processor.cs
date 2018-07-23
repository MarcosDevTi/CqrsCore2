using CqrsCore2.SharedKernel.Cqrs;
using CqrsCore2.SharedKernel.Cqrs.Command;
using CqrsCore2.SharedKernel.Cqrs.Query;
using System;

namespace CqrsCore2.IoC
{
    public class Processor : IProcessor
    {
        private readonly IServiceProvider _service;

        public Processor(IServiceProvider service) =>
            _service = service;

        public TResult Process<TResult>(IQuery<TResult> query) =>
            GetHandle(
                typeof(IQueryHandler<,>),
                query.GetType(),
                typeof(TResult))
                .Handle((dynamic)query);

        public void Send<TCommand>(TCommand command) where TCommand : ICommand =>
            GetHandle(
                typeof(ICommandHandler<>),
                command.GetType())
                .Handle(command);

        private dynamic GetHandle(Type handle, params Type[] types) =>
            _service.GetService(
                handle.MakeGenericType(types));
    }
}
