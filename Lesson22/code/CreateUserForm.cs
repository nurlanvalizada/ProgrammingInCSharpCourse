using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Lesson22
{
    public partial class CreateUserForm : Form
    {
        private const string MyDbPath = @".\Students";

        public CreateUserForm()
        {
            if (!Directory.Exists(MyDbPath))
            {
                Directory.CreateDirectory(MyDbPath);
            }

            InitializeComponent();

            dataGridView1.Columns.Add("Id", "Id");
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Surname", "Surname");

            InitializeDataGridData();
        }

        private void InitializeDataGridData()
        {
            dataGridView1.Rows.Clear();

            var students = GetAllStudentsFromDb();

            foreach (var student in students)
            {
                dataGridView1.Rows.Add(student.Id, student.Name, student.Surname);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var directory = new DirectoryInfo(MyDbPath);
            var lastFile = directory.GetFiles().OrderByDescending(n=>n.Name).Select(f => f.Name).FirstOrDefault();

            int studentId;
            if (lastFile == null)
            {
                studentId = 1;
            }
            else
            {
                studentId = int.Parse(Path.GetFileNameWithoutExtension(lastFile));
                studentId++;
            }

            var fileText = $"Name: {textBox1.Text}\r\nSurname: {textBox2.Text}";
            var filePath = Path.Combine(MyDbPath, $"{studentId}.txt");
            File.WriteAllText(filePath, fileText);

            var dialogResult = MessageBox.Show("Student added.\r\nDo yu want to close this modal ?", null,
                MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);

            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                InitializeDataGridData();
            }
        }

        private void CreateUserForm_Load(object sender, EventArgs e)
        {

        }

        private List<Student> GetAllStudentsFromDb()
        {
            var result = new List<Student>();

            var directory = new DirectoryInfo(MyDbPath);
            foreach (var file in directory.GetFiles())
            {
                var fileLines = File.ReadAllLines(file.FullName);
                var student = new Student()
                {
                    Id = int.Parse(Path.GetFileNameWithoutExtension(file.Name)),
                    Name = fileLines[0].Split(":")[1].Trim(),
                    Surname = fileLines[1].Split(":")[1].Trim()
                };
                result.Add(student);
            }

            return result;
        }

        private List<Course> GetCoursesFromSqlDb(int studentId)
        {
            var result = new List<Course>();

            var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=StudentsDb;Trusted_Connection=True;TrustServerCertificate=True");
            var command = connection.CreateCommand();
            command.CommandText = @"select c.Name, c.CreationTime from dbo.tblStudent s
	                                join tblStudentCourse sc on sc.StudentId = s.Id
	                                join tblCourse c on c.Id = sc.CourseId
	                                where s.Id="+ studentId;
            connection.Open();

            var dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                var courseName = dataReader.GetString(dataReader.GetOrdinal("Name"));
                var creationTime = dataReader.GetDateTime(dataReader.GetOrdinal("CreationTime"));

                var course = new Course
                {
                    Name = courseName,
                    CreationTime = creationTime
                };

                result.Add(course);
            }

            connection.Close();

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var studentId = int.Parse(textBox3.Text);
            var courses = GetCoursesFromSqlDb(studentId);
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProfileImagePath { get; set; }
    }

    public class Course
    {
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }
    }

}
