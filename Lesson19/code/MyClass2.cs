using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson19
{
    public partial class MyClass
    {
        public string Profession { get; set; }

        public void ShowSOmeData()
        {
            Console.WriteLine("My profession is:" + Profession);
        }

        public partial void DoItAgain()
        {
            Console.WriteLine("Do It Again");
        }
    }
}
