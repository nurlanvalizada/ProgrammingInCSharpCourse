using System;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = "This is a test string content";

            int whitespaceCount = 0;
            for (int i = 0; i < test.Length; i++)
            {
                if (test[i] == ' ')
                {
                    whitespaceCount++;
                }
            }
           
            Console.WriteLine(whitespaceCount);
        }
    }
}
