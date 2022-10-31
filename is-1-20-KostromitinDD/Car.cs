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


namespace is_1_20_KostromitinDD
{
    public partial class Car : MetroFramework.Forms.MetroForm
    {
        enum Row
        {
            Existed,
            New,
            Modified,
            ModifiedNew,
            Deleted
        }
       

        public Car()
        {
            InitializeComponent();
        }

        private void CreateColumns()
        {
            dataGridView1.Columns.Add("id_car", "id_car");
            dataGridView1.Columns.Add("car_name", "Название авто");
            dataGridView1.Columns.Add("car_number", "Номер авто");
            dataGridView1.Columns.Add("car_body", "Тип кузова");
            dataGridView1.Columns.Add("car_color", "Цвет авто");
            dataGridView1.Columns.Add("years_of_release", "Год выпуска авто");
            dataGridView1.Columns.Add("car_price", "Стоимость аренды");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4),
                record.GetString(5), record.GetString(6), Row.ModifiedNew);
        }

        private void RedreshDataGrid(DataGridView dgv)
        {
            dgv.Rows.Clear();

            string queryString = $"Select * From Cars";

            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm f2 = new MainForm();              //кнопка на возвращение окна авторизации
            f2.FormClosed += formClosed;
            this.Hide();
            f2.Show();
        }
        void formClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void Car_Load(object sender, EventArgs e)
        {

        }
        private void GetList(int id_stud)
        {
            
        }
    }
}
