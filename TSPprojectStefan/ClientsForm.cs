using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSPprojectStefan
{
    public partial class ClientsForm : Form
    {
        Client client = new Client();
        public ClientsForm()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void clearFields_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxFname.Text = "";
            textBoxCountry.Text = "";
            textBoxLname.Text = "";
            textBoxPnumber.Text = "";
        }

        private void addClient_Click(object sender, EventArgs e)
        {
            String fname = textBoxFname.Text;
            String lname = textBoxLname.Text;
            String phoneNumber = textBoxPnumber.Text;
            String country = textBoxCountry.Text;

           
          
            if(fname.Trim().Equals("") || lname.Trim().Equals("") || phoneNumber.Trim().Equals("") || country.Trim().Equals("")){
                MessageBox.Show("Please fill the fields ", "Data error", MessageBoxButtons.OK, MessageBoxIcon.Error );
            
            }else{
                 Boolean InsertClient = client.insertClient(fname, lname, phoneNumber, country);
                if (InsertClient)
            {
                dataGridView1.DataSource = client.getClients();

                MessageBox.Show("Client inserted successfully ", "Add Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else {
                MessageBox.Show("Client failed to insert ", "Add Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
            }
        }

        private void ClientsForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.getClients();
        }

        private void editClient_Click(object sender, EventArgs e)
        {
            int id ;
            String fname = textBoxFname.Text;
            String lname = textBoxLname.Text;
            String phoneNumber = textBoxPnumber.Text;
            String country = textBoxCountry.Text;

            try { 
                id =  Convert.ToInt32(textBoxId.Text);
                if (fname.Trim().Equals("") || lname.Trim().Equals("") || phoneNumber.Trim().Equals("") || country.Trim().Equals(""))
                {
                    MessageBox.Show("Please fill the fields ", "Data error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    Boolean InsertClient = client.editClient(id, fname, lname, phoneNumber, country);
                    if (InsertClient)
                    {
                        dataGridView1.DataSource = client.getClients();

                        MessageBox.Show("Client updated successfully ", "Edit Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Client failed to update ", "Edit Client", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message,"ID Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxFname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxLname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxPnumber.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxCountry.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void removeClient_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxId.Text);
                if (client.deleteClient(id))
                {
                    dataGridView1.DataSource = client.getClients();

                    MessageBox.Show("Client deleted successfully ", "Delete Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("Client was not deleted ", "Delete Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }
            catch (Exception exc) {MessageBox.Show(exc.Message, "ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            textBoxId.Text = "";
            textBoxFname.Text = "";
            textBoxCountry.Text = "";
            textBoxLname.Text = "";
            textBoxPnumber.Text = "";

        }
    }
}
