using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DTO_SinhVien;
using DAL_SinhVien;

namespace BLL_SinhVien
{
    public class SinhVien_BLL
    {
        SinhVien_DAL SinhVien_DAL = new SinhVien_DAL();

        public List<SinhVien> LoadData()
        {
            return SinhVien_DAL.LoadSv();
        }

        public bool Addsv(SinhVien_Clean sinhVien_Clean)
        {
            return SinhVien_DAL.themSv(sinhVien_Clean);
        }

        public List<SinhVien> timKiemMa(string masv)
        {
            return SinhVien_DAL.timKiemMa(masv);
        }

        //public List<SinhVien> timKiemTen(string tensv)
        //{
        //    return SinhVien_DAL.timKiemTen(tensv);
        //}

        public bool suaSv(SinhVien sinhVien)
        {
            return SinhVien_DAL.suaSv(sinhVien);
        }

        public bool xoaSv(SinhVien sinhVien)
        {
            return SinhVien_DAL.xoaSv(sinhVien);
        }
    }
}
