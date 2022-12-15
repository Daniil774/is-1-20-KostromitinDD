using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace is_1_20_KostromitinDD
{
    public partial class New_Car : Form
    {
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
        //string connStr = "server=10.90.12.110;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
        MySqlConnection conn;
        public New_Car()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tb1 = textBox1.Text;
            string tb2 = textBox2.Text;
            string tb3 = textBox3.Text;
            string tb4 = textBox4.Text;
            string tb5 = textBox5.Text;
            string tb6 = textBox6.Text;
            string tb7 = textBox7.Text;
            string tb8 = textBox8.Text;
            string sql = $"INSERT INTO Cars(id_car, car_name, car_number, car_body, car_color, years_of_release, car_price, photo_car)"
                + $"VALUES ('{tb1}', '{tb2}', '{tb3}', '{tb4}', '{tb5}', '{tb6}', '{tb7}', '{tb8}')";
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            Update();
            MessageBox.Show("Авто успешно добавлено.");
        }
        private void New_Entry_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            //перемещение формы
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
        }

        //перемещение формы
        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
