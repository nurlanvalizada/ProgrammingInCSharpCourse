using System;
using Lesson9.Models;
using Helpers;

namespace Lesson9
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.Name = "Ahmed";

            Animal animal = new Dog("Coban iti", "tehlukeli ses");
            animal.Move();

            //Dog d = new Animal("");

            Dog dog = new Dog("Toplan", "Hav-hav");
            dog.SomeProperty = "";
            dog.Move();

            Animal a = new Animal("Snake");

            Console.WriteLine();



            Models.User user = new Models.User();
            Console.WriteLine("Hello World!");
        }
    }
}
