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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public void ManagerRole(string role)
        {
            switch (role)
            {
                //И в зависимости от того, какая роль (цифра) хранится в поле класса и передана в метод, показываются те или иные кнопки.
                //Вы можете скрыть их и не отображать вообще, здесь они просто выключены
                case "Начальник гаража":
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button3.Enabled = false;
                    button4.Enabled = true;
                    break;

                case "Директор":
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    break;

                case "Директор по персоналу":
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    break;

                case "Младший менеджер":
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button3.Enabled = false;
                    button4.Enabled = true;
                    break;
            }
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            if (Auth.auth)
            {
                this.Show();
                label1.Text = $"Добро пожаловать, {Auth.auth_fio}";
                label1.ForeColor = Color.Black;
                ManagerRole(Auth.auth_role);
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
