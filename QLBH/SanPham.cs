using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace QLBH
{
    class SanPham
    {
        string masp, tensp;
        int soluong;
        int dongia;
        public SanPham() { }
        public SanPham(string masp, string tensp, int soluong, int dongia)
        {
            this.masp = masp;
            this.tensp = tensp;
            this.soluong = soluong;
            this.dongia = dongia;
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-9V6MI6K;Initial Catalog=QLBH;Integrated Security=True");
        public void Hienthi_ListView(ListView item, string sql)
        {
            item.Items.Clear();
            DataTable dt = new DataTable();
            SqlCommand comSelect = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comSelect;
            da.Fill(dt);
            dt.AcceptChanges();
            int i = 0;

            foreach (DataRow row in dt.Rows)
            {
                string masp = row["Masp"].ToString();
                string tensp = row["Tensp"].ToString();
                string soluong = row["SoLuong"].ToString();
                string dongia = row["DonGia"].ToString();
                item.Items.Add((i + 1).ToString());
                item.Items[i].SubItems.Add(masp);
                item.Items[i].SubItems.Add(tensp);
                item.Items[i].SubItems.Add(soluong);
                item.Items[i].SubItems.Add(dongia);
                i = i + 1;


            }
        }

        public void Insert(SanPham sp)
        {
            string sql = "insert into SanPham values('" + sp.masp + "', '" + sp.tensp + "' , " + sp.soluong + ", " + sp.dongia + ")";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void Update(SanPham sp) { 
        string sql = "Update SanPham set Tensp = '"+sp.tensp+"' , DonGia= "+sp.dongia+", SoLuong = "+sp.soluong+" where Masp = '"+sp.masp+"'" ;
             SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void del(SanPham sp)
        {
            string sql ="Delete from SanPham where masp ='"+sp.masp+"'";
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