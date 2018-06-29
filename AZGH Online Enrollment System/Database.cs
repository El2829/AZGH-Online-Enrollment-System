using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace AZGH_Online_Enrollment_System
{
    class Database
    {
        MySqlConnection con;

        public Database(string connstr)
        {
            con = new MySqlConnection(connstr);

        }

        public MySqlConnection getConnection()
        {
            return this.con;
        }

        public void executecmd(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, getConnection());
            cmd.ExecuteNonQuery();
        }
        public bool openConnection()
        {
            try
            {
                con.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        public bool closeConnection()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
