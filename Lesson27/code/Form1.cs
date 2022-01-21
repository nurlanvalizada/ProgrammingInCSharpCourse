using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson27
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Student> list = GetAllStudentsFromDb();
            dataGridView1.DataSource = list;
        }

        private List<Student> GetAllStudentsFromDb()
        {
            List<Student> list = new List<Student>();

            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=StudentsDb;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM [tblStudent]";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var student = new Student();
                    student.Id = dr.GetInt32("Id");
                    student.Name = dr.GetString("Name");
                    student.Surname = dr.GetString("Surname");
                    student.DateOfBirth = dr.GetDateTime("DateOfBirth");
                    student.Salary = dr.GetDouble("Salary");
                    student.Gender = dr.GetInt32("Gender");

                    list.Add(student);
                }
            }

            return list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoGender.Items.Add("Male");
            comboBoGender.Items.Add("Female");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlTransaction transaction = null;
            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=StudentsDb;Trusted_Connection=True;TrustServerCertificate=True"))
            {
                connection.Open();
                transaction= connection.BeginTransaction();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @$"insert tblStudent(Name, Surname, DateOfBirth, Salary, Gender)
                                    Values(@Name, @Surname, @DateOfBirth, @Salary, @Gender)";
                cmd.Transaction = transaction;

                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = @$"insert tblStudent1(Name, Surname, DateOfBirth, Salary, Gender)
                                    Values(@Name, @Surname, @DateOfBirth, @Salary, @Gender)";
                cmd2.Transaction = transaction;

                cmd.Parameters.Add(new SqlParameter("@Name", textBoxName.Text));
                cmd.Parameters.Add(new SqlParameter("@Surname", textBoxSurname.Text));
                cmd.Parameters.Add(new SqlParameter("@DateOfBirth", dateTimePicker.Value));
                cmd.Parameters.Add(new SqlParameter("@Salary", textBoxSalary.Text));
                cmd.Parameters.Add(new SqlParameter("@Gender", 1));

                try
                {
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }

                MessageBox.Show("Added successfully");

                List<Student> list = GetAllStudentsFromDb();
                dataGridView1.DataSource = list;
            }
        }
    }
}

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public double Salary { get; set; }
    public int Gender { get; set; }

}
}
