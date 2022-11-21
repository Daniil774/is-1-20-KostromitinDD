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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Регистрация_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f = new Form1();
            f.FormClosed += formClosed;
            this.Close();
        }
        void formClosed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

    }
    
}
