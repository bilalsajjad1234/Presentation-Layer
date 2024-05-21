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
    public partial class checkin : Form
    {
        BLL.Receptionist r = new Receptionist();
        public checkin()
        {
            InitializeComponent();
        }

        private void checkin_Load(object sender, EventArgs e)
        {
            textBox1.Text = user.Username;
            comboBox1.Enabled = false;
            // button1.Enabled = false;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int roomno = int.Parse(textBox2.Text.ToString());
            string name = textBox1.Text.ToString();

            if (!r.roomPresent(roomno))
            {

                MessageBox.Show("Room doesnt exits :(");
                button2.Enabled = false;

            }
            else if (r.roomCheck(roomno))
            {

                MessageBox.Show("Room already booked");
                button2.Enabled = false;

            }
            else if (r.alreadyBook(name))
            {
                MessageBox.Show("You are already assigned a room");
            }
            else
            {
                button2.Enabled = true;
                comboBox1.Enabled = true;
                //button1.Enabled = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text.ToString();
            int roomno = int.Parse(textBox2.Text.ToString());
            int days = int.Parse(comboBox1.SelectedItem?.ToString());


            bool added = r.addBookedRoom(name, roomno, days);
            if (added)
            {
                MessageBox.Show("data added successfully");
                button2.Enabled = false;
                textBox2.Text = "";
                comboBox1.SelectedItem = -1;
            }
            else
            {
                MessageBox.Show("room already booked");

            }
        }
    }
}
