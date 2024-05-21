using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using System.Windows.Forms;

namespace PLL
{
    public partial class checkout : Form
    {

        BLL.Receptionist r = new Receptionist();
        private Random random = new Random();
        public checkout()
        {
            InitializeComponent();
        }

        private void checkout_Load(object sender, EventArgs e)
        {
            //string name = textBox1.Text;


            //int price = r.getRoom("ali_980");
            //textBox2.Text = price.ToString();
            string name = user.Username;
            textBox1.Text = name;
            int days = r.getDays(name);
            int roomno = r.getRoom(name);
            int price = r.getPrice(roomno);
            textBox4.Text = days.ToString();
            textBox2.Text = roomno.ToString();
            textBox3.Text = price.ToString();
            int randomNumber = random.Next(300, 500);
            textBox5.Text = randomNumber.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            int days = int.Parse(textBox4.Text.ToString());

            int price = int.Parse(textBox3.Text.ToString());
            int total = (days * price) + int.Parse(textBox5.Text);
            textBox6.Text = total.ToString();


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            var nf = new payment();
            nf.Show();
            this.Hide();
        }
    }
}
