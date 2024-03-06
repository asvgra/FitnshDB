using iTextSharp.text.pdf;
using iTextSharp.text;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovvaia
{
    public partial class zakaz : Form
    {
        public zakaz()
        {
            InitializeComponent();
        }
        public void reload()
        {

            DB_con detebl = new DB_con();

            DataTable table = new DataTable();
            detebl.openConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT `publisher` AS 'Идентификатор клиента' ,`author` AS 'ФИО клиента',`publication_year` AS 'Дата рождения',`name_jornal` AS 'Номер телефона'  FROM `journal`", detebl.getConnection()); //выполняем подключение к базе данных и выбираем из нее введенные пользователем логин и пароль(ищем совпадения) делается с помощью языка sql. @lu и @pu это специальные заглушки для безопасности 

            adapter.SelectCommand = command;
            adapter.Fill(table);

            dataGridView_sale.DataSource = table;


            dataGridView_sale.Columns[0].Width = 20;
            dataGridView_sale.Columns[1].Width = 90;
            dataGridView_sale.Columns[2].Width = 20;
            dataGridView_sale.Columns[3].Width = 50;
            dataGridView_sale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView_sale.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;




            DataTable tables = new DataTable();

            MySqlDataAdapter adapterr = new MySqlDataAdapter();

            MySqlCommand commands = new MySqlCommand("SELECT `name_jornal` AS 'Навзвание тренировки', `information` AS 'Информация о тренировке', `jornal_num` AS 'Цена абонемента' FROM `info`", detebl.getConnection());

            adapterr.SelectCommand = commands;
            adapterr.Fill(tables);

            dataGridView1.DataSource = tables;


            dataGridView1.Columns[0].Width = 110;
            dataGridView1.Columns[1].Width = 210;
            dataGridView1.Columns[2].Width = 20;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            detebl.closeConnection();


        }
        private void zakaz_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void dataGridView_sale_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
        private DataTable dt2;
        private void button1_Click(object sender, EventArgs e)
        {

            // Если в dataGridView_sale есть выбранные строки
            if (dataGridView_sale.SelectedRows.Count > 0)
            {
                // Получаем выбранную строку
                DataGridViewRow selectedRow = dataGridView_sale.SelectedRows[0];

                // Если dt2 еще не инициализирован, создаем его и копируем столбцы из dataGridView_sale
                if (dt2 == null)
                {
                    dt2 = new DataTable();
                    foreach (DataGridViewColumn col in dataGridView_sale.Columns)
                    {
                        dt2.Columns.Add(col.Name, col.ValueType);
                    }
                }

                // Очищаем dt2 перед добавлением новой строки
                dt2.Rows.Clear();

                // Создаем новую строку в dt2 и копируем данные из выбранной строки
                DataRow newRow = dt2.NewRow();
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    newRow[cell.ColumnIndex] = cell.Value;
                }
                dt2.Rows.Add(newRow);

                // Устанавливаем dt2 как источник данных для dataGridViewOK и обновляем отображение
                dataGridViewOK.DataSource = dt2;
                dataGridViewOK.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null; // Очищает DataGridView
            dataGridViewOK.DataSource = null; // Очищает DataGridView
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //DataTable dt = (DataTable)dataGridViewOK.DataSource;
            //ds.Tables.Add(dt);

            //BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\times.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            //// iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL, new BaseColor(128, 0, 128));
            //iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(128, 0, 128));

            //if (dataGridViewOK.Rows.Count > 0)
            //{



            //    SaveFileDialog save = new SaveFileDialog();

            //    save.Filter = "PDF (*.pdf)|*.pdf";

            //    save.FileName = "zakaz.pdf";

            //    bool ErrorMessage = false;

            //    if (save.ShowDialog() == DialogResult.OK)

            //    {

            //        if (File.Exists(save.FileName))

            //        {

            //            try

            //            {

            //                File.Delete(save.FileName);

            //            }

            //            catch (Exception ex)

            //            {

            //                ErrorMessage = true;

            //                MessageBox.Show("Unable to wride data in disk" + ex.Message);

            //            }

            //        }

            //        if (!ErrorMessage)

            //        {

            //            try

            //            {

            //                PdfPTable pTable = new PdfPTable(dataGridViewOK.Columns.Count);

            //                pTable.DefaultCell.Padding = 2;
            //                pTable.WidthPercentage = 100;

            //                pTable.HorizontalAlignment = Element.ALIGN_LEFT;

            //                //Добавим в таблицу общий заголовок
            //                PdfPCell cell = new PdfPCell(new Phrase("Предзаказ комиксов ", font));

            //                // PdfPCell date = new PdfPCell();
            //                cell.Colspan = ds.Tables[0].Columns.Count;
            //                cell.HorizontalAlignment = 1;
            //                //Убираем границу первой ячейки, чтобы балы как заголовок
            //                cell.Border = 0;
            //                pTable.AddCell(cell);

            //                foreach (DataGridViewColumn col in dataGridViewOK.Columns)

            //                {

            //                    PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

            //                    pTable.AddCell(pCell);

            //                }

            //                //PdfPCell date = new PdfPCell(new Phrase("Дата: " + dateTimePicker1.Text, font));
            //                date.Colspan = ds.Tables[0].Columns.Count;
            //                date.HorizontalAlignment = 0;
            //                date.Border = 0;

            //                // Добавляем ячейку с датой в таблицу перед циклом, который добавляет строки
            //                pTable.AddCell(date);

            //                //Добавляем все остальные ячейки
            //                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            //                {
            //                    for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
            //                    {
            //                        pTable.AddCell(new Phrase(ds.Tables[0].Rows[j][k].ToString(), font));
            //                    }



            //                    // DataGridView dataGridViewAddress = dataGridViewLocc; // Замените на ваш DataGridView

            //                    // Создаем новую таблицу для адресов
            //                    //PdfPTable addressTable = new PdfPTable(1);

            //                    // Добавляем столбец в таблицу
            //                    // addressTable.AddCell(new PdfPCell(new Phrase("Адрес магазина", font)));

            //                    // Добавляем адреса в таблицу
            //                    // foreach (DataGridViewRow row in dataGridViewAddress.Rows)
            //                    // {
            //                    //     addressTable.AddCell(new PdfPCell(new Phrase(row.Cells[3].Value.ToString(), font)));
            //                    // }


            //                    // Создаем новый таблицу
            //                    //PdfPTable table2 = new PdfPTable(dataGridViewLocc.Columns.Count - 1);

            //                    using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
            //                    {
            //                        Document document = new Document(PageSize.A4.Rotate());
            //                        PdfWriter.GetInstance(document, fileStream);
            //                        //document.Add(addressTable);
            //                        document.Open();
            //                        // Добавляем таблицу с адресами в документ

            //                        document.Add(pTable);

            //                        document.Close();

            //                        fileStream.Close();
            //                    }

            //                    MessageBox.Show("Data Export Successfully", "info");

            //                }
            //            }

            //            catch (Exception ex)

            //            {

            //                MessageBox.Show("Error while exporting Data" + ex.Message);

            //            }

            //        }

            //    }

            //}

            //else

            //{

            //    MessageBox.Show("No Record Found", "Info");

            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView_sale_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_sale.CurrentCell != null && dataGridView_sale.CurrentCell.RowIndex < dataGridView_sale.Rows.Count)
            {
                dataGridView_sale.Rows[dataGridView_sale.CurrentCell.RowIndex].Selected = true;
            }

        }
        private DataTable dt1;
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = dt1;
            dataGridView2.Refresh();

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // получаем выбранную строку
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // если таблица второго датагрида еще не создана, создаем ее
                if (dt1 == null)
                {
                    dt1 = new DataTable();
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        dt1.Columns.Add(col.Name);
                    }
                }

                // Очищаем dt1 перед добавлением новой строки
                dt1.Rows.Clear();

                // копируем значения ячеек из выбранной строки и добавляем новую строку в таблицу
                DataRow newRows = dt1.NewRow();
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    newRows[cell.ColumnIndex] = cell.Value; newRows.EndEdit();
                }
                dt1.Rows.Add(newRows);

                // привязываем таблицу ко второму датагриду
                dataGridView2.DataSource = dt1;
            }











        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
       private void dataGridViewOK_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Клиент удачно записан. За день до начала тренировок ему придет смс");
            dataGridView2.DataSource = null; // Очищает DataGridView
            dataGridViewOK.DataSource = null; // Очищает DataGridView
        }

        private void button5_Click_1(object sender, EventArgs e)
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

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            OSNOV login = new OSNOV();
            login.ShowDialog();
        }
    }
}
