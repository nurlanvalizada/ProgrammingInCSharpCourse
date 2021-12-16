# Lesson17- Tasks

## Reading Materials
1. https://newbedev.com/func-vs-action-vs-predicate
2. https://canro91.github.io/2019/03/22/WhatTheFuncAction/
3. https://www.geeksforgeeks.org/c-sharp-indexers/
   
## ToDo
1. Write WhereMy and FirstOrDefaultMy extension methodd for List<T> class that works exatly the same as original Where and FirstOrDefault ones.
2. This is an example of some delegate usage
   ```C#
    using System;
 
    namespace DelegatesAndEvents
    {
        public class Program
        {
            public static void Main()
            {
                DelegateExercises delegateExercises = new DelegateExercises();
                delegateExercises.Method3();
                Console.ReadLine();
            }
        }
        
        public delegate void MyDelegate(ref int intValue);
        
        public class DelegateExercises
        {
            void Method1(ref int intValue)
            {
                intValue = intValue + 5;
                System.Console.WriteLine("Method1 " + intValue);
            }
        
            public void Method3()
            {
                MyDelegate myDelegate = new MyDelegate(Method1);
                MyDelegate myDelegate1 = new MyDelegate(Method1);
                MyDelegate myDelegate2 = myDelegate + myDelegate1;
                int intParameter = 5;
                myDelegate2(ref intParameter);
            }
        }
    }
   ```
   Look at the results and try to figure out how it is working. We will discuss it on lesson :)
3.  We have the following class **Guest** and container **Table** classes
    ```C#
    public class Guest
    {
        public string Name { get; set; }
    }
  
    public class Table
    {
        public Table()
        {
            Guests = new List<Guest>()
            {
                new Guest(){Name = "John"}
                , new Guest(){Name = "Charlie"}
                , new Guest() {Name = "Jill"}
                , new Guest(){Name = "Jane"}
                , new Guest(){Name = "Martin"}
                , new Guest(){Name = "Ann"}
                , new Guest(){Name = "Eve"}
            };
        }

        private List<Guest> Guests { get; set; }
    }
    ```
    Do the followings: \
    a) Write an indexer which accept int parameter and returns related Guest object \
    b) Write and indexer which accept string parameter and returns the first Guest object which Name is equal to a given parameter