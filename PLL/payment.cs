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
    public partial class payment : Form
    {

        Pin p = new Pin();
        Customer c = new Customer();
        Receptionist r = new Receptionist();
        public payment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int pin = int.Parse(textBox1.Text);
            p.setPin(pin);
            //int a = p.pinNo;
            int pinn = p.getPin();
            bool isPin = c.getPin(pinn);
            if(isPin)
            {
                MessageBox.Show("transaction completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bool delete = r.delCus(user.Username);
                if(delete)
                {
                    user.Username = "";
                    var nf = new Login();
                    nf.Show();
                    this.Hide();
                }



            }
            else
            {
                MessageBox.Show("transaction failed. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
    }
}
