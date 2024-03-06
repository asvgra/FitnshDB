using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using MySqlConnector;

namespace Kursovvaia
{
    internal class DB_con
    {
        MySqlConnection connection;
        public DB_con()
        {
            try
            {
                connection = new MySqlConnection($"server=localhost;port=3306;username=root;database=komiksy_ar;Allow User Variables=True");
                connection.Open();
            }

            catch (Exception)
            {
                MessageBox.Show("Ошибка");
                throw;
            }

        }

        public DB_con(MySqlConnection connection)
        {
            this.connection = connection;
        }
       

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
        

 