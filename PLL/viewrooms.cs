using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLL
{
    
    public partial class viewrooms : Form
    {
        BLL.Receptionist rc = new BLL.Receptionist();
        public viewrooms()
        {
            InitializeComponent();
        }

        private void viewrooms_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = rc.fetchRooms();
        }
    }
}
