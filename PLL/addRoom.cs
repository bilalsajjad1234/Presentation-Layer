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
    public partial class addRoom : Form
    {

        BLL.Room r = new Room();
        BLL.Receptionist re = new Receptionist();
        public addRoom()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(comboBox2.SelectedItem?.ToString()))
            {
                MessageBox.Show("Please fill in all fields.");
                return; // Exit the method without proceeding further
            }
            if (!radioButton4.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Please select whether the room has a Jacuzzi.");
                return; // Exit the method without proceeding further
            }
            int rn = int.Parse(textBox4.Text.ToString());
            int rp = int.Parse(textBox3.Text.ToString());
            int cap = int.Parse(comboBox2.SelectedItem?.ToString());



            DeluxeRoom dr = new DeluxeRoom();
            StandardRoom sr = new StandardRoom();

            dr.RoomNumber = rn;
            dr.Price = rp;
            dr.Capacity = cap;
            dr.HasJacuzzi = "Jacuzzi";

            sr.RoomNumber = rn;
            sr.Price = rp;
            sr.Capacity = cap;
            sr.HasBalcony = "Balcony";




            if (radioButton4.Checked)
            {
                //int jacuzziPrice = 1900; //this is per day price
                //int total = int.Parse(comboBox1.SelectedItem?.ToString()) * jacuzziPrice;
                //textBox3.Text = total.ToString();
                bool added = re.addRoom(dr.RoomNumber, dr.Price, dr.Capacity, dr.HasJacuzzi);

                if (added)
                {
                    MessageBox.Show("added data");

                }
                else
                {
                    MessageBox.Show("error occured");
                }

            }
            else if (radioButton3.Checked)
            {
                //int balconyPrice = 2900; //this is per day price
                //int total = int.Parse(comboBox1.SelectedItem?.ToString()) * balconyPrice;
                //textBox3.Text = total.ToString();
                bool added = re.addRoom(sr.RoomNumber, sr.Price, sr.Capacity, sr.HasBalcony);
                if (added)
                {
                    MessageBox.Show("added data");

                }
                else
                {
                    MessageBox.Show("error occured");
                }

            }
            textBox4.Text = "";
            textBox3.Text = "";
            comboBox2.SelectedIndex = -1;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            //bool added = re.addRoom(dr.RoomNumber, dr.Price, dr.Capacity, dr.HasJacuzzi);
            //if (added)
            //{
            //    MessageBox.Show("added data");
            //}
            //else
            //{
            //    MessageBox.Show("Unexpected Error Occured!");

            //}
        }
    }
}
