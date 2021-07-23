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
    public partial class Form_hoadon : Form
    {
        public Form_hoadon()
        {
            InitializeComponent();
        }

        private void Form_hoadon_Load(object sender, EventArgs e)
        {
            SanPham ob = new SanPham();
            ob.Hienthi_ListView(listView1, "select * from SanPham");
            muahang ob1 = new muahang();
            ob1.HienThi_ListView(listView2, "select * from HoaDon1");

            cbmkh.DataSource = ob1.Load("select * from khachhang");
            cbmkh.DisplayMember = "MaKH";
            cbmkh.ValueMember = "MaKH";
            cbmsp.DataSource = ob1.Load("select * from SanPham");
            cbmsp.DisplayMember = "MaSP";
            cbmsp.ValueMember = "Masp";

        }

        private void cbmsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            muahang ob = new muahang();
            DataTable dt = new DataTable();
            dt = ob.Load("select DonGia from GiaSP where Masp='" + cbmsp.SelectedValue.ToString() + "'");
            foreach(DataRow row in dt.Rows){
            txtdongia.Text = row["DonGia"].ToString();
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            muahang ob = new muahang();
            string sql = "select SoLuong from SanPham where Masp='" + cbmsp.SelectedValue.ToString() + "'";
            DataTable dt = new DataTable();
            dt = ob.Load(sql);
            string soluong1 = "";
            foreach (DataRow row in dt.Rows) {
                soluong1 = row["SoLuong"].ToString();
            }
            if (Convert.ToInt32(txtsl.Text) > Convert.ToInt32(soluong1))
            {
                MessageBox.Show("Khong du so luong ban");
            }
            else {
                muahang ob1 = new muahang(txtmhd.Text, cbmkh.SelectedValue.ToString(),
                    cbmsp.SelectedValue.ToString(), Convert.ToInt32(txtsl.Text),
                    Convert.ToInt32(txtdongia.Text), Convert.ToDateTime(txtngaymua.Text));
                ob1.Insert(ob1);
                string sql1;
                int sl = Convert.ToInt32(soluong1) - Convert.ToInt32(txtsl.Text);
                sql1 = "update SanPham set soluong= " + sl + " where masp = '" + cbmsp.SelectedValue.ToString() + "'";
                ob1.Execute(sql1);
                Form_hoadon_Load(sender, e);
                
            }
        }

        private void del_Click(object sender, EventArgs e)
        {
            muahang ob = new muahang();
            string sql = "select SoLuong from SanPham where Masp='" + cbmsp.SelectedValue.ToString() + "'";
            DataTable dt = new DataTable();
            dt = ob.Load(sql);
            string soluong1 ="";
            // lay so luong san pham
            foreach (DataRow row in dt.Rows)
            {
                soluong1 =row["soluong"].ToString();
            }
            muahang ob1 = new muahang(txtmhd.Text, cbmkh.SelectedValue.ToString(),
                  cbmsp.SelectedValue.ToString(), Convert.ToInt32(txtsl.Text),
                  Convert.ToInt32(txtdongia.Text), Convert.ToDateTime(txtngaymua.Text));
            ob1.del(ob1);
            int sl = Convert.ToInt32(soluong1.ToString()) + Convert.ToInt32(txtsl.Text);
          string sql1 = "update SanPham set soluong= " + sl + " where masp = '" + cbmsp.SelectedValue.ToString() + "'";
            ob1.Execute(sql1);
            Form_hoadon_Load(sender, e);
        }
        private void update_Click(object sender, EventArgs e)
        {
            string sql = "select SoLuong from SanPham where Masp = '"+cbmsp.SelectedValue.ToString()+"'";
            muahang ob = new muahang();
            DataTable dt = new DataTable();
            dt = ob.Load(sql);
            int soluong1 = 0;
          int soluong2 =0;
            // lay so luong san pham
            foreach (DataRow row in dt.Rows)
            {
                soluong1 = Convert.ToInt32(row["SoLuong"].ToString());
            }

            /*string sql1 = "select SoLuong from HoaDon1 where MaHD ='"+txtmhd.Text+"'";
            DataTable dt2 = new DataTable();
            dt2 = ob.Load(sql1);
            foreach (DataRow row in dt2.Rows) {
                soluong2 = Convert.ToInt32(row["SoLuong"].ToString());
            } // laasy soluong cua hoadon drb
             * */
            muahang ob1 = new muahang(txtmhd.Text, cbmkh.SelectedValue.ToString(),
                 cbmsp.SelectedValue.ToString(), Convert.ToInt32(txtsl.Text),
                 Convert.ToInt32(txtdongia.Text), Convert.ToDateTime(txtngaymua.Text));
            //update so luong hoa don
            ob1.update(ob1);
            // update so luong san pham
            int sl = (soluong1 + valSoluong) - Int32.Parse(txtsl.Text);
            string sql2 = "update SanPham set SoLuong ="+sl+" where Masp = '"+cbmsp.SelectedValue.ToString()+"'"; // do công thức sai e ơi
            // giờ e muốn lấy dữ liệu nà ov
            ob1.Execute(sql2);
            sql2 = "update HoaDon1 set SoLuong ='" + Convert.ToInt32(txtsl.Text) + "' where Masp ='" + cbmsp.SelectedValue.ToString() + "'";
            ob1.Execute(sql2);
            Form_hoadon_Load(sender, e);
            // cái này phải update cả 2 bảng e. cả bảng hóa đơ nữa, dr nhung k lay dc soluong bang hoa don y

        }

        int valSoluong;

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView2.SelectedItems)
            {
                txtmhd.Text = item.SubItems[1].Text;
                cbmkh.Text = item.SubItems[2].Text;
                cbmsp.Text = item.SubItems[3].Text;
                txtsl.Text = item.SubItems[4].Text;
                txtdongia.Text = item.SubItems[5].Text;
                txtngaymua.Text = item.SubItems[6].Text;
                valSoluong = Int32.Parse(item.SubItems[4].Text); // anh lấy dc rồi nè

            }
        }


      
    }
}
