# Lesson14 - Tasks

## Reading Materials
1. https://www.geeksforgeeks.org/exception-handling-in-c-sharp/
2. https://stackify.com/csharp-exception-handling-best-practices/
3. https://csharp.net-tutorials.com/advanced/exceptions/
   
## ToDo
1. This program is throwing exception IndexOutOfRangeException. Using your skills fix this problem using try catch block.
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace Null_Reference_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] list = new string[5];
            list[0] = "Sunday";
            list[1] = "Monday";
            list[2] = "Tuesday";
            list[3] = "Wednesday";
            list[4] = "Thursday";
 
            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine(list[i].ToString());
            }
            Console.ReadLine();
 
        }
    }
}
```
2.  The given program is throwing OverflowException. Fix it.
```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace Overflow_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            byte result;
 
            num1 = 30;
            num2 = 60;
            result = Convert.ToByte(num1 * num2);
            Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
            Console.ReadLine();
        }
    }
}
```
3. 	The static methods in the static class **System.Convert** are able to convert values of one type to values of another type.

    Consult the documentation of** System.Convert.ToDouble**. There are several overloads of this method. Which exceptions can occur by converting a string to a double?

    Write a program which triggers these **exceptions**.

    Finally, supply handlers of the exceptions. The handlers should report the problem on standard output, rethrow the exception, and then continue.

4. Write a program that checks if an **n** number is even, and if it is, prints it on the screen. If an invalid number is entered, the program should display a notification that the entered input is not a valid number and the entering of the number has to be done again.