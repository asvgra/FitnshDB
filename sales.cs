using iTextSharp.text;
using iTextSharp.text.pdf;
using Kursovvaia;
using MySqlConnector;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Kursovvaia
{
    public partial class sales : Form
    {
        public sales()
        {
            InitializeComponent();
        }
        public void reload()
        {

            DB_con detebl = new DB_con();
            detebl.openConnection();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `publisher` AS 'Идентификатор клиента' ,`author` AS 'ФИО клиента',`publication_year` AS 'Дата рождения',`name_jornal` AS 'Номер телефона'  FROM `journal`", detebl.getConnection()); //выполняем подключение к базе данных и выбираем из нее введенные пользователем логин и пароль(ищем совпадения) делается с помощью языка sql. @lu и @pu это специальные заглушки для безопасности 

            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataGridView_sale.DataSource = table;



            dataGridView_sale.Columns[0].Width = 20;
            dataGridView_sale.Columns[1].Width = 90;
            dataGridView_sale.Columns[2].Width = 30;
            dataGridView_sale.Columns[3].Width = 110;
            dataGridView_sale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_sale.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            detebl.closeConnection();
        }
        private void fileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs e)
        {

        }

        private void sales_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            int index = dataGridView_sale.CurrentRow.Index;
            int index1 = Convert.ToInt32(dataGridView_sale.CurrentRow.Cells[0].Value);
            if (index < dataGridView_sale.RowCount - 1)
            {
                dataGridView_sale.Rows[index + 1].Selected = true;
                dataGridView_sale.CurrentCell = dataGridView_sale[0, index + 1];
            }
            else
            { }

            DB_con db = new DB_con();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand comm = new MySqlCommand("SELECT num_jornal AS `Номер журнала`, location AS 'Название магазина', quantity AS 'Количество', adress AS 'Адрес магазина' FROM `locations` WHERE num_jornal = @id_reader", db.getConnection());

            comm.Parameters.Add("@id_reader", MySqlDbType.VarChar).Value = index1 - 1;
            adapter.SelectCommand = comm;
            adapter.Fill(table);
            //dataGridViewLocc.DataSource = table;
            db.closeConnection();
            //   labelSelected.Text = Convert.ToString(dataGridViewSales.CurrentRow.Index + 1);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
             int index = dataGridView_sale.CurrentRow.Index;
            int index1 = Convert.ToInt32(dataGridView_sale.CurrentRow.Cells[0].Value);
            if (index < dataGridView_sale.RowCount + 1)
            {
                dataGridView_sale.Rows[index - 1].Selected = true;
                dataGridView_sale.CurrentCell = dataGridView_sale[0, index - 1];
            }
            else
            { }

            DB_con db = new DB_con();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand comm = new MySqlCommand("SELECT num_jornal AS `Номер журнала`, location AS 'Название магазина', quantity AS 'Количество', adress AS 'Адрес магазина' FROM `locations` WHERE num_jornal = @id_reader", db.getConnection());

            comm.Parameters.Add("@id_reader", MySqlDbType.VarChar).Value = index1 + 1;
            adapter.SelectCommand = comm;
            adapter.Fill(table);
            //dataGridViewLocc.DataSource = table;
            db.closeConnection();

        }




        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView_sale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           


        }
        private DataTable dt2;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registr login = new Registr();
            login.ShowDialog();






        }



        

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить данные клиента? Они исчезнут навсегда", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return; // Если пользователь отменил удаление, выходим из метода
            }

            // Создаем список для хранения идентификаторов выбранных строк
            List<int> selectedIds = new List<int>();

            // Получаем выбранные строки из DataGridView
            foreach (DataGridViewRow row in dataGridView_sale.SelectedRows)
            {
                // Добавляем идентификатор выбранной строки в список
                selectedIds.Add((int)row.Cells[0].Value);
            }

            // Удаляем выбранные строки из DataGridView
            foreach (DataGridViewRow row in dataGridView_sale.SelectedRows)
            {
                dataGridView_sale.Rows.Remove(row);
            }

            // Создаем новое подключение к базе данных
            DB_con detebl = new DB_con();
            detebl.openConnection();

            // Удаляем выбранные строки из базы данных
            foreach (int id in selectedIds)
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM `journal` WHERE `publisher` = @identifier", detebl.getConnection());
                command.Parameters.AddWithValue("@identifier", id);
                command.ExecuteNonQuery();
            }

            // Закрываем подключение
            detebl.closeConnection();

            // Перезагружаем данные в DataGridView
            //reload();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            zakaz login = new zakaz();
            login.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        //private void dataGridView_sale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{

        //}

        private void dataGridView_sale_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_sale.CurrentCell != null && dataGridView_sale.CurrentCell.RowIndex < dataGridView_sale.Rows.Count)
            {
                dataGridView_sale.Rows[dataGridView_sale.CurrentCell.RowIndex].Selected = true;
            }



            try
            {
                // Проверка, что выбранная строка существует
                if (dataGridView_sale.SelectedRows.Count > 0)
                {
                    int index1 = dataGridView_sale.SelectedRows[0].Index;

                    DB_con db = new DB_con();
                    db.openConnection();
                    MySqlDataAdapter adapte = new MySqlDataAdapter();
                    DataTable table = new DataTable();
                    MySqlCommand command = new MySqlCommand("SELECT `picture` FROM `journal`", db.getConnection());
                    adapte.SelectCommand = command;
                    adapte.Fill(table);

                    // Проверка, что строка содержит данные
                    if (table.Rows[index1] != null)
                    {
                        // Проверка, что строка содержит данные в указанном столбце
                        //     if (table.Rows[index1][0] != null)
                        //   {
                        // Проверка, что данные в указанном столбце являются массивом байтов
                        if (table.Rows[index1][0] is byte[])
                        {
                            Byte[] data = (Byte[])(table.Rows[index1][0]);
                            MemoryStream mem = new MemoryStream(data);
                            foto.Image = System.Drawing.Image.FromStream(mem);
                        }
                        //  }
                    }

                    db.closeConnection();
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dataGridView_sale_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView_sale.CurrentRow.Index;
            dataGridView_sale.Text = Convert.ToString(dataGridView_sale.Rows[row].Cells[1].Value);
        }

        private void button7_Click(object sender, EventArgs e)
        {

            this.Hide();
            OSNOV login = new OSNOV();
            login.ShowDialog();
        }
    }
}
    
            
          