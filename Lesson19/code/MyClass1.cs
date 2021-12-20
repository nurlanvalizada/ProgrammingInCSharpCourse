using System;

namespace Lesson19
{
    public partial class MyClass
    {
        public MyClass(string profession)
        {
            Profession = profession;
        }

        public void DoIt()
        {
            Console.WriteLine("Doing");
        }

        public partial void DoItAgain();
    }
}