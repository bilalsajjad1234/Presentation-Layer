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
    public partial class addfood : Form
    {
        public addfood()
        {
            InitializeComponent();
        }

        Receptionist r = new Receptionist();

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))

            {
                  MessageBox.Show("Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                

            }
            else
            {
                int id = int.Parse(textBox1.Text);
                string name = textBox2.Text.ToString();
                int price = int.Parse(textBox3.Text);

                bool add = r.addFood(id, name, price);
                if(add)
                {
                    MessageBox.Show("Done.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                {
                    MessageBox.Show("Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
