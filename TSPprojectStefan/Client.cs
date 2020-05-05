using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace TSPprojectStefan
{

    class Client
    {
        Connect conn = new Connect();
        public bool insertClient(String fName, String lName, String country, String phoneNumber) {

            MySqlCommand command = new MySqlCommand();
            String insertQuery = "INSERT INTO `clients`(`first_name`, `last_name`, `phone_number`, `country`) VALUES (@fname,@lname,@phoneNumber,@country)";
            command.CommandText = insertQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = fName;
            command.Parameters.Add("@lname", MySqlDbType.VarChar).Value = lName;
            command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = country;
            command.Parameters.Add("@country", MySqlDbType.VarChar).Value = phoneNumber;

            conn.openConnection();
            if (command.ExecuteNonQuery() == 1) {
                conn.closeConnection();
                return true;

            }

            conn.closeConnection();
            return false;

        }

        public DataTable getClients() {
            MySqlCommand command = new MySqlCommand("SELECT * FROM `clients` ",conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            return  table;
        }

        public bool editClient(int id, String fName, String lName, String country, String phoneNumber)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "UPDATE `clients` SET `first_name`=@fname,`last_name`=@lname,`phone_number`=@phoneNumber,`country`=@country WHERE `id`=@cid";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@cid", MySqlDbType.VarChar).Value = id;
            command.Parameters.Add("@fname", MySqlDbType.VarChar).Value = fName;
            command.Parameters.Add("@lname", MySqlDbType.VarChar).Value = lName;
            command.Parameters.Add("@phoneNumber", MySqlDbType.VarChar).Value = country;
            command.Parameters.Add("@country", MySqlDbType.VarChar).Value = phoneNumber;

            conn.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;

            }

            conn.closeConnection();
            return false;

        
        }

        public bool deleteClient(int id) {
            MySqlCommand command = new MySqlCommand();
            String removeQuery = "DELETE FROM `clients` WHERE `id` = @cid";
            command.CommandText = removeQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@cid", MySqlDbType.Int32).Value = id;

            conn.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;

            }

            conn.closeConnection();
            return false;
        }
    }
}
