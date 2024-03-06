using Kursovvaia.SqlServerTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovvaia
{
    public partial class OSNOV : Form
    {
        public OSNOV()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Form1 mainfo = new Form1();
            //  this.Hide();
            //  mainfo.ShowDialog();

            sales mainfo = new sales();
            this.Hide();
            mainfo.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

          Vubor mainfo = new Vubor();
            this.Hide();
            mainfo.ShowDialog();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            ads mainfo = new ads();
            this.Hide();
            mainfo.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            nalishie mainfo = new nalishie();
            this.Hide();
            mainfo.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
