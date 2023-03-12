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

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        private object connection;

        public Form3()
        {
            InitializeComponent();
        }

        private readonly string connectionString = "server=localhost;port=3306;username=root;password=root;database=Auth";

        private void button1_Click(object sender, EventArgs e)
        {
            {
                String username = textBox1.Text;
                String secretWord = textBox2.Text;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM user WHERE login=@username AND secret_word=@secret_word", connection);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@secret_word", secretWord);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string password = reader.GetString("password");
                            MessageBox.Show("Your password is: " + password);
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or secret word");
                        }
                    }
                }
            }
        }
    }
}







