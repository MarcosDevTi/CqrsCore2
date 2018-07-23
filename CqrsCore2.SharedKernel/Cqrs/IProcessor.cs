using CqrsCore2.SharedKernel.Cqrs.Command;
using CqrsCore2.SharedKernel.Cqrs.Query;

namespace CqrsCore2.SharedKernel.Cqrs
{
    public interface IProcessor
    {
        TResult Process<TResult>(IQuery<TResult> query);
        void Send<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
