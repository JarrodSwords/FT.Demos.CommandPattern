using System.Collections.Generic;

namespace FT.Demos.CommandPattern.CommandImplementations.Domain
{
    /// <summary>
    /// Command
    /// </summary>
    public interface ICommand
    {
        string Name { get; }
        void Do();
        void Undo();
        void Redo();
    }

    public class CompositeCommand : ICommand
    {
        private readonly ICollection<ICommand> _commands;

        public CompositeCommand()
        {
            _commands = new List<ICommand>();
        }

        public string Name { get; }

        public void Do()
        {
            throw new System.NotImplementedException();
        }

        public void Undo()
        {
            throw new System.NotImplementedException();
        }

        public void Redo()
        {
            throw new System.NotImplementedException();
        }
    }
}
