using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson15
{
    class Program
    {
        public static void Main()
        { 
            DataCollection<int> dataCollection = new DataCollection<int>();
            dataCollection.Add(1);
            dataCollection.Add(2);

            Console.WriteLine(dataCollection.GetElementByIndex(0));
            Console.WriteLine(dataCollection.GetElementByIndex(1));

            int sum = 0;

            for (int i = 0; i < dataCollection.Count; i++)
            {
                sum += dataCollection.GetElementByIndex(i);
            }

            Console.WriteLine("Sum is: " + sum);

            foreach (var item in dataCollection)
            {
                Console.WriteLine();
            }

        }

        public static void Main3()
        {
            //HashSet
            HashSet<string> myHashSet1 = new HashSet<string>();
            myHashSet1.Add("salam");

            HashSet<string> myHashSet2 = new HashSet<string>();
            myHashSet2.Add("salam");
            myHashSet2.Add("salam1");

            myHashSet2.ExceptWith(myHashSet1);

            myHashSet2.IntersectWith(myHashSet1);

            myHashSet1.UnionWith(myHashSet2);

           

            Console.ReadKey();  
        }

        public static void Main2() 
        { 
            // QUEUE - FIFO
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            var queueCount = queue.Count;

            for (int i = 0; i < queueCount; i++)
            {
                Console.WriteLine("Next queue element is: " + queue.Dequeue());
            }

            Console.ReadKey();

            
            // STACK 
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            var stackCount = stack.Count;

            for (int i = 0; i < stackCount; i++)
            {
                Console.WriteLine("Next stack element is: " + stack.Pop());
            }

            Console.ReadKey();

        }

        static void Main1(string[] args)
        {
            //data structures

            // 1. Array
            int[] myIntNumbers = new int[100];
            myIntNumbers[10] = 5;

            // 2. ArrayList
            ArrayList myList = new ArrayList();
            myList.Add(15);
            myList.Add(16);
            myList.Add(17);

            int sum = 0;
            foreach (var item in myList)
            {
                sum += (int)item;
            }

            //List
            List<int> myIntList = new List<int>();
            myIntList.Add(10);
            myIntList.Add(11);
            //myIntList[2] = 12;

            //Dictinary
            Dictionary<string, int> regionPeopleCount = new Dictionary<string, int>();
            regionPeopleCount.Add("Baku", 5000);
            regionPeopleCount.Add("Sumgait", 3500);
            regionPeopleCount.Add("Ismayilli", 2000);
            regionPeopleCount.Add("Gadabay", 1000);

            foreach (var item in regionPeopleCount)
            {
                Console.WriteLine($"Region is {item.Key}, People Count is {item.Value}");
            }

            Dictionary<int, User> userDictonary = new Dictionary<int, User>();

            var user1 = new User
            {
                Id = 1,
                Name = "Samir",
                DateOfBirth = DateTime.Now.AddYears(-20),
            };

            userDictonary.Add(user1.Id, user1);

            var user2 = new User
            {
                Id = 2,
                Name = "Samira",
                DateOfBirth = DateTime.Now.AddYears(-15),
            };

            userDictonary.Add(user2.Id, user2);

            Console.WriteLine("Enter user id to find");

            var userId = int.Parse(Console.ReadLine());

            if (userDictonary.ContainsKey(userId))
            {
                var foundUser = userDictonary[userId];

                Console.WriteLine("Found is is \n" + foundUser);
            }
            else
            {
                Console.WriteLine("User with this id is not found");
            }


            Console.WriteLine(sum);

            var dataStoreForString = new DataStoreForString();
            dataStoreForString.Data = "Salam";

            var dataStoreForInt = new DataStoreForInt();
            dataStoreForInt.Data = 15;

            var dataStore = new DataStore<double>();
            dataStore.Data = 15.0f;

            var dataStore1 = new DataStore<char>();
            dataStore.Data = '\n';

            Console.WriteLine(dataStore.Data);

            Console.ReadKey();
        }
    }
}
