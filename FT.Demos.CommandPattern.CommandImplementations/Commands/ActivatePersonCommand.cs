using FT.Demos.CommandPattern.CommandImplementations.Domain;
using FT.Demos.CommandPattern.Domain;
using FT.Demos.CommandPattern.Domain.Personnel;

namespace FT.Demos.CommandPattern.CommandImplementations.Commands
{
    /// <summary>
    /// Concrete command
    /// </summary>
    public class ActivatePersonCommand : ICommand
    {
        private readonly int _id;
        private readonly IPersonRepository _repository;
        private Status _previousStatus;
        private Person _person;

        public string Name { get; } = "Activate Person";

        public ActivatePersonCommand(IPersonRepository repository, int id)
        {
            _repository = repository;
            _id = id;
        }

        public void Do()
        {
            _person = _repository.Get(_id);
            _previousStatus = _person.Status;
            _person.Status = Status.Active;
            _repository.Update(_person);
        }

        public void Undo()
        {
            _person = _repository.Get(_id);
            _person.Status = _previousStatus;
            _repository.Update(_person);
        }

        public void Redo()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return $"{Name}:\t{_person}";
        }
    }
}
