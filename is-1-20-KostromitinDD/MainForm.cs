using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace is_1_20_KostromitinDD
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
         

            if(Auth.auth)
            {
                this.Show();
                label1.Text = $"Добро пожаловать, {Auth.auth_fio}";
                label1.ForeColor = Color.Black;
            }
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.StartPosition = FormStartPosition.Manual;
            ifrm.Left = this.Left;
            ifrm.Top = this.Top;
            ifrm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Car dlg = new Car();
            dlg.Show(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();              //кнопка на возвращение окна авторизации
            f2.FormClosed += formClosed;
            this.Close();
            
        }
        void formClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        
    }
}
