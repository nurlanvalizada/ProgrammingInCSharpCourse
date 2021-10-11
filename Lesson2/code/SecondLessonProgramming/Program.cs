using System;

namespace SecondLessonProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //integral numeric types
            byte var1 = 45;
            byte var2;

            var2 = 56; //byte.Parse(Console.ReadLine());

            int sum = var1 + var2;

            Console.WriteLine(sum);

            var intMin = int.MinValue;
            var intMax = int.MaxValue;

            //floating point numbers
            var var3 = 567.890F;

            double var4 = 45645.89D;

            double sum2 = var3 + var4;

            Console.WriteLine(sum2);

            //boolean types

            bool var5 = (6>5) || (7>5);

            Console.WriteLine(var5);

            // char type

            char var6 = 'A';
            char var7 = 'B';
            var concat = var6.ToString() + var7.ToString();

            Console.WriteLine(concat);

            var var8 = char.IsLetter(var6);
            var var9 = char.IsNumber(var7);

            // string
            string var10 = " asdflkndlknas ";
            var var11 = var10.ToUpper();

            Console.WriteLine(var11);

            Console.ReadLine();
        }
    }
}
