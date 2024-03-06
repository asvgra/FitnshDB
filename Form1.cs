using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovvaia
{
    public partial class Form1 : Form
   {
        public Form1()
        {
            InitializeComponent();
            Names.Text = "Введите логин";
            Names.ForeColor = Color.Gray;

            PASs.Text = "Введите пароль";
            PASs.ForeColor = Color.Gray;
        }


private void Names_Enter(object sender, EventArgs e)
            {
                if (Names.Text == "Введите логин")
                {
                    Names.Text = "";
                    Names.ForeColor = Color.Black;
                }
            }

            private void Names_Leave(object sender, EventArgs e)
            {

                if (Names.Text == "")
                {
                    Names.Text = "Введите логин";
                    Names.ForeColor = Color.Gray;
                }
            }
        private void Registrsh_Click(object sender, EventArgs e)
        {
            if (Names.Text == "Введите логин")
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (PASs.Text == "Введите пароль")
            {
                MessageBox.Show("Введите пароль");
                return;
            }

          //  if (ChecUz())
           //     return;
            DB_con db = new DB_con(); //имеем доступ к функциям с класса DBЫ
            MySqlCommand comm = new MySqlCommand("INSERT INTO `admins` (`login`,  `pass`) VALUES (@name, @surname)", db.getConnection());
            String login = Names.Text;
            String password = PASs.Text;

            comm.Parameters.Add("@name", MySqlDbType.VarChar).Value = login; //внесли в заглушку значение переменной
            comm.Parameters.Add("@surname", MySqlDbType.VarChar).Value = password;

      

            if (comm.ExecuteNonQuery() == 1)
                MessageBox.Show("Поздравляем Вы успешно зарегистрировались");
            else
                MessageBox.Show("Извините,но аккаунт не может быть создан,проверьте данные или позвоните в библиотеку");




                             }

        //public Boolean ChecUz()
        //    {

        //    DB_con db = new DB_con();
          
        //    MySqlDataAdapter adapter = new MySqlDataAdapter();
        //    DataTable table = new DataTable();
        //    MySqlCommand comm = new MySqlCommand("SELECT * FROM admins WHERE `login` = @uL", db);
        //    comm.Parameters.Add("@uL", MySqlDbType.VarChar).Value = Names.Text;
        //    adapter.SelectCommand = comm;
        //    adapter.Fill(table);
        //    db.Close();


        //    if (table.Rows.Count > 0)
        //        {
        //            MessageBox.Show("Данный логин уже имеется в базе,пожалуйста,придумайте новый");
        //            return true;
        //        }

        //        else
        //            return false;
        //    }


        //    private void label1_Click(object sender, EventArgs e)
        //    {
        //        Application.Exit();
        //    }
        //    Point col;

        //    private void panel1_MouseMove(object sender, MouseEventArgs e)
        //    {
        //        if (e.Button == MouseButtons.Left)
        //        {
        //            this.Left += e.X - col.X;
        //            this.Top += e.Y - col.Y;
        //        }
        //    }

        //    private void panel1_MouseDown(object sender, MouseEventArgs e)
        //    {
        //        col = new Point(e.X, e.Y);
        //    }

            

        private void Names_TextChanged(object sender, EventArgs e)
        {

        }

        private void PASs_TextChanged(object sender, EventArgs e)
        {

        }

        private void PASs_Enter(object sender, EventArgs e)
        {
            if (PASs.Text == "Введите пароль")
            {
                PASs.Text = "";
                PASs.ForeColor = Color.Black;
            }
        }

        private void PASs_Leave(object sender, EventArgs e)
        {
            if (PASs.Text == "")
            {
                PASs.Text = "Введите логин";
                PASs.ForeColor = Color.Gray;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Registr_label_Click(object sender, EventArgs e)
        {

            this.Hide();
           vhod login = new vhod();
            login.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

        }
            
        
    
