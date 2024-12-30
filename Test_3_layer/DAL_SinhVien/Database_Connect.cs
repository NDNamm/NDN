using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace DAL_SinhVien
{
    public  class Database_Connect
    {
        // chuoi ket noi
        string strCon = @"Data Source=NDN;Initial Catalog=QuanLySinhVien;Integrated Security=True;TrustServerCertificate=True";

        // doi tuong ket noi
        public SqlConnection sqlCon = null;

        // ham mo ket noi
        public void MoKetNoi()
        {
            if (sqlCon == null) sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
        }

        public SqlConnection Getcon() {
            return sqlCon;
        }
    }
}
