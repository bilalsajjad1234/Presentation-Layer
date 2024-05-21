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
    public partial class ipconnectivity : Form
    {


        ip_lan ipc = new ip_lan();
        public ipconnectivity()
        {
            InitializeComponent();
        }

        private void ipconnectivity_Load(object sender, EventArgs e)
        {
            textBox1.Text = ipc.registryread();
            textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            //getthecon g = new getthecon();
            string ipAddress = textBox1.Text;
            //string databaseName = textBox2.Text;
            string username = textBox2.Text;
            string password = textBox3.Text;
            bool isConnected = ipc.ConnectToDatabase(ipAddress, username, password);

            if (isConnected)
            {
                MessageBox.Show("Connection successful!");
                ipc.registrywrite(ipAddress.ToString());
                List<string> databases = ipc.GetDatabaseList(ipAddress, username, password);

                listBox1.Items.Clear();
                foreach (string db in databases)
                {
                    listBox1.Items.Add(db);
                }
                timer1.Start();


            }
            else
            {
                MessageBox.Show("Connection failed!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            var mw = new UserForm();
            mw.Show();
            this.Hide();
        }
    }
}
