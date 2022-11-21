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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;


namespace is_1_20_KostromitinDD
{
    public partial class Car : Form
    {
        SqlCommand Command;
        SqlDataAdapter Adapter;
        SqlCommandBuilder Builder;
        DataSet Ds;
        DataTable Table;

        public Car()
        {
            InitializeComponent();
            select();
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
                    dataGridView1.Rows.Add(reader["car_name"].ToString(), reader["car_number"].ToString(), reader["car_body"].ToString(),
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void button2_Click(object sender, EventArgs e)
        {
            MainForm f2 = new MainForm();              //кнопка на возвращение окна авторизации
            f2.FormClosed += formClosed;
            this.Close();
        }
        void formClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void Car_Load(object sender, EventArgs e)
        {
        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить эту запись?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)

            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        public void button3_Click(object sender, EventArgs e)
        {
           
        }

    }
}
