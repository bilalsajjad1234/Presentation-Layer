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
    public partial class orderfood : Form
    {
        BLL.Receptionist r = new Receptionist();
        public orderfood()
        {
            InitializeComponent();
        }

        private void orderfood_Load(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            dataGridView1.DataSource = r.fetchfood();
            textBox3.Text = user.Username;
            string name = textBox3.Text;
            int rno = r.getRoom(name);
            textBox2.Text = rno.ToString();
            //int rno = r.getRoom(name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;

            int id = int.Parse(textBox1.Text.ToString());
            int rno = r.getRoom(name);
            int priceFood = r.getPriceofFood(id);
            bool update = r.priceUpdate(rno, priceFood);
            if (update)
            {
                MessageBox.Show("Food is Coming!!!");
            }
            else
            {
                MessageBox.Show("Error Occured!");
            }
        }
    }
}
