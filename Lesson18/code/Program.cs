using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//using Lesson18.Extensions;

namespace Lesson18
{
    public class Program
    {
        public delegate void DoSomething();

        public static void PrintHelloToScreen()
        {
            Console.WriteLine("Hello");
        }

        public static void WriteHelloToFile()
        {
            File.WriteAllText("myfile.txt", "Hello");
            Console.WriteLine("File writing success");
        }

        static void Main()
        {
            UserManager userManager = new UserManager();
            userManager.AddUser(new User("Ehmed", DateTime.Now, 1));
            userManager[2, 0] = null;
            //var user = userManager.GetAll()[1];
        }

        static void Main2(string[] args)
        {
            var user = new User("Hasim", new DateTime(1999, 1, 1));
            //MyExtensions.PrintUserDetails(user);
            user.PrintUserDetails();


            var users = InitializeUserList();
            users[1] = null;
            users.GetAllUsersGreaterThan2000();
            var filteredList = users.Where(GetReal);
            var filteredList1 = users.Where(user => user.DateOfBirth > DateTime.Today.AddYears(-18));

            DoSomething myDelegate = PrintHelloToScreen;
            myDelegate = WriteHelloToFile;
            myDelegate();

            Console.ReadKey();

            Func<User, bool> myFuncDelegate = (u) => u.DateOfBirth > new DateTime(2000, 1, 1);
            var isTrue = myFuncDelegate(new User("Hasim", new DateTime(1999, 1, 1)));

            Action myAction = () =>
            {
                Console.WriteLine("DO Something");
            };

            Action<string, string> greetSomeOne = (name, surname) =>
            {
                Console.WriteLine($"Hello {name} {surname}");
            };

            greetSomeOne("Nurlan", "Valizada");


            myAction();
        }

        public static List<User> InitializeUserList()
        {
            return new List<User>()
            {
                new User("Samir", DateTime.Parse("2001-10-12")),
                new User("Ehmed", DateTime.Parse("2002-10-12")),
                new User("Gulnar", DateTime.Parse("2003-10-12")),
                new User("Aysel", DateTime.Parse("2004-10-12")),
                new User("Namiq", DateTime.Parse("2005-10-12"))
            };
        }

        public static void Do()
        {
        }

        public static void Do<T>(T arg1)
        {
        }

        public static void Do<T1, T2>(T1 arg1, T2 arg2)
        {
        }

        // ...

        public static TResult Get<TResult>()
        {
            return default;
        }

        public static TResult Get<T1, TResult>(T1 arg1)
        {
            return default;
        }

        public static bool GetPredicate<T1>(T1 arg1)
        {
            return default;
        }

        public static bool GetReal(User user)
        {
            return user.DateOfBirth > DateTime.Today.AddYears(-18);
        }

        public static TResult Get<T1, T2, TResult>(T1 arg1, T2 arg2)
        {
            return default;
        }

        // ...
    }

    public class User
    {
        public User(string name, DateTime dateOfBirth, int id = 0)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

}
