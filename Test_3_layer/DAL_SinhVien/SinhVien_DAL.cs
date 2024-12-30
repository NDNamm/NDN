using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO_SinhVien;

namespace DAL_SinhVien
{
    public class SinhVien_DAL
    {
        Database_Connect Database_Connect = new Database_Connect();
        // ham doc du lieu tu csdl
        public List<SinhVien> LoadSv()
        {
            // mo ket noi
            Database_Connect.MoKetNoi();

            List<SinhVien> ds_tho = new List<SinhVien>();
            string query = "Select * from SinhVien";

            using (SqlCommand cmd = new SqlCommand(query, Database_Connect.Getcon()))
            {
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    SinhVien sinhVien = new SinhVien()
                    {
                        MaSV = reader["MaSV"].ToString(),
                        TenSV = reader["TenSv"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        NgaySinh=Convert.ToDateTime(reader["NgaySinh"]),
                        QueQuan = reader["QueQuan"].ToString(),
                        MaLop = reader["MaLop"].ToString()

                    };
                    ds_tho.Add(sinhVien);
                }
            } 
            return ds_tho;

        }

        public bool themSv(SinhVien_Clean sinhVien_Clean)
        {
            Database_Connect.MoKetNoi();

            string query = "INSERT INTO SinhVien(MaSv, TenSv, GioiTinh, NgaySinh, QueQuan, MaLop)" +
                "VALUES(@masv, @tensv, @gt, @ngaysinh, @que, @malop)";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, Database_Connect.Getcon()))
                {

                    cmd.Parameters.AddWithValue("@masv", sinhVien_Clean.MaSV_Clean);
                    cmd.Parameters.AddWithValue("@tensv", sinhVien_Clean.TenSV_Clean);
                    cmd.Parameters.AddWithValue("@gt", sinhVien_Clean.GioiTinh_Clean);
                    cmd.Parameters.AddWithValue("@ngaysinh", sinhVien_Clean.NgaySinh_Clean);
                    cmd.Parameters.AddWithValue("@que", sinhVien_Clean.QueQuan_Clean);
                    cmd.Parameters.AddWithValue("@malop", sinhVien_Clean.MaLop_Clean);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
            return true;
            
        }

        public List<SinhVien> timKiemMa(string masv)
        {
            Database_Connect.MoKetNoi();
            List<SinhVien> ds_tho = new List<SinhVien>();
            string query = "Select * from SinhVien where MaSV Like @masv";

            using (SqlCommand cmd = new SqlCommand(query, Database_Connect.Getcon()))
            {
                cmd.Parameters.AddWithValue("@masv", "%" + masv + "%");
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    SinhVien sinhVien = new SinhVien()
                    {
                        MaSV = reader["MaSV"].ToString(),
                        TenSV = reader["TenSv"].ToString(),
                        GioiTinh = reader["GioiTinh"].ToString(),
                        NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
                        QueQuan = reader["QueQuan"].ToString(),
                        MaLop = reader["MaLop"].ToString()

                    };
                    ds_tho.Add(sinhVien);
                }
                
            }return ds_tho;
            
        }



        //public List<SinhVien> timKiemTen(string tensv)
        //{
        //    Database_Connect.MoKetNoi();
        //    List<SinhVien> ds_tho = new List<SinhVien>();
        //    string query = "Select * from SinhVien where TenSV Like @tensv";

        //    using (SqlCommand cmd = new SqlCommand(query, Database_Connect.Getcon()))
        //    {
        //        cmd.Parameters.AddWithValue("@tensv", "%" + tensv + "%");
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            SinhVien sinhVien = new SinhVien()
        //            {
        //                MaSV = reader["MaSV"].ToString(),
        //                TenSV = reader["TenSv"].ToString(),
        //                GioiTinh = reader["GioiTinh"].ToString(),
        //                NgaySinh = Convert.ToDateTime(reader["NgaySinh"]),
        //                QueQuan = reader["QueQuan"].ToString(),
        //                MaLop = reader["MaLop"].ToString()

        //            };
        //            ds_tho.Add(sinhVien);
        //        }

        //    }
        //    return ds_tho;

        //}

        public bool suaSv(SinhVien sinhVien)
        {
            Database_Connect.MoKetNoi();
            List<SinhVien> ds_sv = new List<SinhVien>();

            string query = "UPDATE SinhVien " +
                   "SET TenSV = @tensv, " +
                   "GioiTinh = @gt, " +
                   "NgaySinh = @ngaysinh, " +
                   "QueQuan = @que, " +
                   "MaLop = @malop " +
                   "WHERE MaSV = @masv;";

            using (SqlCommand cmd = new SqlCommand(query, Database_Connect.Getcon())) { 

                cmd.Parameters.AddWithValue("@masv",sinhVien.MaSV);
                cmd.Parameters.AddWithValue("@tensv", sinhVien.TenSV);
                cmd.Parameters.AddWithValue("@gt", sinhVien.GioiTinh);
                cmd.Parameters.AddWithValue("@ngaysinh", sinhVien.NgaySinh);
                cmd.Parameters.AddWithValue("@que", sinhVien.QueQuan);
                cmd.Parameters.AddWithValue("@malop", sinhVien.MaLop);

                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public bool xoaSv(SinhVien sinhVien)
        { 
            Database_Connect.MoKetNoi(); 
            

            string query = "DELETE FROM SinhVien WHERE MaSV = @masv";
            using (SqlCommand cmd = new SqlCommand(query, Database_Connect.Getcon()))
            {
                cmd.Parameters.AddWithValue("@masv", sinhVien.MaSV);
                cmd.ExecuteNonQuery();
            }
            return true;
        }

    }
}
