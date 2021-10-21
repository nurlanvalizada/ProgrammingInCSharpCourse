using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program2
    {
        static void Main()
        {
            var random = new Random();
            var magicNumber = random.Next(1, 101);

            var input = 0;

            Console.WriteLine("Enter value to find magic number: ");

            while (input != magicNumber)
            { 
                input = int.Parse(Console.ReadLine());

                if (input > magicNumber)
                {
                    Console.WriteLine("Enter small number");
                }
                else
                {
                    Console.WriteLine("Enter big number");
                }
            }

            Console.WriteLine($"Your magic number is {input}");
        }

        public static void DoSomething()
        {
            Console.WriteLine("Doing something");
        }
    }
}
