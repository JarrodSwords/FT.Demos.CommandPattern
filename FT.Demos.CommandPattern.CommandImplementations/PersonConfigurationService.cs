using System;
using FT.Demos.CommandPattern.CommandImplementations.Commands;
using FT.Demos.CommandPattern.CommandImplementations.Domain;
using FT.Demos.CommandPattern.Domain.Personnel;
using FT.Demos.CommandPattern.Services;

namespace FT.Demos.CommandPattern.CommandImplementations
{
    public class PersonConfigurationService : IPersonConfigurationService
    {
        private readonly ICommandStack _commandStack;
        private readonly IPersonRepository _repository;

        public PersonConfigurationService(ICommandStack commandStack, IPersonRepository repository)
        {
            _commandStack = commandStack;
            _repository = repository;
        }

        public void Activate(Person person)
        {
            throw new NotImplementedException();
        }

        public void Activate(int id)
        {
            var command = new ActivatePersonCommand(_repository, id);
            _commandStack.Push(command);
        }

        public void Create(Person person)
        {
            var command = new CreatePersonCommand(_repository, person);
            _commandStack.Push(command);
        }

        public void Delete(int id)
        {
            var command = new DeletePersonCommand(_repository, id);
            _commandStack.Push(command);
        }

        public Person Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
