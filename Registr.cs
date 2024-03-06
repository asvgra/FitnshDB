using iTextSharp.text.pdf;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using ToolTip = System.Windows.Forms.ToolTip;

namespace Kursovvaia
{
    public partial class Registr : Form
    {
        private Random random;
       
        public Registr()
        {
            InitializeComponent();
            random = new Random();
        }

        private void ChecOK_Click(object sender, EventArgs e)
        {
            if (AddSurname.Text == "")
            {
                MessageBox.Show("Введите ФИО пользователяя");
                return;
            }
            if (id_klients.Text == "")
            {
                MessageBox.Show("Введите id клиента или сгенерируйте его");
                return;
            }
            if (maskedTextBox1.Text == "")
            {
                MessageBox.Show("Введите номер телефона клиента");
                return;
            }
            DB_con db = new DB_con(); //имеем доступ к функциям с класса DBЫ
            MySqlDataAdapter adapte = new MySqlDataAdapter();
            db.openConnection();


            DataTable table = new DataTable();
            MySqlCommand comm = new MySqlCommand("INSERT INTO `journal` ( `publication_year`,`author`,  `name_jornal`,  `publisher`) VALUES (@id,@name, @surname,  @password)", db.getConnection());
            String name = AddSurname.Text;
            String auter = id_klients.Text;
            String izd = maskedTextBox1.Text;
            String id = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            
            comm.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            comm.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            comm.Parameters.Add("@surname", MySqlDbType.VarChar).Value = izd;
            comm.Parameters.Add("@password", MySqlDbType.VarChar).Value = auter; //внесли в заглушку значение переменной

            if (comm.ExecuteNonQuery() == 1)
                MessageBox.Show("Клиент добавлен в базу данных");
            else
                MessageBox.Show("Извините,клиент не может быть добавлен, проверьте правильность заполнения");

            AddSurname.Clear();
            id_klients.Clear();
            maskedTextBox1.Clear();
            dateTimePicker1.ResetText();
            db.closeConnection();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }
     

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string code = GenerateCode();
            id_klients.AppendText(code);

        }
        private string GenerateCode()
        {
            string code = "";
            for (int i = 0; i < 8; i++)
            {
                code += random.Next(0, 10).ToString();
            }
                      id_klients.Clear();  return code;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(button7, "Сгенерировать id");
        }

        private void AddSurname_MouseEnter(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(AddSurname, "Введите ФИО с больших букв и с пробелами");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            sales login = new sales();
            login.ShowDialog();
        }
    }
}

