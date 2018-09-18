using System.Collections.Generic;
using System.Linq;

namespace FT.Demos.CommandPattern.CommandImplementations.Domain
{
    /// <summary>
    /// Invoker
    /// </summary>
    public class BasicCommandStack : ICommandStack
    {
        public Stack<ICommand> _executedCommands;
        public Stack<ICommand> _undoneCommands;

        public BasicCommandStack()
        {
            _executedCommands = new Stack<ICommand>();
            _undoneCommands = new Stack<ICommand>();
        }

        public void Push(ICommand command)
        {
            command.Do();
            _executedCommands.Push(command);
            _undoneCommands.Clear();
        }

        public void Repeat()
        {
            if (_executedCommands.Count == 0) return;

            var command = _executedCommands.Peek();
            Push(command);
        }

        public void Redo()
        {
            if (_undoneCommands.Count == 0) return;

            var command = _undoneCommands.Peek();
            command.Redo();
            _executedCommands.Push(command);
            _undoneCommands.Pop();
        }

        public void Undo()
        {
            if (_executedCommands.Count == 0) return;

            var command = _executedCommands.Peek();
            command.Undo();
            _executedCommands.Pop();
            _undoneCommands.Push(command);
        }

        public ICollection<ICommand> GetExecutedCommands()
        {
            return _executedCommands.ToList();
        }

        public ICollection<ICommand> GetUndoneCommands()
        {
            return _undoneCommands.ToList();
        }
    }
}
