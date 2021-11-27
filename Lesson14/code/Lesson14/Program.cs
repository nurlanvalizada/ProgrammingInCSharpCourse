using System;
using System.IO;

namespace Lesson14
{
    class Program
    {
        const string LogFilePath = "D:\\Logs\\logs.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Please enter  2 numbers");

            try
            {
                // int.Parse(Console.ReadLine());


                int number1, number2, result = 0;
                try
                {
                    number1 = int.Parse(Console.ReadLine());
                    number2 = int.Parse(Console.ReadLine());

                    string str = null;
                    //str.Trim();

                    if (number2 == 0)
                    {
                        Console.WriteLine("Second number should not be 0");
                        return;
                    }

                    result = number1 / number2;

                }
                catch (DivideByZeroException exc)
                {
                    Console.WriteLine("Second number should not be 0");
                    File.AppendAllText(LogFilePath, DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff") + '\n' + exc.ToString() + "\n \n");
                    //throw new OperationRestrictedException("This is not allowed", exc, "Divide");
                }
                catch (FormatException exc)
                {
                    Console.WriteLine("Please enter correct number");
                    File.AppendAllText(LogFilePath, DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff") + '\n' + exc.ToString() + "\n \n");
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Something unexpected occured");
                    File.AppendAllText(LogFilePath, DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff") + '\n' + exc.ToString() + "\n \n");
                    //throw;
                }
                finally
                {
                    Console.WriteLine("This text will be always shown");
                }

                Console.WriteLine(result);
                Console.WriteLine("Next Statement");
            }
            catch(Exception exc)
            {
                throw; new ArgumentNullException();
            }
        }
    }
}
