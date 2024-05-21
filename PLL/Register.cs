using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace PLL
{
    public partial class Register : Form
    {
        BLL.Customer c = new Customer();
        public Register()
        {
            InitializeComponent();
        }
        private int GenerateRandomId()
        {
            
            Random random = new Random();
            int randomId = random.Next(100, 300);
            return randomId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int randomId = GenerateRandomId();


            textBox1.Text = randomId.ToString();

            string name = textBox2.Text;
            string uname = textBox3.Text;
            string pass = textBox4.Text;
            string contact = textBox5.Text;
            bool isInsert = c.thisCustomerAdded(randomId, name, uname, pass, contact);
            if (isInsert)
            {
                MessageBox.Show("User successfully created");
                timer1.Start();
            }
            else
            {
                MessageBox.Show("Error signing in");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("Success Brother");
            var md = new UserForm();
            md.Show();
            this.Hide();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
        }
    }
}
