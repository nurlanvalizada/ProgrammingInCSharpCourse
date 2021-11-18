using System;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Lesson12
{
    class Program
    {
        const string MyDbDirectory = @"D:\MyDB";
        const string DateFormat = "yyyy-MM-dd";

        static void Main1(string[] args)
        {
            Console.WriteLine("What do you want to do ?\n 1- Create Student\n 2-See all registered students");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    var student = CreateStudent();
                    RegisterStudentInDb(student);
                    break;
                case 2:
                    var students = GetStudents();
                    PrintStudents(students);
                    break;
                default:
                    throw new ArgumentException(nameof(option));
            }

            Console.ReadKey();
        }

        public static Student CreateStudent() 
        {
            Console.WriteLine("Registering a student ...");
            Console.WriteLine();

            var student = new Student();

            Console.WriteLine("Name:");
            student.Name = Console.ReadLine();

            Console.WriteLine("Surname:");
            student.Surname = Console.ReadLine();

            Console.WriteLine($"DateOfBirth ({DateFormat}):");
            student.DateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.WriteLine($"Id:");
            student.Id = int.Parse(Console.ReadLine());

            return student;
        }

        public static void RegisterStudentInDb(Student student) 
        {
            var file = Path.Combine(MyDbDirectory, student.Id + ".txt");
            if (File.Exists(file))
            {
                Console.WriteLine("This student has already been registered");
            }
            else
            {
                //File.Create(file);
                var fileText = $"Name: {student.Name}\n" +
                    $"Surname: {student.Surname}\n" +
                    $"DateOfBirth: {student.DateOfBirth.ToString(DateFormat)}";

                File.WriteAllText(file, fileText);

                Console.WriteLine("Student was successfully registed");
            }
        }

        public static Student[] GetStudents() 
        {
            var directory = new DirectoryInfo(MyDbDirectory);
            var files = directory.GetFiles();

            var students = new Student[100];

            var i = 0;

            foreach (var file in files)
            {
                var fileLines = File.ReadAllLines(file.FullName);
                var student = new Student();
                student.Name = fileLines[0].Split(':')[1].Trim();
                student.Surname = fileLines[1].Split(':')[1].Trim();
                student.DateOfBirth = DateTime.Parse(fileLines[2].Split(':')[1].Trim());

                students[i] = student;
                i++;
            }

            return students;
        }

        public static void PrintStudents(Student[] students) 
        {
            foreach (var student in students)
            {
                if (student is null)
                {
                    break;
                }

                PrintStudent(student);

                Console.WriteLine();
                Console.WriteLine("---------------------");
                Console.WriteLine();
            }
        }

        public static void PrintStudent(Student student) 
        {
            Console.WriteLine($"{nameof(student.Name)}: {student.Name}");
            Console.WriteLine($"{nameof(student.Surname)}: {student.Surname}");
            Console.WriteLine($"{nameof(student.DateOfBirth)}: {student.DateOfBirth.ToString(DateFormat)}");
        }
    }

    public class Student 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
