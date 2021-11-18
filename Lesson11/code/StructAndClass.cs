using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11
{
    public class StructAndClass
    {

        public static void Main2() 
        {
            var user1 = new User
            {
                Name = "Samir",
                Age = 50
            };

            User user3 = default;

            user3.Name = "Namiq";
            user3.Age = 50;

            Console.WriteLine($"User1's name is {user1.Name}");

            var user2 = new User();
            user2.CopyFromAnother(user1);
            user2.Name = "Ehmed";

            Console.WriteLine($"User1's name is {user1.Name}");
            Console.WriteLine($"User2's name is {user2.Name}");
            Console.WriteLine($"User3's name is {user3.Name} and age is {user3.Age}");
        }

        public static void Main3()
        {
            var user1 = new UserStruct
            {
                Name = "Samir",
                Age = 50
            };

            UserStruct user3 = default;

            user3.Name = "Namiq";
            user3.Age = 50;

            Console.WriteLine($"User1's name is {user1.Name}");

            var user2 = user1;
            user2.Name = "Ehmed";

            Console.WriteLine($"User1's name is {user1.Name}");
            Console.WriteLine($"User2's name is {user2.Name}");
            Console.WriteLine($"User3's name is {user3.Name} and age is {user3.Age}");
        }
    }

    public class User 
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public UserStruct MyUser;

        public void CopyFromAnother(User userToCopy) 
        { 
            Name = userToCopy.Name;
            Age = userToCopy.Age;
        }
    }

    public struct UserStruct
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
