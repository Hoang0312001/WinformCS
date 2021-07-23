using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLBH
{
    class muahang
    {
        string makh, mahd, masp;
        int soluong;
        int dongia;
        DateTime ngaymua;
        public muahang()
        {

        }
        public muahang( string makh, string mahd, string masp,int soluong,int dongia,DateTime ngaymua)
        {
            this.mahd = mahd;
            this.makh = makh;
            this.masp = masp;
            this.soluong = soluong;
            this.dongia = dongia;
            this.ngaymua=ngaymua;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-9V6MI6K;Initial Catalog=QLBH;Integrated Security=True");
        public void HienThi_ListView(ListView item, string sql)
        {
            item.Items.Clear();
            DataTable dt = new DataTable();
            SqlCommand comSelect = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comSelect;
            da.Fill(dt);
            dt.AcceptChanges();
            int i = 0;
            foreach (DataRow row in dt.Rows) {
                string makh = row["MaKH"].ToString();
                string mahd = row["Mahd"].ToString();
                string masp = row["Masp"].ToString();
                string soluong = row["SoLuong"].ToString();
                string dongia = row["DonGia"].ToString();
                string ngaymua = row["NgayMua"].ToString();
                item.Items.Add((i + 1).ToString());
                item.Items[i].SubItems.Add(makh);
                item.Items[i].SubItems.Add(mahd);
                item.Items[i].SubItems.Add(masp);
                item.Items[i].SubItems.Add(soluong);
                item.Items[i].SubItems.Add(dongia);
                item.Items[i].SubItems.Add(ngaymua);
                i = i + 1;
            }

        }
        public DataTable Load(string sql) {
            DataTable dt = new DataTable();
            SqlCommand comSelect = new SqlCommand(sql, conn);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = comSelect;
            da.Fill(dt);
            dt.AcceptChanges();
            return dt;
        }
        public void Insert(muahang ob) {
            string sql = sql = "insert into [HoaDon1] values('"+ob.mahd+"','"+ob.makh+"','"+ob.masp+"',"+ob.soluong+","+ob.dongia+",'"+ob.ngaymua+"')";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void del(muahang ob)
        {
            string sql = sql = "delete from HoaDon1 where MaHD = '"+ob.mahd+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void update(muahang ob)
        {
            string sql = sql = "update HoaDon1 set MaKH = '"+ob.makh+"',MaSP = '"+ob.masp+"', SoLuong = "+ob.soluong+", DonGia ="+ob.dongia+" , NgayMua = '"+ob.ngaymua+"' where MaHD = '"+ob.mahd+"'";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
        public void Execute(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            da.Update(dt);
            dt.AcceptChanges();
        }
    }
}
