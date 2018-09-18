using FT.Demos.CommandPattern.CommandImplementations.Domain;
using FT.Demos.CommandPattern.Domain;
using FT.Demos.CommandPattern.Domain.Personnel;

namespace FT.Demos.CommandPattern.CommandImplementations.Commands
{
    /// <summary>
    /// Concrete command
    /// </summary>
    public class CreatePersonCommand : ICommand
    {
        private readonly IPersonRepository _repository;
        private Person _person;

        public string Name { get; } = "Create Person";

        public CreatePersonCommand(IPersonRepository repository, Person person)
        {
            _repository = repository;
            _person = person;
        }

        public void Do()
        {
            var id = _repository.Create(_person);
            _person = _repository.Get(id);
        }

        public void Undo()
        {
            _repository.Delete(_person.Id);
        }

        public void Redo()
        {
            var person = _repository.Get(_person.Id);
            person.Status = Status.Inactive;
            _repository.Update(person);
        }

        public override string ToString()
        {
            return $"{Name}:\t\t{_person}";
        }
    }

    ///// <summary>
    ///// Concrete command
    ///// </summary>
    //public class CreatePersonCommand1 : ICommand
    //{
    //    private readonly IPersonConfigurationService _service;
    //    private readonly IPersonRepository _repository;
    //    private Person _person;

    //    public string Name { get; } = "Create Person";

    //    public CreatePersonCommand1(IPersonConfigurationService service, IPersonRepository repository, Person person)
    //    {
    //        _service = service;
    //        _repository = repository;
    //        _person = person;
    //    }

    //    public void Do()
    //    {
    //        var id = _repository.Create(_person);
    //        _person = _repository.Get(id);
    //    }

    //    public void Undo()
    //    {
    //        _repository.Delete(_person.Id);
    //    }

    //    public void Redo()
    //    {
    //        var person = _repository.Get(_person.Id);
    //        person.Status = Status.Inactive;
    //        _repository.Update(person);
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Name}:\t\t{_person}";
    //    }
    //}
}
