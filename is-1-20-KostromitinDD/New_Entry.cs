﻿using MySql.Data.MySqlClient;
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
    public partial class New_Entry : Form
    {
        string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
        //string connStr = "server=10.90.12.110;port=33333;user=st_1_20_17;database=is_1_20_st17_KURS;password=32424167;";
        MySqlConnection conn;
        public New_Entry()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            string sql = $"INSERT INTO Cars(id_car, car_name)" + $"VALUES ('{login}', '{password}')";
            conn.Open();
            MySqlCommand command = new MySqlCommand(sql, conn);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Авто успешно добавлено.");
        }

        private void New_Entry_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection(connStr);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
