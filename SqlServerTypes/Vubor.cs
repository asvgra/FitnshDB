using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Kursovvaia.SqlServerTypes
{
    public partial class Vubor : Form
    {
        public Vubor()
        {
            InitializeComponent();
        }
        public void reload()
        {



            try
            {
                DB_con detebl = new DB_con();
                detebl.openConnection();
                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT `ID`,`nam` AS 'ФИО тренера' ,`inf` AS 'Компетенция тренера'  FROM `spor`", detebl.getConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);

                dataGridView_sales.DataSource = table;

                dataGridView_sales.Columns[0].Width = 30;
                dataGridView_sales.Columns[1].Width = 150;
                dataGridView_sales.Columns[2].Width = 410;
                dataGridView_sales.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dataGridView_sales.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
   detebl.closeConnection();
            }
            catch (Exception ex)
            {
                // Логирование ошибки или отображение сообщения об ошибке
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        //private void dataGridView_sale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{



            //if (dataGridView_sale.SelectedRows.Count > 0)
            //{
            //    DataGridViewRow selectedRow = dataGridView_sale.SelectedRows[0];

            //    // Предполагается, что столбец ID содержит целочисленные значения
            //    if (int.TryParse(selectedRow.Cells["ID"].Value.ToString(), out int selectedId))
            //    {

            //        // Запрос к базе данных для получения изображения
            //        DB_con db = new DB_con();
            //        db.openConnection();

            //        MySqlCommand command = new MySqlCommand("SELECT pic FROM info WHERE ID = @selectedId", db.getConnection());
            //        command.Parameters.AddWithValue("@selectedId", selectedId);

            //        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
            //        {
            //            DataTable table = new DataTable();
            //            adapter.Fill(table);

            //            if (table.Rows.Count > 0)
            //            {
            //                byte[] data = (byte[])table.Rows[0]["pic"]; // Обратите внимание на наименование столбца

            //                using (MemoryStream mem = new MemoryStream(data))
            //                {
            //                    foto.Image = Image.FromStream(mem);
            //                }
            //            }
            //        }

            //        db.closeConnection();
























        //}

        private void buttonNext_Click(object sender, EventArgs e)
        {
            int index = dataGridView_sales.CurrentRow.Index;
            int index1 = Convert.ToInt32(dataGridView_sales.CurrentRow.Cells[0].Value);
            if (index < dataGridView_sales.RowCount - 1)
            {
                dataGridView_sales.Rows[index + 1].Selected = true;
                dataGridView_sales.CurrentCell = dataGridView_sales[0, index + 1];
            }


            DB_con db = new DB_con();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand comm = new MySqlCommand("SELECT `nam` AS 'ФИО тренера' ,`inf` AS 'Компетенция тренера'  FROM `spor`", db.getConnection()); //выполняем подключение 
            //comm.Parameters.Add("@id_reader", MySqlDbType.VarChar).Value = index1 - 1;
            adapter.SelectCommand = comm;
            adapter.Fill(table);
            //dataGridViewLocc.DataSource = table;
            db.closeConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            int index = dataGridView_sales.CurrentRow.Index;
            int index1 = Convert.ToInt32(dataGridView_sales.CurrentRow.Cells[0].Value);
            if (index < dataGridView_sales.RowCount + 1)
            {
                dataGridView_sales.Rows[index - 1].Selected = true;
                dataGridView_sales.CurrentCell = dataGridView_sales[0, index - 1];
            }
            else
            { }

            DB_con db = new DB_con();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            MySqlCommand comm = new MySqlCommand("SELECT `nam` AS 'ФИО тренера' ,`inf` AS 'Компетенция тренера', `ID`  FROM `spor`", db.getConnection()); //выполняем подключение
            comm.Parameters.Add("@id_reader", MySqlDbType.VarChar).Value = index1 + 1;
            adapter.SelectCommand = comm;
            adapter.Fill(table);
            //dataGridViewLocc.DataSource = table;
            db.closeConnection();










        }
        private void dataGridView_sale_SelectionChanged(object sender, EventArgs e)
        {

            if (dataGridView_sales.CurrentCell != null && dataGridView_sales.CurrentCell.RowIndex < dataGridView_sales.Rows.Count)
            {
                dataGridView_sales.Rows[dataGridView_sales.CurrentCell.RowIndex].Selected = true;
            }



            try
            {
                // Проверка, что выбранная строка существует
                if (dataGridView_sales.SelectedRows.Count > 0)
                {
                    int index1 = dataGridView_sales.SelectedRows[0].Index;

                    DB_con db = new DB_con();
                    db.openConnection();
                    MySqlDataAdapter adapte = new MySqlDataAdapter();
                    DataTable table = new DataTable();
                    MySqlCommand command = new MySqlCommand("SELECT `pic` FROM `spor`", db.getConnection());
                    //MySqlCommand command = new MySqlCommand("SELECT `picture` FROM `journal`", db.getConnection());
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
                            Image originalImage = System.Drawing.Image.FromStream(mem);

                            // Создание уменьшенной копии изображения с заданными размерами
                            int desiredWidth = 300; // Задайте желаемую ширину
                            int desiredHeight =  300; // Задайте желаемую высоту
                            Image thumbnailImage = originalImage.GetThumbnailImage(desiredWidth, desiredHeight, null, IntPtr.Zero);

                            // Присвоение уменьшенной копии PictureBox
                            fotos.Image = thumbnailImage;
                        
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


    private void Vubor_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView_sale_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView_sales.CurrentRow.Index;
            dataGridView_sales.Text = Convert.ToString(dataGridView_sales.Rows[row].Cells[1].Value);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            OSNOV login = new OSNOV();
            login.ShowDialog();
        }
    }
}
