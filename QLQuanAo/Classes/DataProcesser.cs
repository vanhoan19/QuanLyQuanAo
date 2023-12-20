using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQuanAo.Classes
{
    public class DataProcesser
    {
        string Conectstr = "Data Source=(local);Initial Catalog=QuanLyQuanAo;Integrated Security=True";
        SqlConnection sqlConnect = null;
        //PT mở kets nối
        public void OpenConnect()
        {
            sqlConnect = new SqlConnection(Conectstr);
            if (sqlConnect.State != ConnectionState.Open)
            {
                sqlConnect.Open();
            }
        }
        //PT đóng kết nối
        public void CloseConnect()
        {
            if (sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
                sqlConnect.Dispose();
            }
        }
        //PT đọc dữ liệu:
        //Phương thức thực thi câu lệnh Select trả về một DataTable
        public DataTable ReadData(string sqlSelect)
        {
            DataTable dt = new DataTable();
            OpenConnect();
            SqlDataAdapter dtAdapter = new SqlDataAdapter(sqlSelect, sqlConnect);
            dtAdapter.Fill(dt);
            CloseConnect();
            dtAdapter.Dispose();
            return dt;
        }
        //PT Cập nhật dữ liệu(thêm, sửa xóa)
        public void ChangeData(string sql)
        {
            OpenConnect();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnect;
            sqlCommand.CommandText = sql;
            sqlCommand.ExecuteNonQuery();
            CloseConnect();
            sqlCommand.Dispose();
        }
    }
}
