using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Lesson19
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // async programming - 10 second
            File.WriteAllText("mytext.txt", "Test");

            //10 second
            var task1 = File.WriteAllTextAsync("mytextasync.txt", "Test");

            // multithreading
            Thread method2RunnerThread = new Thread(Method2);
            method2RunnerThread.Start();

            Method1();


            await task1;


            //var currentThread = Thread.CurrentThread;
            //Console.WriteLine($"Name: {currentThread.Name}");

            //var dateTime = DateTime.Now;

            //Console.WriteLine("en culture:" + dateTime);

            //currentThread.Name = "MainThread";
            //currentThread.CurrentCulture = new CultureInfo("az");
            //currentThread.CurrentUICulture = new CultureInfo("az");

            //Console.WriteLine($"Name: {currentThread.Name}");
            //Console.WriteLine("az culture:" + dateTime);

            Console.ReadKey();

        }

        public static void Method1()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Method1 - {i}");
                Thread.Sleep(10);
            }
        }

        public static void Method2()
        {
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"Method2 - {i}");
                Thread.Sleep(10);
            }
        }

        static void Main1(string[] args)
        {
            // partial class and methods
            var myClass = new MyClass("Programmer");
            myClass.DoIt();
            myClass.DoItAgain();

            Console.ReadKey();
        }
    }
}
