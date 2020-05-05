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

namespace TSPprojectStefan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Connect conn = new Connect();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand();
            String query = "SELECT * FROM `users` WHERE `username` =@usn AND `password`=@pass";

            command.CommandText = query;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = userNameTextBox.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = PasswordTextBox.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                Main_form mform = new Main_form();
                mform.Show();
            }
            else
            {
                if (userNameTextBox.Text.Trim().Equals("")) {
                    MessageBox.Show("Enter your user", "Empty user name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (PasswordTextBox.Text.Trim().Equals(""))
                {
                    MessageBox.Show("Enter your password", "Empty password", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else {
                    MessageBox.Show("This user name or password does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }
            }

        }
    }
}
