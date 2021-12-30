using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson22
{
    public partial class CreateUserForm : Form
    {
        private const string MyDbPath = @"D:\MyDB\Students";

        public CreateUserForm()
        {
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
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProfileImagePath { get; set; }
    }

}
