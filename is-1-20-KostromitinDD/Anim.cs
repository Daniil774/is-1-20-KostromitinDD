﻿using System;
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
    public partial class Anim : Form
    {
        public Anim()
        {
            InitializeComponent();
        }

        private void Anim_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Bitmap.FromFile(Application.StartupPath + @"\load-loading.gif");
        }
    }
}
