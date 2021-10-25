using System;

namespace Lesson6
{
    class Program
    {
        static void Main()
        {
            (bool isOk, int result) = TryParse("436347");

            int a = 5;

            TryParse(Console.ReadLine(), out int var1);

            TryParse("657");

            IncreaseNumber(ref a);

            Console.WriteLine("Inside main method " + a);


            //method overloading
            MultiplyNumbers(5, 6, (int)7);

            MultiplyNumbers(1, 2);
        }

        static int MultiplyNumbers(double c, params int[] numbers)
        {
            return 0;
        }

        int MultiplyNumbers(int a, int b)
        {
            return a * b;
        }

        double MultiplyNumbers(double a, double b)
        {
            return a * b;
        }

        static int MultiplyNumbers(int a, int b, int c)
        {
            return a * b * c;
        }

        static double MultiplyNumbers(int a, int b, double c)
        {
            return a * b * c;
        }

        static bool TryParse(string s, out int result)
        {
            int actualNumber;
            try
            {
                actualNumber = int.Parse(s);
                result = actualNumber;
                return true;
            }
            catch (Exception e)
            {
                result = 0;
                return false;
            }
        }

        static (bool IsOk, int result) TryParse(string s)
        {
            try
            {
                var actualNumber = int.Parse(s);
                Console.WriteLine("Process completed successfully");
                return (true, actualNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine("Process completed successfully");
                return (false, 0);
            }
        }

        static int IncreaseNumber(ref int number)
        {
            ++number;

            Console.WriteLine("Inside method " + number);

            return number;
        }

        static void Main1(string[] args)
        {
            SumNumbers(new[] {1, 2, 3});

            SumNumbers(new[] { 1, 3 });

            SumNumbers(new[] { 1, 3 , 7, 90});

            SumNumbers();

            SumNumbers(90);

            SumNumbers(1, 2);

            SumNumbers(1, 2, 6);

            SumNumbers(9, 14, 67, 246, 79);

            PrintHelloWorld(29, "");


           var result = GetHelloWorldString("Nurlan", 29);
           //Console.WriteLine(result.ToUpper());
        }

        static int SumNumbers(params int[] numbers)
        {
            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }

            Console.WriteLine(sum);

            return sum;
        }

        static void PrintHelloWorld(int age, string name = "Nurlan", int experience = 0)
        {
            var result = $"Hello World {name}, your age is {age}";

            if (experience != 0)
            {
                result += $" and your experience is {experience}";
            }

            Console.WriteLine(result);
        }

        static string GetHelloWorldString(string name, int age)
        {
            return $"Hello World {name}, your age is {age}";
        }
    }
}
