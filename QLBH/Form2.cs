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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SanPham ob = new SanPham();
            ob.Hienthi_ListView(listView1, "select * from SanPham");
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                txtmasp.Text = item.SubItems[1].Text;
                txttensp.Text = item.SubItems[2].Text;
                txtsoluong.Text = item.SubItems[3].Text;
                txtdongia.Text = item.SubItems[4].Text;

            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            SanPham ob = new SanPham(txtmasp.Text, txttensp.Text, Int32.Parse(txtsoluong.Text), Int32.Parse(txtdongia.Text));
            if (ob.KT_key(txtmasp.Text) == true)
            {
                MessageBox.Show("TRUNG KHOA CHINH");
            }
            else{
                ob.Insert(ob);
            Form2_Load(sender, e);
            }

        }

      

        private void sua_Click(object sender, EventArgs e)
        {
            SanPham ob = new SanPham(txtmasp.Text, txttensp.Text, Int32.Parse(txtsoluong.Text), Int32.Parse(txtdongia.Text));
                ob.Update(ob);
                Form2_Load(sender, e);
            

        }

        private void del_Click(object sender, EventArgs e)
        {
            SanPham ob = new SanPham(txtmasp.Text, txttensp.Text, Int32.Parse(txtsoluong.Text), Int32.Parse(txtdongia.Text));
            ob.del(ob);
            Form2_Load(sender, e);
            
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            SanPham ob = new SanPham();
            txtmasp.Text = "";
            txttensp.Text = "";
            txtdongia.Text = "";
            txtsoluong.Text = "";
        }

     


     
    }
}
