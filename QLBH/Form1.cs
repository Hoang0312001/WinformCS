using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLBH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bảngSảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 ob = new Form2();
            ob.Show();
        }

     

        private void bảngKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_KH kh = new Form_KH();
            kh.Show();
        }

        private void bảngHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_hoadon hd = new Form_hoadon();
            hd.Show();
        }

     
    }
}
