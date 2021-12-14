using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson17
{
    class Program
    {
        //Func<int, bool> = delegate bool MyFuncDelegate(int element);

        delegate bool FilterMyListDelegate(int element, int comparingNumber);

        static bool CheckIfNumberIsDividibleToX(int element, int comparingNumber) 
        {
            if (element % comparingNumber == 0)
            {
                return true;
            }

            return false;
        }

        static bool CHeckIfNumberIsGreaterThanX(int element, int comparingNumber)
        {
            if (element > comparingNumber)
            {
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            var user = new User
            {
                Name = "Samir",
                Email = "s.imanov@gmail.com"
            };

            FilterMyListDelegate myDelegate = new FilterMyListDelegate(CHeckIfNumberIsGreaterThanX);
            Console.WriteLine(myDelegate(12, 10));

            //Console.WriteLine(user);

            var list = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16
            };

            var filteredList = list.Where(item => item > 2); //select * from Numbers where NUmber > 2

            var filteredList = list.Where(item =>
            {
                if (Math.Pow(2, x) == item)
                    return true;

                return false;
            });

            var newList = GetElementsFiltered(list, 11, CHeckIfNumberIsGreaterThanX);

            var newList1 = GetElementsFiltered(list, 5, delegate (int item, int comparingNumber) 
            {
                return item < comparingNumber;
            });

            var newList2 = GetElementsFiltered(list, 3, (int item, int comparingNumber) =>
            {
                return item < comparingNumber;
            });

            var newList3 = GetElementsFiltered(list, 3, (item, comparingNumber) => item < comparingNumber);

            // Console.WriteLine(newList);

            Console.WriteLine(GetListAsString(GetElementsFiltered(list, 3, CheckIfNumberIsDividibleToX)));

            Console.ReadKey();
        }

        static string GetListAsString(List<int> list) 
        {
            var str = "";
            foreach (var item in list)
            {
                str += item + ",";
            }

            str = str.TrimEnd(',');
            str.Substring(0, str.Length - 1);

            if (str.EndsWith(","))
            {
                //str = str.Substring(0, str.Length - 1);
                //str = str.Remove(str.Length - 1, 1);
            }

            return str;
        }

        static List<int> GetElementsFiltered(List<int> list, int comparingNumber, FilterMyListDelegate filterMyListDelegate)
        {
            var subList = new List<int>();
            foreach (var item in list)
            {
                if (filterMyListDelegate(item, comparingNumber))
                {
                    subList.Add(item);
                }
            }

            return subList;
        }
    }

    public class User 
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return Name + " " + Email;
        }
    }
}

//static List<int> GetElementsMoreThanANUmber(List<int> list, int comparingNumber)
//{
//    var subList = new List<int>();
//    foreach (var item in list)
//    {
//        if (item > comparingNumber)
//        {
//            subList.Add(item);
//        }
//    }

//    return subList;
//}

//static List<int> GetElementsDivideByANumber(List<int> list, int comparingNumber)
//{
//    var subList = new List<int>();
//    foreach (var item in list)
//    {
//        if (item % comparingNumber == 0)
//        {
//            subList.Add(item);
//        }

//        //subList.Where()
//    }

//    return subList;
//}
