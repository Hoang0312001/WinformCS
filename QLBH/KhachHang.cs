using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLBH
{
    class KhachHang
    {
        string makh;
        string tenkh;
        string diachi;
        public KhachHang() { }
        public KhachHang(  string makh,string tenkh,string diachi) {
            this.makh = makh;
            this.tenkh = tenkh;
            this.diachi = diachi;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-9V6MI6K;Initial Catalog=QLBH;Integrated Security=True");

        public void listview_hienthi(ListView item, String sql)
        {
            item.Items.Clear();
            DataTable dt = new DataTable();
            SqlCommand comSelect = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comSelect;
            da.Fill(dt);
            dt.AcceptChanges();
            int i = 0;
            foreach (DataRow rows in dt.Rows) {
                string makh = rows["Makh"].ToString();
                string tenkh = rows["Tenkh"].ToString();
                string diachi = rows["diachi"].ToString();
                item.Items.Add((i + 1).ToString());
                item.Items[i].SubItems.Add(makh);
                item.Items[i].SubItems.Add(tenkh);
                item.Items[i].SubItems.Add(diachi);
                i = i + 1;
            }
        }
        public void insert(KhachHang kh)
        {
            string sql = "insert into KhachHang values ('" + kh.makh + "', '" + kh.tenkh + "','" + kh.diachi + "')";
            SqlDataAdapter da= new SqlDataAdapter(sql,conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void del(KhachHang kh)
        {
            string sql = "Delete from SanPham where makh ='" + kh.makh + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void Update(KhachHang kh)
        {
            string sql = "Update SanPham set Tenkh = '" + kh.tenkh + "' , DiaChi = " + kh.diachi + " where Makh = '" + kh.makh + "'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void sort(KhachHang kh)
        {
            string sql = "select * from SanPham order by SoLuong";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public bool KT_key(string key)
        {
            bool kt = false;
            string sql = "select Masp from SanPham";
            DataTable dt = new DataTable();
            SqlCommand comSelect = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comSelect;
            da.Fill(dt);
            dt.AcceptChanges();
            foreach (DataRow row in dt.Rows)
            {
                string masp = row["Masp"].ToString();
                if (String.Compare(masp.Trim(), key.Trim(), true) == 0)
                {
                    kt = true;
                    break;
                }


            }
            return kt;
        }

    }
}
