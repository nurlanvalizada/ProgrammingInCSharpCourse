using System;
using System.Collections.Generic;

namespace Lesson16_exam1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


        }
    }

    public class Branch 
    { 
        public string Name { get; }
        public List<Branch> ChildBraches { get; set; }
        public Branch Parent { get; set; }
    }
}
