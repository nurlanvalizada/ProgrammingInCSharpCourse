namespace Lesson20
{
    public partial class Form1 : Form
    {
        public delegate void MyDelegate(string message);

        public event MyDelegate MyEvent;

        public void Greet(string name)
        {
            MessageBox.Show("Hello " + name);
        }

        public void Greet1(string name)
        {
            MessageBox.Show("Hello1 " + name);
        }

        public void Greet2(string name)
        {
            MessageBox.Show("Hello2 " + name);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            MyDelegate dDelegate = Greet;
            dDelegate += new MyDelegate(Greet1);
            dDelegate += Greet2;
            dDelegate("Samir");



            //if (textBoxName.Text == "Samir")
            //{
            //    if (MyEvent != null)
            //    {
            //        MyEvent(textBoxPublishMessage.Text);
            //    }
            //}



            //MessageBox.Show($"{textBoxName.Text} {textBoxSurname.Text}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyEvent += MySubscriptionMethod1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyEvent += MySubscriptionMethod2;
        }

        public void MySubscriptionMethod1(string message)
        {
            MessageBox.Show("I have received the following message. Nothing to do \r\n" + message);
        }

        public void MySubscriptionMethod2(string message)
        {
            MessageBox.Show("I have received the following message. I am going to do it \r\n" + message);
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            labelLetterCount.Text = textBoxName.Text.Length.ToString();
        }
    }
}