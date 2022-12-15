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
using System.Data.SqlClient;
using System.Drawing.Drawing2D;

namespace is_1_20_KostromitinDD
{
    public partial class Staff : Form
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
        public Staff()
        {
            InitializeComponent();
            select();
        }
        private void Staff_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            //закругление
            this.Region = new Region(RoundedRect(new Rectangle(0, 0, this.Width, this.Height), 10));

            dataGridView1.RowHeadersVisible = false;

            panel1.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            New_Staff NS = new New_Staff();
            NS.FormClosed += Update;
            NS.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit_Staff aut = new Edit_Staff();
            aut.FormClosed += Update;
            aut.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete_Staff aut = new Delete_Staff();
            aut.FormClosed += Update;
            aut.Show();
        }

        //кнопка на возвращение в mainform
        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            MainForm f = new MainForm();
            f.Show();
            f.Close();
        }

        //заполнение DataGridView
        public void select()
        {
            DataSet ds;
            ds = new DataSet();
            string connectionString = "server=chuc.caseum.ru;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            MySqlCommand command = new MySqlCommand();
            string commandString = "SELECT * FROM Staff;";
            command.CommandText = commandString;
            command.Connection = connection;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView1.Columns.Add("id_employee", "Номер сотрудника");
                this.dataGridView1.Columns["id_employee"].Width = 80;
                this.dataGridView1.Columns.Add("fio_employee", "ФИО сотрудника");
                this.dataGridView1.Columns["fio_employee"].Width = 175;
                this.dataGridView1.Columns.Add("employee_position", "Должность сотрудника");
                this.dataGridView1.Columns["employee_position"].Width = 135;
                this.dataGridView1.Columns.Add("login_employee", "Логин сотрудника");
                this.dataGridView1.Columns["login_employee"].Width = 80;
                this.dataGridView1.Columns.Add("access_level", "Уровень доступа");
                this.dataGridView1.Columns["access_level"].Width = 80;
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["id_employee"].ToString(), reader["fio_employee"].ToString(), reader["employee_position"].ToString()
                        , reader["login_employee"].ToString(), reader["access_level"].ToString());
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
            string commandString = "SELECT * FROM Staff;";
            command.CommandText = commandString;
            command.Connection = connection;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["id_employee"].ToString(), reader["fio_employee"].ToString(), reader["employee_position"].ToString()
                        , reader["login_employee"].ToString(), reader["access_level"].ToString());
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


        //вывод изображения и данных о авто в pictureBox и textBox
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            conn.Open();
            int id = dataGridView1.SelectedCells[0].RowIndex + 1;
            string url = $"SELECT photo_staff FROM Staff WHERE id_employee = {id}";
            MySqlCommand com = new MySqlCommand(url, conn);
            string name = com.ExecuteScalar().ToString();
            conn.Close();
            pictureBox1.ImageLocation = $"{name}";
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            panel1.Show();
            int index = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows[index].Selected = true;
        }
    }
}
