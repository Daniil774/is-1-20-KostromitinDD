using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.IO;

namespace is_1_20_KostromitinDD
{
    public partial class Car : Form
    {
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
        //string connStr = "server=10.90.12.110;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";

        MySqlConnection conn;

        //хеширование
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
            this.Region = new Region(RoundedRect(new Rectangle(0, 0, this.Width, this.Height), 10));
            dataGridView1.RowHeadersVisible = false;

            panel1.Hide();
        }

        //заполнение DataGridView
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
                this.dataGridView1.Columns.Add("id_car", "Парковочное место");
                this.dataGridView1.Columns["id_car"].Width = 90;
                this.dataGridView1.Columns.Add("car_name", "Название авто");
                this.dataGridView1.Columns["car_name"].Width = 165;
                this.dataGridView1.Columns.Add("car_number", "Номер авто");
                this.dataGridView1.Columns["car_number"].Width = 80;
                this.dataGridView1.Columns.Add("car_body", "Тип кузова");
                this.dataGridView1.Columns["car_body"].Width = 80;
                this.dataGridView1.Columns.Add("car_color", "Цвет авто");
                this.dataGridView1.Columns["car_color"].Width = 60;
                this.dataGridView1.Columns.Add("years_of_release", "Год выпуска");
                this.dataGridView1.Columns["years_of_release"].Width = 60;
                this.dataGridView1.Columns.Add("car_price", "Стоимость аренды авто");
                this.dataGridView1.Columns["car_price"].Width = 85;
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["id_car"].ToString(), reader["car_name"].ToString(), reader["car_number"].ToString(), reader["car_body"].ToString(),
                        reader["car_color"].ToString(), reader["years_of_release"].ToString(), reader["car_price"].ToString());
                }
                reader.Close();
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

        //добавление в таблицу
        private void button1_Click(object sender, EventArgs e)
        {
            New_Car aut = new New_Car();
            aut.FormClosed += Update;
            aut.Show();
        }

        //кнопка на возвращение в mainform
        public void button2_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm f = new MainForm();
            f.Show();
            f.Close();
        }

        //редактирование записей
        public void button3_Click(object sender, EventArgs e)
        {
            Edit_Car aut = new Edit_Car();
            aut.FormClosed += Update;
            aut.Show();
        }

        //удаление из таблицы
        private void button4_Click(object sender, EventArgs e)
        {
            Delete_Car aut = new Delete_Car();
            aut.FormClosed += Update;
            aut.Show();
        }

        //обновление DataGridView
        void reload_list()
        {
            dataGridView1.Rows.Clear();
            readnig();
        }
      
        void Update(object sender, FormClosedEventArgs e)
        {
            reload_list();
        }

        //метод получения записей, который вновь заполнит таблицу
        void readnig()
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
            }
            catch 
            {
                command.Connection.Close();
            }
        }

        //закругление
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

        //выделение всей строки
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Selected = true;
        }

        //вывод изображения и данных о авто в pictureBox и textBox
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            conn.Open();
            int id = dataGridView1.SelectedCells[0].RowIndex + 1;
            string url = $"SELECT photo_car FROM Cars WHERE id_car = {id}";
            MySqlCommand com = new MySqlCommand(url, conn);
            string name = com.ExecuteScalar().ToString();
            conn.Close();
            pictureBox1.ImageLocation = $"{name}";
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            panel1.Show();
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
