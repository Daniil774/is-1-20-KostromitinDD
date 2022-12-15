using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;
using Xceed.Words.NET;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace is_1_20_KostromitinDD
{
    public partial class Dogovor : Form
    {
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
        //string connStr = "server=10.90.12.110;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";

        MySqlConnection conn;
        public Dogovor()
        {
            InitializeComponent();
            Cars();
            Clients();
        }

        private void Dogovor_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            //закругление
            this.Region = new Region(RoundedRect(new Rectangle(0, 0, this.Width, this.Height), 10));
            dataGridView2.RowHeadersVisible = false;
            dataGridView3.RowHeadersVisible = false;
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

        string gpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"/Dogovor";

        private void button1_Click(object sender, EventArgs e)
        {
            //работает на половину
            //string userMessage = "";
            //DocX obj = DocX.Create(gpath);
            //obj.InsertParagraph(userMessage);
            //obj.Save();
            //Process.Start("Notepad.exe", gpath);

            //неработает
            //string userMessage = "";
            //DocX obj = DocX.Create(gpath);
            //obj.InsertParagraph(userMessage);
            //obj.Save();
            //Process.Start("Notepad.exe", gpath);
            //
            //  using (StreamWriter sw = new StreamWriter(userMessage))
            //  {
            //      sw.WriteLine(textBox2.Text);
            //      sw.WriteLine(textBox3.Text);
            //      sw.WriteLine(textBox4.Text);
            //      sw.Close();
            //  }

            //неработает
            //try
            //{
            //    //Pass the filepath and filename to the StreamWriter Constructor
            //    StreamWriter sw = new StreamWriter("C:\\Users\\danii\\OneDrive\\MyDocuments\\Dogovor.txt");
            //    //Write a line of text
            //    sw.WriteLine(textBox2.Text);
            //    //Write a second line of text
            //    sw.WriteLine(textBox3.Text);
            //    //Close the file
            //    sw.Close();
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Exception: ");
            //}
            //finally
            //{
            //    Console.WriteLine("Executing finally block.");
            //}
            DocX obj = DocX.Create(gpath);
            Process.Start("Notepad.exe", gpath);

        }
        //заполнение DataGridView
        public void Cars()
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
                this.dataGridView3.Columns.Add("id_car", "Парковочное место");
                this.dataGridView3.Columns["id_car"].Width = 90;
                this.dataGridView3.Columns.Add("car_name", "Название авто");
                this.dataGridView3.Columns["car_name"].Width = 165;
                this.dataGridView3.Columns.Add("car_number", "Номер авто");
                this.dataGridView3.Columns["car_number"].Width = 80;
                this.dataGridView3.Columns.Add("car_body", "Тип кузова");
                this.dataGridView3.Columns["car_body"].Width = 80;
                this.dataGridView3.Columns.Add("car_color", "Цвет авто");
                this.dataGridView3.Columns["car_color"].Width = 60;
                this.dataGridView3.Columns.Add("years_of_release", "Год выпуска");
                this.dataGridView3.Columns["years_of_release"].Width = 60;
                this.dataGridView3.Columns.Add("car_price", "Стоимость аренды авто");
                this.dataGridView3.Columns["car_price"].Width = 85;
                while (reader.Read())
                {
                    dataGridView3.Rows.Add(reader["id_car"].ToString(), reader["car_name"].ToString(), reader["car_number"].ToString(), reader["car_body"].ToString(),
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
        public void Clients()
        {
            DataSet ds;
            ds = new DataSet();
            string connectionString = "server=chuc.caseum.ru;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand command = new MySqlCommand();
            string commandString = "SELECT * FROM Client;";
            command.CommandText = commandString;
            command.Connection = connection;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView2.Columns.Add("fio_client", "ФИО клиента");
                this.dataGridView2.Columns["fio_client"].Width = 90;
                this.dataGridView2.Columns.Add("passport_number", "Номер паспорта");
                this.dataGridView2.Columns["passport_number"].Width = 165;
                this.dataGridView2.Columns.Add("phone_number", "Номер телефона");
                this.dataGridView2.Columns["phone_number"].Width = 80;
                while (reader.Read())
                {
                    dataGridView2.Rows.Add(reader["fio_client"].ToString(), reader["passport_number"].ToString(), reader["phone_number"].ToString());
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

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            conn.Open();
            int id = dataGridView2.SelectedCells[0].RowIndex + 1;
            string url = $"SELECT photo_client FROM Client WHERE id_client = {id}";
            MySqlCommand com = new MySqlCommand(url, conn);
            string name = com.ExecuteScalar().ToString();
            conn.Close();
            pictureBox1.ImageLocation = $"{name}";
            textBox2.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString(); 
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            conn.Open();
            int id = dataGridView3.SelectedCells[0].RowIndex + 1;
            string url = $"SELECT photo_car FROM Cars WHERE id_car = {id}";
            MySqlCommand com = new MySqlCommand(url, conn);
            string name = com.ExecuteScalar().ToString();
            conn.Close();
            pictureBox2.ImageLocation = $"{name}";
            textBox5.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            textBox6.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            textBox7.Text = dataGridView3.CurrentRow.Cells[3].Value.ToString();
            textBox8.Text = dataGridView3.CurrentRow.Cells[4].Value.ToString();
            textBox9.Text = dataGridView3.CurrentRow.Cells[5].Value.ToString();
            textBox10.Text = dataGridView3.CurrentRow.Cells[6].Value.ToString();
        }
    }
}
