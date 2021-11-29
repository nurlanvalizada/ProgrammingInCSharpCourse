using System;

namespace Lesson15
{
    public class User
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"Id is {Id}, Name is {Name}, DataOfBirth is {DateOfBirth.ToString("dd.mm.yyyy")}";
        }
    }
}
