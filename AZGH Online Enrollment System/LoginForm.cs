using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AZGH_Online_Enrollment_System
{
    public partial class LoginForm : Form
    {
        Database dbconnection;
        public LoginForm()
        {
            Connection.setServer("127.0.0.1");
            Connection.setPort("3307");
            Connection.setUser("personal");
            Connection.setDatabase("oes");
            Connection.setPassword("borinaga09");
            dbconnection = new Database(Connection.getConnectionStr());
            InitializeComponent();
            //Color myRgbColor = new Color();
        }
        private void validate(string user, string pass)
        {
            dbconnection.openConnection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select accounttype from tblaccount where username=@user and password=@pass";
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", pass);
            Variable.userStatus = cmd.ExecuteScalar().ToString();
            dbconnection.closeConnection();
        }
        private bool validate_login(string user, string pass)
        {
            dbconnection.openConnection(); 
            string query = "Select * from tblaccount where username=@user and password=@pass ";
            MySqlCommand cmd = new MySqlCommand(query, dbconnection.getConnection());
            cmd.Parameters.AddWithValue("@user", user);
            cmd.Parameters.AddWithValue("@pass", MD5Hasher.GetMd5Hash(pass));
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                dbconnection.closeConnection();
                return true;
            }
            else
            {
                dbconnection.closeConnection();
                return false;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void CloseImageButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to Close the Application?", "Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dr == DialogResult.No)
            {

            }
        }

        private void MinimizeImageButton_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ForgetPasslbl_Click(object sender, EventArgs e)
        {
            ForgotForm forgotpass = new ForgotForm(); //showing new form
            forgotpass.ShowDialog(); //for form not to be executed twice after done
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            string user = Login_txt.Text; //variable for Username
            string pass = Password_Txt.Text; //variable for Password
            if (user == "Enter Username" || pass == "Enter Password")
            {
                Password_Txt.ForeColor = Color.Red;
                Login_txt.ForeColor = Color.Red;
                return;
            }
            bool r = validate_login(user, pass); 
            if (r)
            {
                //
                this.Hide();
                MainForm Form = new MainForm();
                Form.Show(); 
            }
            else
                MessageBox.Show("Incorrect Login Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Login_txt_Enter(object sender, EventArgs e)
        {
            if (Login_txt.Text == "Enter Username")
            {
                Login_txt.Text = string.Empty;
                Login_txt.ForeColor = Color.Black;
            }
        }

        private void Login_txt_Leave(object sender, EventArgs e)
        {
            if (Login_txt.Text == string.Empty)
            {
                Login_txt.Text = "Enter Username";
                Login_txt.ForeColor = Color.Silver;
            }
        }

        private void Login_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //enter key press
            {
                Password_Txt.Focus();//focusing the next txtbox after keypress
            }
        }

        private void Password_Txt_Enter(object sender, EventArgs e)
        {
            if (Password_Txt.Text == "Enter Password")
            {
                Password_Txt.Text = string.Empty;
                Password_Txt.ForeColor = Color.Black;
                Password_Txt.isPassword = true;
            }
        }

        private void Password_Txt_Leave(object sender, EventArgs e)
        {
            if (Password_Txt.Text == string.Empty)
            {
                Password_Txt.Text = "Enter Password";
                Password_Txt.ForeColor = Color.Silver;
                Password_Txt.isPassword = false;
            }
        }

        private void Password_Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) //enter key press
            {
                Login_btn_Click(sender, e); //alternative way for PerformClick();
            }
        }
    }
}
