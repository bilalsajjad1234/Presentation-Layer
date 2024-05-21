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
    public partial class Modules : Form
    {

        BLL.Receptionist r = new Receptionist();

        public void loadForm(object Form)
        {
            if (this.panel2.Controls.Count > 0)
                this.panel2.Controls.RemoveAt(0);
            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(f);
            this.panel2.Tag = f;
            f.Show();
        }
        public Modules(string whoIs)
        {
            InitializeComponent();
            if(whoIs == "Customer")
            {
                button1.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
            }
            else if (whoIs == "Manager")
            {
                button3.Enabled = false;
                button4.Enabled = false;
                button6.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadForm(new addRoom());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadForm(new viewrooms());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadForm(new checkin());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name = user.Username;
            bool existence = r.getCustomerCheckinDetail(name);
            if (existence)
            {
                loadForm(new checkout());

            }
            else
            {
                MessageBox.Show("You need to Check in to check out");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string name = user.Username;
            bool existence = r.getCustomerCheckinDetail(name);
            if (existence)
            {
                loadForm(new orderfood());

            }
            else
            {
                MessageBox.Show("You need to Check in to order food");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var nf = new Login();
            nf.Show();
            this.Hide();
            user.Username = "";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Modules_Load(object sender, EventArgs e)
        {

            loadForm(new greet());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            loadForm(new addfood());
        }

        private void button9_Click(object sender, EventArgs e)
        {
            loadForm(new updatefood());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            loadForm(new deletefood());
        }
    }
}
