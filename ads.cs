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
    public partial class ads : Form
    {
        public ads()
        {
            InitializeComponent();
        }
        public void reload()
        {

            DB_con detebl = new DB_con();
            detebl.openConnection();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `location` AS 'Название зала' ,`adress` AS 'Адрес зала' FROM `locations`", detebl.getConnection()); //выполняем подключение к базе данных и выбираем из нее введенные пользователем логин и пароль(ищем совпадения) делается с помощью языка sql. @lu и @pu это специальные заглушки для безопасности 

            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataGridView_sale.DataSource = table;



            dataGridView_sale.Columns[0].Width = 100;
            dataGridView_sale.Columns[1].Width = 90;
          ;
            dataGridView_sale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_sale.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            detebl.closeConnection();
        }
        private void ads_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            OSNOV login = new OSNOV();
            login.ShowDialog();
        }
    }
}
