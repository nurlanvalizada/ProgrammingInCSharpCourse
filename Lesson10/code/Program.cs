using System;
using Lesson9.Models;
using Helpers;
using System.Linq;

namespace Lesson9
{
    class Program
    {
        static void Main() 
        {
            var student = new Student();
            byte iq = byte.Parse(Console.ReadLine());
            //student.SetIq(iq);

            student.IQ = 100;
            student.Score = 5;

            Console.WriteLine(student.IQ);

             var x = Math.Abs(-10);

            Console.ReadKey();
        }

        static void Main1(string[] args)
        {
            //Animal animal = new Dog("Coban iti", "tehlukeli ses");
            //animal.Move();

            Animal[] animals = new Animal[3];
            animals[0] = new Animal("Cat");
            animals[1] = new Dog("Reks", "hav-hav");
            animals[2] = new CobanIti("Toplan", "hm-ham", "test");

            ProcessAnimals(animals);

            foreach (Animal animal1 in animals)
            {
                animal1.Move();
            }

            //Dog d = new Animal("");

            Dog dog = new Dog("Toplan", "Hav-hav");
            dog.SomeProperty = "";
            dog.Move();

            Animal a = new Animal("Snake");

            Console.WriteLine();

            Student s = new Student();
            s.Name = "Ahmed";


            Models.User user = new Models.User();
            Console.WriteLine("Hello World!");
        }

        static void ProcessAnimals(Animal[] animals)
        {
            foreach (Animal animal in animals)
            {
                var dog = animal as Dog;
                if (dog != null)
                {
                    dog.MoveForDog();
                    dog.Eat();
                }

                var dogCount = animals.Where(a => a is Dog).Count();

                if (animal is Dog)
                {
                    var dog1 = ((Dog)animal);

                    ((Dog)animal).MoveForDog();

                    ((Dog)animal).Eat();
                    Console.WriteLine("Animal is dog");
                }
            }
        }
    }
}
