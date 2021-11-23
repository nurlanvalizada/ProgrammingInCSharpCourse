using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;

namespace Lesson13
{
    public class Country
    {
        public string country_id { get; set; }
        public double probability { get; set; }
    }

    public class JsonResult
    {
        public string name { get; set; }
        public Country[] country { get; set; }
    }

    class Program
    {
        static void Main() 
        {
            var name = Console.ReadLine();
            var apiUrl = $"https://api.nationalize.io/?name={name}";

            var httpClient = new HttpClient();
            var stringRsult = httpClient.GetStringAsync(apiUrl).Result;

            var result = JsonConvert.DeserializeObject<JsonResult>(stringRsult);

            Console.WriteLine($"Name is {result.name}");

            foreach (var item in result.country)
            {
                Console.WriteLine($"CountryName is {item.country_id}, probability is {item.probability}");
            }

            Console.ReadKey();
        }

        static void Main3() 
        {
            var smsService = new SMSService2();
            var userManager = new UserManager(smsService);

            userManager.RegisterNewUser(new User
            {
                Id = 1,
                Name = "Samir"
            });

            userManager.RegisterNewUser(new User
            {
                Id = 2,
                Name = "Nigar"
            });

            userManager.EditUser(new User
            {
                Id = 1,
                Name = "Samir1"
            });

            Console.ReadKey();
        }
        
        static void Main2(string[] args)
        {
            Dog  dog = new Dog();
            dog.Grow();

            Console.WriteLine("Hello World!");
        }
    }

    public abstract class Animal 
    {
        public abstract int LegCount { get; set; }

        private string _color { get; set; }

        public void SetColor(string color) 
        {
            _color = color;
        }

        public void Go()
        {
            Console.WriteLine("Animal is moving");
        }

        public abstract void MakeSound();
    }

    public class Dog : Animal, ICreature, ICreature1
    {
        private int _legCount;
        public override int LegCount
        {
            get
            {
                return _legCount;
            }
            set
            {
               
            }
        }

        public string Name { get; set; }

        public void Grow()
        {
            Console.WriteLine("I'm growing");
        }

        public override void MakeSound()
        {
            Console.WriteLine("hav-hav");
        }
    }

    public interface ICreature
    {
        string Name { get; set; }

        void Grow();
    }

    public interface ICreature1
    {
        void Grow();
    }
}
