using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9.Models
{
    public class Animal
    {
        public string Name;
        public int Age;

        public Animal(string name)
        {
            Name = name;
        }

        public virtual void Move()
        {
            Console.WriteLine("Animal moving");
        }

        public void Eat()
        {
            Console.WriteLine("Animal Eating");
        }
    }
}
