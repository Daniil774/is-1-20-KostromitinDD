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
        private Form currentChildForm;
        public MainForm()
        {
            InitializeComponent();
        }


        public void ManagerRole(string role)
        {
            switch (role)
            {
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

                case "Начальник по персоналу":
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
                label1.Text = $"ФИО: {Auth.auth_fio}";
                ManagerRole(Auth.auth_role);
                label2.Text = $"Должность: { Auth.auth_role }";
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            openSecondForminForm(new Dogovor());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openSecondForminForm(new Car());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openSecondForminForm(new Staff());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Открытие формы на panel3
        private void openSecondForminForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //Конец
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;// свернуть
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }
    }
}
