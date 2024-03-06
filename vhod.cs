using MySqlConnector;
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
    public partial class vhod : Form
    {
        public vhod()
        {
            InitializeComponent();
        }

        private void GoTu_Click(object sender, EventArgs e)
        {
            String log = BoxLog.Text;//создали  переменную поместили в ее память значение из текст бокса   
            String Pass = BoxPass.Text;
            DB_con db = new DB_con();


            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter(); //создали память под адаптер

            // MySqlCommand comm = new MySqlCommand("SELECT * FROM readeers WHERE login = @uL AND password = @uP",db.getConnection()); это если для юзеров
            //Выбрать все элементы из бд юзер с таким логином и паролем c @ заглушки
            MySqlCommand comm = new MySqlCommand("SELECT * FROM admins WHERE login = @uL AND PASS = @uP", db.getConnection());

            comm.Parameters.Add("@uL", MySqlDbType.VarChar).Value = log; //внесли в заглушку значение переменной
            comm.Parameters.Add("@uP", MySqlDbType.VarChar).Value = Pass;

            adapter.SelectCommand = comm;
            adapter.Fill(table);


            if (table.Rows.Count > 0)
            {
                OSNOV mainfo = new OSNOV();
                this.Hide();
                mainfo.ShowDialog();
            }
            else
                MessageBox.Show("Данные введены не верно,проверьте правильность заполнения");
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registr_label_Click(object sender, EventArgs e)
        {
           Form1 mainfo = new Form1();
            this.Hide();
            mainfo.ShowDialog();
        }
    }
}
