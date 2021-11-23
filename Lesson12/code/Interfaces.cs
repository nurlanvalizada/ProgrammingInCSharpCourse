using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson12
{
    public class Interfaces
    {
        static void Main()
        {
            var config = File.ReadAllText(@"D:\MyDB\personFormat.txt");
            IPersonVisualizer personVisualizer;
            if (config == "1")
            {
                personVisualizer = new PersonVisualizer1();
            }
            else 
            {
                personVisualizer = new PersonVisualizer2();
            }

            var person = new Person(personVisualizer)
            {
                Id = 1,
                FirstName = "Samir",
                LastName = "Eliyev"
            };

            person.PrintPerson();

            Console.WriteLine();

            Console.ReadKey();
        }
    }

    public class Person
    {
        private readonly IPersonVisualizer _personVisualizer;
        public Person(IPersonVisualizer personVisualizer)
        {
            _personVisualizer = personVisualizer;
        }

        public string LastName { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }

        public void PrintPerson()
        {
            _personVisualizer.PrintPerson(this);
        }
    }

    public class PersonVisualizer1 : IPersonVisualizer
    {
        public void PrintPerson(Person person) 
        {
            Console.WriteLine($"{nameof(person.Id)}: {person.Id}");
            Console.WriteLine($"{nameof(person.FirstName)}: {person.FirstName}");
            Console.WriteLine($"{nameof(person.LastName)}: {person.LastName}");
        }
    }

    public class PersonVisualizer2 : IPersonVisualizer
    {
        public void PrintPerson(Person person)
        {
            Console.WriteLine($"Person {nameof(person.Id)} - {person.Id}");
            Console.WriteLine($"Person {nameof(person.FirstName)} - {person.FirstName}");
            Console.WriteLine($"Person {nameof(person.LastName)} - {person.LastName}");
        }
    }

    public interface IPersonVisualizer
    {
       void PrintPerson(Person person);
    }
}
