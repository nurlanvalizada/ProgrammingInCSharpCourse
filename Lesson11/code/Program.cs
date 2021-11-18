using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lesson11
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ApiUrl = "https://catfact.ninja/fact";

            bool isContinue;

            int? a = null;

            Nullable<int> b= null;

            HttpClient client = new HttpClient();

            Console.WriteLine("Starting to show facts \r\n \r\n");

            do
            {
                var result = client.GetStringAsync(ApiUrl).Result;

                var catfact = (CatFact)JsonConvert.DeserializeObject(result, typeof(CatFact));

                Console.WriteLine(catfact.Fact);

                Console.WriteLine();

                Console.WriteLine("Do you want to continue ? True/False");

                isContinue = Convert.ToBoolean(Console.ReadLine());
            } while (isContinue);
        }


        public static async Task Main3(string[] args) 
        {
            var user = new User
            {
                Name = "Babek",
                Age = 40,
                IsStudent = true,
                Parent = new Person
                {
                    Name = "Mamed",
                    DateOfBirth = new DateTime(1980, 9, 6)
                },
                SuccessYears = new int[] { 2000, 2005, 2010 },
                Children = new Person[]
                {
                    new Person
                    {
                        Name = "Semed", DateOfBirth = DateTime.Parse("2000-02-01")
                    },
                    new Person
                    {
                        Name = "Samire",
                        DateOfBirth = DateTime.Parse("2005-08-05")
                    }
                }
            };

            var jsonString = JsonConvert.SerializeObject(user, Formatting.Indented);
            Console.WriteLine(jsonString);

            Console.ReadKey();
        }

        public class User 
        {
            public string Name { get; set; }
            public bool IsStudent { get; set; }
            public int Age { get; set; }

            public Person Parent { get; set; }

            public Person[] Children { get; set; }

            public int[] SuccessYears { get; set; }
        }


        public class Person 
        {
            public string Name { get; set; }
            public DateTime DateOfBirth { get; set; }
        }


        public class CatFact 
        { 
            public string Fact { get; set; }
            public int Length { get; set; }
        }
    }
}
