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
    public partial class Login : Form
    {
        BLL.Customer c = new Customer();

        
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            user.Username = username;
            string getString = c.whichUserType(username, password);

            if (string.IsNullOrEmpty(getString))
            {
                MessageBox.Show("Invalid!");

            }
            else if (getString == "Customer")
            {
               // button1.Enabled = false;

                var nf = new Modules(getString);
                nf.Show();
                this.Hide();
                MessageBox.Show(user.Username);
            }
            else if (getString == "Manager")
            {
                var nf = new Modules(getString);
                nf.Show();
                this.Hide();
                MessageBox.Show("its Manager");
            }
            else
            {
                MessageBox.Show("sorry data not found");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            var nf = new Register();
            nf.Show();
            this.Hide();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }
    }
}
