using Kursovvaia;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Kursovvaia
{
    public partial class nalishie : Form
    {


        public nalishie()
        {
            InitializeComponent();
            // Инициализация комбобокса и BindingSource

        }

        public void reload()
        {

            DB_con detebl = new DB_con();
            detebl.openConnection();
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `name_jornal` AS 'Навзвание тренировки', `information` AS 'Информация о тренировке', `jornal_num` AS 'Цена абонемента',`ID`, `picture` FROM `info`", detebl.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            comboControl.DataSource = table;
            comboControl.DisplayMember = "Навзвание тренировки";
            comboControl.ValueMember = "ID";
            comboControl.DataSource = table;
            detebl.closeConnection();


        }
        private void ChecOK_Click(object sender, EventArgs e)
        {



        }

        private void sears_Click(object sender, EventArgs e)
        {


        }





        //// Восстановление выбранного значения, если оно было
        //comboControl.SelectedValue = selectedValue


        //// Обновление DataSource через BindingSource
        //bindingSource.DataSource = table;

        //// Установка DisplayMember и ValueMember для комбо-бокса,чтобы названия не терялись
        //comboControl.DisplayMember = "name_jornal";
        //comboControl.ValueMember = "ID";

        //if (table.Rows.Count > 0)
        //{
        //    // Режим обработки данных при наличии результатов поиска
        //    MessageBox.Show("Тренировка найдена");
        //}
        //else
        //{
        //    // Режим обработки данных при отсутствии результатов поиска
        //    MessageBox.Show("Тренировка не найдена");
        //}







        private void nalishie_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            //dataGridView1.Sort(dataGridView1.Columns[3], ListSortDirection.Ascending);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //dataGridView1.Sort(dataGridView1.Columns[4], ListSortDirection.Ascending);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {


         
        }
    
   
    

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        



        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {


         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            this.Close();
            sales newform = new sales();
            newform.ShowDialog();



        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //int row = dataGridView1.CurrentRow.Index;
            //dataGridView1.Text = Convert.ToString(dataGridView1.Rows[row].Cells[1].Value);


        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            OSNOV login = new OSNOV();
            login.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
 
        private void comboControl_SelectedIndexChanged(object sender, EventArgs e)
        {


          









            // Проверяем, что обработчик событий не вызван автоматически при загрузке формы

            if (comboControl.SelectedIndex != -1)
                {
                    DataRowView selectedRowView = comboControl.SelectedItem as DataRowView;
                    if (selectedRowView != null)
                    {
                        // Предполагается, что столбец ID содержит целочисленные значения
                        int selectedId = Convert.ToInt32(selectedRowView["ID"]);
                        // Теперь вы можете использовать selectedId для дальнейшей обработки
                        richTextBox1.Text = selectedRowView[1].ToString();
                    sals.Text = selectedRowView[2].ToString();



                        // Запрос к базе данных для получения изображения
                        DB_con db = new DB_con();
                        db.openConnection();
                        MySqlCommand command = new MySqlCommand("SELECT picture FROM info WHERE ID = @selectedId", db.getConnection());
                        command.Parameters.AddWithValue("@selectedId", selectedId);

                        MySqlDataAdapter adapte = new MySqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapte.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            Byte[] data = (Byte[])(table.Rows[0]["picture"]);
                            using (MemoryStream mem = new MemoryStream(data))
                            {
                                foto.Image = Image.FromStream(mem);
                            }
                        }

                        db.closeConnection();
                    }

                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Цена на абонемент расчитывается за один календарный месяц");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            zakaz login = new zakaz();
            login.ShowDialog();
        }




    }
}
       
    
