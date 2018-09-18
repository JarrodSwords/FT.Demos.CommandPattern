using System.Collections.Generic;

namespace FT.Demos.CommandPattern.CommandImplementations.Domain
{
    public interface ICommandStack
    {
        void Push(ICommand command);
        void Redo();
        void Repeat();
        void Undo();
        ICollection<ICommand> GetExecutedCommands();
        ICollection<ICommand> GetUndoneCommands();
    }
}
