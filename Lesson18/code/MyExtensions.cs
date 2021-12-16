using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson18
{
    public static class MyExtensions
    {
        public static void PrintUserDetails(this User user)
        {
            Console.WriteLine($"Name: {user.Name}, DateOfBirth: {user.DateOfBirth}");
        }

        public static List<User> GetAllUsersGreaterThan2000(this List<User> users)
        {
            return users.Where(u => u.DateOfBirth.Year > 2000).ToList();
        }
    }
}
