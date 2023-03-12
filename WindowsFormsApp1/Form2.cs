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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя пользователя.");
                return;
            }
            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите пароль.");
                return;
            }
            if (PasswordTextBox.Text != ConfirmPasswordTextBox.Text)
            {
                MessageBox.Show("Пароли не совпадают.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Пожалуйста, введите секретное слово.");
                return;
            }
            // Сохранение пользователя в базе данных
            try
            {
                // настройки подключения к mySQL
                string connectionString = "server=localhost;port=3306;username=root;password=root;database=Auth;";
                MySqlConnection connection = new MySqlConnection(connectionString);

                // Открытие соединения с базой данных:
                connection.Open();

                string query = "INSERT INTO user (login, password, secret_word) VALUES (@name, @password, @secretWord)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", UsernameTextBox.Text);
                command.Parameters.AddWithValue("@password", PasswordTextBox.Text);
                command.Parameters.AddWithValue("@secretWord", textBox1.Text);

                // Выполнение SQL-команды:
                command.ExecuteNonQuery();

                // Закрытие соединения с базой данных:
                connection.Close();

                MessageBox.Show("Пользователь успешно зарегистрирован! Секретное слово: " + textBox1.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при регистрации пользователя: " + ex.Message);

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
        }


