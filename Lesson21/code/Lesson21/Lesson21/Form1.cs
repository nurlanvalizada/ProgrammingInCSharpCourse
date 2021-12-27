using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Lesson21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = 1;

            listViewStudent.Columns.Clear();
            listViewStudent.Items.Clear();
            listViewStudent.Columns.Add("#", "#");
            listViewStudent.Columns.Add("Id", "Id");
            listViewStudent.Columns.Add("Name", "Name");

            var listViewItem = new ListViewItem($"{index}");
            var subItem1 = new ListViewItem.ListViewSubItem(listViewItem, "1");
            var subItem2 = new ListViewItem.ListViewSubItem(listViewItem, "Samir");

            index++;

            var listViewItem1 = new ListViewItem($"{index}");
            var subItem3 = new ListViewItem.ListViewSubItem(listViewItem, "5");
            var subItem4 = new ListViewItem.ListViewSubItem(listViewItem, "Ayten");

            listViewItem.SubItems.Add(subItem1);
            listViewItem.SubItems.Add(subItem2);

            listViewStudent.Items.Add(listViewItem);

            //listViewStudent.Items.Add("Test1");
            //listViewStudent.Items.Add("Test2");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Application initialized");
        }

        private void Button2_Clieck(object sender, EventArgs e)
        {
            button2.Font = new Font(new FontFamily("Arial"), 8);
        }

        private void button2_FontChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Font changed");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Font = new Font(new FontFamily("Arial"), 9);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Size = new Size(100, 35);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Size = new Size(94, 29);
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            var random = new Random();
            var x = this.Location.X;
            //var y = this.en;
            button4.Location = new Point(random.Next(0, 1));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();

            pictureBox1.Image = Image.FromFile(this.openFileDialog1.FileName);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Thread.Sleep(5000);
            colorDialog1.ShowDialog();
            button6.BackColor = colorDialog1.Color;
            progressBar1.Value += 10;
        }
    }

    public class User
    {
        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
