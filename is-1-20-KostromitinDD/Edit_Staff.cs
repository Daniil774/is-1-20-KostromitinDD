﻿using MySql.Data.MySqlClient;
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
    public partial class Edit_Staff : Form
    {
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
        //string connStr = "server=10.90.12.110;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
        MySqlConnection conn;
        public Edit_Staff()
        {
            InitializeComponent();
        }

        private void Edit_Staff_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string tb = textBox1.Text;
            string tb3 = textBox2.Text;
            string sql = $"UPDATE Staff SET id_employee = {tb3} WHERE id_employee = {tb}";
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            //обновление dataGridView
            Update();
            MessageBox.Show("Данные сотрудника успешно обновлены.");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
