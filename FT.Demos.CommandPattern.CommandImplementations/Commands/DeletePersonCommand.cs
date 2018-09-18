using FT.Demos.CommandPattern.CommandImplementations.Domain;
using FT.Demos.CommandPattern.Domain.Personnel;

namespace FT.Demos.CommandPattern.CommandImplementations.Commands
{
    /// <summary>
    /// Concrete command
    /// </summary>
    public class DeletePersonCommand : ICommand
    {
        private readonly IPersonRepository _repository;
        private readonly int _id;
        private Person _person;

        public string Name { get; } = "Delete Person";

        public DeletePersonCommand(IPersonRepository repository, int id)
        {
            _repository = repository;
            _id = id;
        }

        public void Do()
        {
            _person = _repository.Get(_id);
            _repository.Delete(_id);
        }

        public void Undo()
        {
            _repository.Create(_person);
        }

        public void Redo()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Name}:\t\t{_person}";
        }
    }
}
