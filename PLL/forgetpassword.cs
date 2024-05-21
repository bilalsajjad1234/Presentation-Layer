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
    public partial class forgetpassword : Form
    {

        Customer c = new Customer();

        public forgetpassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string pass = textBox2.Text;

            bool passed = c.updatePass(name, pass);
            if (passed)
            {
                MessageBox.Show("Password Updated Enjoy!");
                var nf = new UserForm();
                nf.Show();
                this.Hide();

            }
           
        }
    }
}
