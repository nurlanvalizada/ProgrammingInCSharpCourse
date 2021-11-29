# Lesson15- Tasks

## Reading Materials
1. https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/types/generics
2. https://www.geeksforgeeks.org/c-sharp-generics-introduction/
3. https://dev.to/adavidoaiei/fundamental-data-structures-and-algorithms-in-c-4ocf
4. https://stackoverflow.com/questions/128636/net-data-structures-arraylist-list-hashtable-dictionary-sortedlist-sorted
   
## ToDo
1. Create new MyList<T> class from scratch, which work mostly as List<T>. It hsould have  **void Add(T item), void Remove(T item), void Clear(), bool Contains(T item)** methods and **Count** poperty.
   We also can iterate this collection via **foreach**

2. Please remove the item with the key 'Han' from the dictionary.
    ```C#
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, bool> characters = new Dictionary<string, bool>()
            {
                { "Luke", true },
                { "Han", false },
                { "Chewbacca", false }
            };

            // Your code here.
        }
    }
    ```
3. Please add a new value, the key of which is your name, and the value of which is your age. Do this using the Add method.

    Next, add another value to the dictionary using the index notation. This time, use a different name and a different age.

    Lastly, read the first item you added to the dictionary, and write it to the console using Console.WriteLine.
   ```C#
   using System;
   using System.Collections.Generic;

   public class Program
   {
       public static void Main()
       {
           Dictionary<string, int> people = new Dictionary<string, int>();

           // Your code here.
       }
   }
   ```
4. Complete the TODO section of below code
    ```C#
    public static List<string> ProcessToKill(List<string> process)
    {
        // Create list of string with initial size to 3.
        List<string> processToKill = new List<string>(3);

        // Show capacity ; here : 3.
        Console.WriteLine(string.Format("Capacity {0}", processToKill.Capacity));

        // Show number of items ; here : 0.
        Console.WriteLine(string.Format("Count {0}", processToKill.Count));

        /// TODO: 
        /// Add items from process to processToKill list 
        /// Process equals "Explorer.exe" don't be added, ignore it

        foreach (var p in processToKill)
        {
            Console.WriteLine(p);
        }           

        return processToKill;
    }
    ```