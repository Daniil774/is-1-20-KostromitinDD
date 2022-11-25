using MySql.Data.MySqlClient;
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
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace is_1_20_KostromitinDD
{
    public partial class Car : Form
    {
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
        //string connStr = "server=10.90.12.110;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";

        MySqlConnection conn;

        static string sha256(string randomString)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(randomString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }

        public Car()
        {
            InitializeComponent();
            select();
        }
        private void Car_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            //закругление
            this.Region = new Region(RoundedRect(new Rectangle(0, 0, this.Width, this.Height),10));
        }
        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            reload_list();
        }

        public void select()
        {
            DataSet ds;
            ds = new DataSet();
            string connectionString = "server=chuc.caseum.ru;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand command = new MySqlCommand();
            string commandString = "SELECT * FROM Cars;";
            command.CommandText = commandString;
            command.Connection = connection;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView1.Columns.Add("id_car", "ид авто");
                this.dataGridView1.Columns["id_car"].Width = 80;
                this.dataGridView1.Columns.Add("car_name", "Название авто");
                this.dataGridView1.Columns["car_name"].Width = 165;
                this.dataGridView1.Columns.Add("car_number", "Номер авто");
                this.dataGridView1.Columns["car_number"].Width = 80;
                this.dataGridView1.Columns.Add("car_body", "Тип кузова");
                this.dataGridView1.Columns["car_body"].Width = 80;
                this.dataGridView1.Columns.Add("car_color", "Цвет авто");
                this.dataGridView1.Columns["car_color"].Width = 80;
                this.dataGridView1.Columns.Add("years_of_release", "Год выпуска");
                this.dataGridView1.Columns["years_of_release"].Width = 80;
                this.dataGridView1.Columns.Add("car_price", "Стоимость аренды авто");
                this.dataGridView1.Columns["car_price"].Width = 80;
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["id_car"].ToString(), reader["car_name"].ToString(), reader["car_number"].ToString(), reader["car_body"].ToString(),
                        reader["car_color"].ToString(), reader["years_of_release"].ToString(), reader["car_price"].ToString());
                }
                reader.Close();
                dataGridView1.AllowUserToAddRows = false;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //добавление в таблицу
            New_Entry aut = new New_Entry();
            aut.FormClosed += Update;
            aut.Show();
        }
        void Update(object sender, FormClosedEventArgs e)
        {
            reload_list();
        }
        void Update12()
        {
            DataSet ds;
            ds = new DataSet();
            string connectionString = "server=chuc.caseum.ru;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand command = new MySqlCommand();
            string commandString = "SELECT * FROM Cars;";
            command.CommandText = commandString;
            command.Connection = connection;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["id_car"].ToString(), reader["car_name"].ToString(), reader["car_number"].ToString(), reader["car_body"].ToString(),
                        reader["car_color"].ToString(), reader["years_of_release"].ToString(), reader["car_price"].ToString());
                }
                reader.Close();
                dataGridView1.AllowUserToAddRows = false;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: \r\n{0}", ex.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            //кнопка на возвращение 
            MainForm f2 = new MainForm();             
            f2.FormClosed += formClosed;
            this.Close();    
        }
      
        void formClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        public void button3_Click(object sender, EventArgs e)
        {
            //обновление записей
            string tb = UpdatetextBox.Text;
            string tb3 = textBox3.Text;
            string sql = $"UPDATE Cars SET id_car = {tb3} WHERE id_car = {tb}";
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            //обновление dataGridView
            reload_list();
            MessageBox.Show("Данные автомобиля успешно обновлены.");           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //удаление из таблицы
            string tb = DeleteTEXT.Text;
            string sql = $"DELETE FROM Cars WHERE id_car = {tb}";
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            //обновление dataGridView
            reload_list();
            MessageBox.Show("Авто удалено.");
        }

        public void reload_list()
        {
            dataGridView1.Rows.Clear();
            Update12();
        }
        public static GraphicsPath RoundedRect(Rectangle baseRect, int radius)
        {
            var diameter = radius * 2;
            var sz = new Size(diameter, diameter);
            var arc = new Rectangle(baseRect.Location, sz);
            var path = new GraphicsPath();

            // Верхний левый угол
            path.AddArc(arc, 180, 90);

            // Верхний правый угол
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Нижний правый угол
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Нижний левый угол
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }


        private void DeleteTEXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdatetextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
