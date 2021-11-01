using System;

namespace Lesson8
{
    class Program
    {
        public static void Main(string[] args)
        {
            Program p = new Program();
            p.SumNumbers(5, 6);

            Console.WriteLine(p.SumNumbers(5, 6));

            int a = 5;
            User.MaxUserNameLetterCount = 10;

            User u = new User("Ilkin", "Shahaliyev", 2002);
            u.PrintUserToConsole();


            User u2 = new User();

            User.MaxUserNameLetterCount = 1000;

            u2.name = "Kamran";
            u2.surname = "Shahaliyev";
            u2.birthdate = 1994;
            u2.PrintUserToConsole();

            u.PrintUserToConsole();

            User u3 = new User(2005);

            User[] userArray = new User[100];

            foreach (var user in userArray)
            {
                
            }

            u.PrintUserToConsole();

            Console.WriteLine(u.GetAgeAfterXYeaars(10));
        }

        public int SumNumbers(int a, int b)
        {
            return a + b;
        }


    }

    class User 
    {
        public string name;
        public string surname;
        public int birthdate;

        public static int MaxUserNameLetterCount;

        public User()
        {
            Program.Main(new []{""});
            Program p = new Program();
            p.SumNumbers(7, 8);
        }

        public User(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
        }

        public User(int birthdate)
        {
            this.birthdate = birthdate;
        }

        public User(string name, string surname, int birthdate)
        {
            this.name = name;
            this.surname = surname;
            this.birthdate = birthdate;
        }

        static void ChangeUserMaxLetterCount(int newCount)
        {
            MaxUserNameLetterCount = newCount;
        }

        public string GetFullName() 
        {
            return name + " " + surname;
        }

        public int GetAge() 
        {
            return DateTime.Now.Year - birthdate;
        }

        public void PrintUserToConsole()
        {
            var str = $"My name is {name} {surname}, and my birhdate is {birthdate} and my maxNameLetterCount is {MaxUserNameLetterCount}";
            Console.WriteLine(str);
        }

        public int GetAgeAfterXYeaars(int year) 
        {
            return GetAge() + year;
        }

        ~User()
        {

        }
    }
}
