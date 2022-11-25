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

namespace is_1_20_KostromitinDD
{
    public partial class Staff : Form
    {
        public Staff()
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
            string commandString = "SELECT * FROM Staff;";
            command.CommandText = commandString;
            command.Connection = connection;
            MySqlDataReader reader;
            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                this.dataGridView1.Columns.Add("fio_employee", "ФИО сотрудника");
                this.dataGridView1.Columns["fio_employee"].Width = 175;
                this.dataGridView1.Columns.Add("employee_position", "Должность сотрудника");
                this.dataGridView1.Columns["employee_position"].Width = 135;
                this.dataGridView1.Columns.Add("login_employee", "Логин сотрудника");
                this.dataGridView1.Columns["login_employee"].Width = 80;

                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["fio_employee"].ToString(), reader["employee_position"].ToString(), reader["login_employee"].ToString());
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
    }
}
