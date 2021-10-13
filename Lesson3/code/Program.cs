using System;

namespace Lesson3
{
    class Program
    {
        static void Main()
        {
            //Operators 

            {
                //Arithmetic
                int a = 17;
                int b = 6;
                Console.WriteLine(a + b);
                Console.WriteLine(a - b);
                Console.WriteLine(a * b);
                Console.WriteLine(a / b);
                Console.WriteLine(a % b);
                Console.WriteLine(a++);
                Console.WriteLine(a);
                Console.WriteLine(b--);
                Console.WriteLine(b);

                Console.WriteLine("++a and --b");

                Console.WriteLine(++a);
                Console.WriteLine(--b);

                Console.WriteLine("Logical Operators");

                bool notResult1 = !(a > 6);

                bool notResult2 = a <= 6;

                // ==, !=, >, <, >=, <=

                var result = 6 == 7;
                var result2 = 100 != int.Parse(Console.ReadLine());

                // =,  +=, -=, *=, /= 

                int var4 = 4;
                var4 = a;
                var4 += 5; //var4 = var4 + 5;
                var4 -= 10;
            }

            // Bu kodu bu gun yazdim
            // sizeof(), typeof(), ?:, is, as 
            {
                var result4 = sizeof(int);
                int a = 5;
                var result5 = a.GetType() == typeof(int);
                a = null; // bu kod ona gore xeta verir ki, value tiplere null deyeri vere bilmirik

                int? y = null; // nullable int tipi, sadece int sozunun yanina ? isaresi qoyulur, int-den yegane ferqi elave olaraq null deyeri ala bilmesidir

                if (y.HasValue) // y-in deyeri varmi ?
                {
                    int z = y.Value; // eger varsa y-in deyerini goturub adi not nullable int z deyishenine menimsedirik
                }

                Type x = null; // reference tipdir ve null deyeri ala bilir

                bool result = a is int; // a int -dirmi ? cavab true ve ya false ola biler

                long? b = 15;
                int? c = b as int?; // as cevirme yerine yetirir

            }
        }


        /// <summary>
        /// Bu metodun icinde tip cevirmeleri istifade olunub
        /// </summary>
        /// <param name="a">Bu parametr iceride hec yerde istifade olunmur</param>
        static void Main3(int a)
        {

            int var1 = int.Parse("43645");
            var isItOK = int.TryParse(Console.ReadLine(), out int result);

            var var3 = Convert.ToBoolean(1);

            float var6 = 43534.67F;

            var stringResult = var6.ToString();

            object var4 = var3;


            if (isItOK)
            {
                var sum = 5 + result;
                Console.WriteLine(sum);
            }
            else
            {
            }


            var var2 = float.Parse("3456.67");

            Console.ReadLine();

        }

        static void Main2(string[] args)
        {
            //implicit ot auto conversion
            byte var1 = 15;

            short var2 = var1;

            int var3 = var2;

            double var4 = var3;


            //explicit or manual conversion
            int var6 = 300;
            byte var7 = (byte)var6;

            Console.WriteLine(var7);

            checked
            {
                int var8 = 50000;

                int var9 = int.Parse(Console.ReadLine());

                int var10 = var8 * var9;
            }

            var2 = (short)var3;

            float var5 = (float)var4;

            Console.WriteLine("Hello World!");
        }
    }
}
