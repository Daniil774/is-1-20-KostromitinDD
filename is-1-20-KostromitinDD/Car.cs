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
using System.Reflection;

namespace is_1_20_KostromitinDD
{
    public partial class Car : Form
    {
        private Form currentChildForm;
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

            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            imgColumn.Name = "Изображени авто";
            dataGridView1.Columns.Add(imgColumn);
            Image image = new Bitmap(@"C:\Users\k36127\Downloads\logoza.ru.PNG");
            dataGridView1.Rows[0].Cells["Изображени авто"].Value = image;
            Image image1 = new Bitmap(@"C:\Users\k36127\Downloads\imgonline-com-ua-Resize-s3pwkia3TA.JPG");
            dataGridView1.Rows[1].Cells["Изображени авто"].Value = image1;
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
                this.dataGridView1.Columns["id_car"].Width = 80;
                this.dataGridView1.Columns.Add("car_name", "Название авто");
                this.dataGridView1.Columns["car_name"].Width = 165;
                this.dataGridView1.Columns.Add("car_number", "Номер авто");
                this.dataGridView1.Columns["car_number"].Width = 80;
                this.dataGridView1.Columns.Add("car_body", "Тип кузова");
                this.dataGridView1.Columns["car_body"].Width = 80;
                this.dataGridView1.Columns.Add("car_color", "Цвет авто");
                this.dataGridView1.Columns["car_color"].Width = 55;
                this.dataGridView1.Columns.Add("years_of_release", "Год выпуска");
                this.dataGridView1.Columns["years_of_release"].Width = 55;
                this.dataGridView1.Columns.Add("car_price", "Стоимость аренды авто");
                this.dataGridView1.Columns["car_price"].Width = 80;
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
            New_Entry aut = new New_Entry();
            aut.FormClosed += Update;
            aut.Show();
        }

        //кнопка на возвращение 
        public void button2_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm f = new MainForm();
            f.Show();
            f.Close();
        }

        //обновление записей
        public void button3_Click(object sender, EventArgs e)
        {
            Edit_Entry aut = new Edit_Entry();
            aut.FormClosed += Update;
            aut.Show();
        }

        //удаление из таблицы
        private void button4_Click(object sender, EventArgs e)
        {
            Delete_Entry aut = new Delete_Entry();
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

        private void DeleteTEXT_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdatetextBox_TextChanged(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

    }
}
