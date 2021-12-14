# Lesson17- Tasks

## Reading Materials
1. https://www.completecsharptutorial.com/basic/c-delegate-tutorial-with-easy-example.php
2. https://www.geeksforgeeks.org/c-sharp-delegates/
3. https://www.infoworld.com/article/2996770/how-to-work-with-delegates-in-csharp.html
   
## ToDo
1. We have User (Name, Surname, Age, Country) class and list of User objects \
   a) Write a method to generate about 10 user objects and return them as list.\
   b) Find all users that age is greater than 20 and print them as "Name Surname Age Country" format. ex: "Nurlan Valizada 28 Azerbaijan" \
   c) Remove all users that belongs to Turkey and Age is lower than 10
2. This is an example of some delegate usage
   ```C#
    using System;
    public class Application { 

        public delegate double NumericFunction(double d);   
        static double factor = 4.0;

        public static NumericFunction MakeMultiplier(double factor){
            return delegate(double input){return input * factor;};
        }

        public static void Main(){
            NumericFunction f = MakeMultiplier(3.0); 
            double input = 5.0;

            Console.WriteLine("factor = {0}", factor);
            Console.WriteLine("input = {0}", input);
            Console.WriteLine("f is a generated function which multiplies its input with factor");
            Console.WriteLine("f(input) = input * factor = {0}", f(input));
        }
    }
   ```
   Look at the results and try to figure out how it is working. We will discuss it on lesson :)