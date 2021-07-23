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
    public partial class Form_KH : Form
    {
        public Form_KH()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            KhachHang ob = new KhachHang(txtmkh.Text, txttenkh.Text,txtdc.Text);
            if (ob.KT_key(txtmkh.Text) == true)
            {
                MessageBox.Show("TRUNG KHOA CHINH");
            }
            else
            {
                ob.insert(ob);
                Form_KH_Load(sender, e);
            }
        }


        private void Form_KH_Load(object sender, EventArgs e)
        {
            KhachHang ob = new KhachHang();
            ob.listview_hienthi(listView1, "select * from KhachHang");

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                txtmkh.Text = item.SubItems[1].Text;
                txttenkh.Text = item.SubItems[2].Text;
                txtdc.Text = item.SubItems[3].Text;
            

            }

        }

        private void UPDATE_Click(object sender, EventArgs e)
        {
            KhachHang ob = new KhachHang(txtmkh.Text, txttenkh.Text, txtdc.Text);
            ob.Update(ob);
            Form_KH_Load(sender, e);

        }

        private void DEL_Click(object sender, EventArgs e)
        {
            KhachHang ob = new KhachHang(txtmkh.Text, txttenkh.Text, txtdc.Text);
            ob.del(ob);
            Form_KH_Load(sender, e);
        }

        private void RESET_Click(object sender, EventArgs e)
        {
            txtmkh.Text = "";
            txttenkh.Text = "";
            txtdc.Text = "";

        }

    
    }
}
