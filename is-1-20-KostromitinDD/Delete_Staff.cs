using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_1_20_KostromitinDD
{
    public partial class Delete_Staff : Form
    {
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
        //string connStr = "server=10.90.12.110;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
        MySqlConnection conn;
        public Delete_Staff()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tb = textBox1.Text;
            string sql = $"DELETE FROM Staff WHERE id_employee = {tb}";
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            //обновление DataGridView
            Update();
            MessageBox.Show("Сотрудник удалён.");
        }

        private void Delete_Staff_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
            //перемещение формы
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
        }
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
    }
}
