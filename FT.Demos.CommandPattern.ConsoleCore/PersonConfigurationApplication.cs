using System;
using System.Collections.Generic;
using FT.Demos.CommandPattern.CommandImplementations.Domain;
using FT.Demos.CommandPattern.Domain.Personnel;
using FT.Demos.CommandPattern.Services;

namespace FT.Demos.CommandPattern.ConsoleCore
{
    public class PersonConfigurationApplication : IApplication
    {
        #region DI

        private readonly ICommandStack _commandStack;
        private readonly IPersonRepository _repository;
        private readonly IPersonConfigurationService _service;

        public PersonConfigurationApplication(ICommandStack commandStack, IPersonRepository repository, IPersonConfigurationService service)
        {
            _commandStack = commandStack;
            _repository = repository;
            _service = service;
        }

        #endregion

        #region IApplication

        public void Execute()
        {
            while (true)
            {
                PrintSystemInfo();

                CrLf();
                switch (Prompt("?").ToLower())
                {
                    case "activate":
                        ActivatePerson();
                        break;
                    case "+":
                    case "add":
                    case "create":
                        CreatePerson();
                        break;
                    case "-":
                    case "delete":
                    case "remove":
                        DeletePerson();
                        break;
                    case "redo":
                        _commandStack.Redo();
                        break;
                    case "repeat":
                        _commandStack.Repeat();
                        break;
                    case "undo":
                        _commandStack.Undo();
                        break;
                    case "exit":
                    case "quit":
                        return;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region Commands

        private void ActivatePerson()
        {
            var id = Convert.ToInt32(Prompt("Id"));
            _service.Activate(id);
        }

        private void CreatePerson()
        {
            var name = Prompt("First");
            var surname = Prompt("Last");
            var person = new Person {Name = name, Surname = surname};
            _service.Create(person);
        }

        private void DeletePerson()
        {
            var id = Convert.ToInt32(Prompt("Id"));
            _service.Delete(id);
        }

        #endregion

        #region UI

        private static void CrLf()
        {
            Console.WriteLine();
        }

        private void PrintCollection<T>(string header, ICollection<T> collection)
        {
            CrLf();
            Console.WriteLine($" {header}:");

            if (collection.Count == 0)
            {
                PrintNone();
                return;
            }

            foreach (var item in collection)
                Console.WriteLine($"\t{item}");
        }

        private static void PrintNone()
        {
            Console.WriteLine("\tNone");
        }

        private void PrintSystemInfo()
        {
            Console.Clear();
            PrintCollection("People", _repository.GetAll());
            PrintCollection("Deleted people", _repository.GetAllDeleted());
            PrintCollection("Command stack", _commandStack.GetExecutedCommands());
            PrintCollection("Undo stack", _commandStack.GetUndoneCommands());
        }

        private static string Prompt(string prompt)
        {
            Console.Write($" {prompt}>\t");
            return Console.ReadLine();
        }

        #endregion
    }
}
