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
    public partial class deletefood : Form
    {

        Receptionist r = new Receptionist();
        public deletefood()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {

                MessageBox.Show("Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                int id = int.Parse(textBox1.Text);
                bool delete = r.delFood(id);
                if(delete)
                {
                    MessageBox.Show("Done Brother.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
    }
}
