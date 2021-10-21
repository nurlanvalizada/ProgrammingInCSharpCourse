using System;
using System.Collections;
using System.IO;

namespace Lesson5
{
    class Program1
    {
        static void Main5()
        {
            Program2.DoSomething();

            int[] myArray = {1,5,7,9,10};

            ArrayList list = Program1.CreateAndInitializeArrayList(30, "Bu gun", DateTime.Now);

            PrintArrayList(list);

            int sumWithFor = 0;
            for (int i = 0; i < myArray.Length; i++)
            {
                sumWithFor += myArray[i];
            }

            Console.WriteLine($"Sum with for operator is {sumWithFor}");

            int sumWithForeach = 0;
            foreach (var item in myArray)
            {
                sumWithForeach += item;
            }

            Console.WriteLine($"Sum with foreach operator is {sumWithForeach}");
        }

        static void Main4()
        {
            bool isContinue = false;
            do
            {
                Console.WriteLine("Do you want to continue ? Yes/No");
                string userAnswer = Console.ReadLine();
                isContinue = userAnswer.ToLower() == "yes";

                Console.WriteLine(isContinue ? "you want to continue" : "you choose to exit");
            } 
            while (isContinue);
        }

        static void Main3()
        {
            Console.WriteLine("Do you want to continue ? Yes/No");

            while (true)
            {
                string userAnswer = Console.ReadLine();
                bool isContinue = userAnswer.ToLower() == "yes";

                if (isContinue)
                {
                    Console.WriteLine("you want to continue");
                    continue;
                }

                Console.WriteLine("you choose to exit");
                break;
            }


            int i = 0;
            while (i < 100)
            {
                Console.WriteLine(i);
                i++;
            }

            Console.ReadLine();
        }

        static void Main2(string[] args)
        {
            //loops
            for (int i = 1; i <= 100; i+=2)
            {
                if (i > 70)
                {
                    break;
                }

                if (i / 10 >= 1 && i % 10 == 0)
                {
                    continue;
                }

                Console.WriteLine(i);
            }

            Console.WriteLine("First loop part seperator");

            for (int i = 100; i>0; i--)
            {
                Console.WriteLine(i);
            }
        }

        static ArrayList CreateAndInitializeArrayList(int itemCount, string text, DateTime date)
        {
            ArrayList list = new ArrayList();

            for (int i = 0; i < itemCount; i++)
            {
                list.Add(i);
            }

            int var1 = Convert.ToInt32(list[1]);

            list.Add(1);
            list.Add(text);
            list.Add(date);

            return list;
        }

        static void PrintArrayList(ArrayList list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            return;

            int a = 5;
        }
    }
}
