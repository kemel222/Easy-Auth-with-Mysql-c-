using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            

            {
                this.Hide();
                var Form2 = new Form2();
                var result = Form2.ShowDialog();
            }

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string loginUser = LoginPole.Text;
            string passUser = PassPole.Text;
            DB db = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            using (MySqlConnection connection = new MySqlConnection(db.GetConnection().ConnectionString))

            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM users WHERE username = @uL AND password = @uP", connection);
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

                connection.Open();
                adapter.SelectCommand = command;
                NewMethod(table, adapter);
                connection.Close();
            }

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Yes");
            }
            else
            {
                MessageBox.Show("No");
            }
        }

        private static void NewMethod(DataTable table, MySqlDataAdapter adapter)
        {
            var v = adapter.Fill(table);
            _ = v;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var Form3 = new Form3();
            var result = Form3.ShowDialog();

        }
    }
}





