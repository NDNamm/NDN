using BLL_SinhVien;
using DTO_SinhVien;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_SinhVien;
using BLL_SinhVien;


namespace GUI_SinhVien
{
    public partial class Form2 : Form
    {
        SinhVien_BLL sinhVien_BLL = new SinhVien_BLL();
        public Form2()
        {
            InitializeComponent();
        }

        private void lsvDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            if (lsvsv.SelectedItems.Count > 0)
            {
                ListViewItem lv = lsvsv.SelectedItems[0];
                txtMa.Text = lv.SubItems[0].Text;
                txtTen.Text = lv.SubItems[1].Text;
                cbGioiTinh.Text = lv.SubItems[2].Text;
                dtpNgaySinh.Text = lv.SubItems[3].Text;
                txtQueQuan.Text = lv.SubItems[4].Text;
                txtMaLop.Text = lv.SubItems[5].Text;

            }
            gbTTCT.Enabled = true;
        }
         
        public void LoadData()
        {
            lsvsv.Items.Clear();
            SinhVien_BLL sinhVien_BLL = new SinhVien_BLL();
            List<SinhVien> ds = sinhVien_BLL.LoadData();

            foreach (SinhVien sv in ds)
            {
                ListViewItem listViewItem = new ListViewItem(sv.MaSV);
                listViewItem.SubItems.Add(sv.TenSV);
                listViewItem.SubItems.Add(sv.GioiTinh);
                listViewItem.SubItems.Add(sv.NgaySinh.ToString());
                listViewItem.SubItems.Add(sv.QueQuan);
                listViewItem.SubItems.Add(sv.MaLop);

                lsvsv.Items.Add(listViewItem);

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
             LoadData();
             gbTTCT.Enabled = false;
             btnXoa.Enabled = false;
             btnSua.Enabled = false;
            
        }

        private void cbGioiTinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            themSv();

           
        }
        public void themSv()
        {
            string masv = txtMa.Text.Trim();
            string tensv = txtTen.Text.Trim();
            string gt = cbGioiTinh.Text.Trim();
            DateTime ngaysinh = dtpNgaySinh.Value;
            string que = txtQueQuan.Text.Trim();
            string malop = txtMaLop.Text.Trim();

            SinhVien_Clean sinhVien_Clean = new SinhVien_Clean()
            {
                MaSV_Clean = masv,
                TenSV_Clean = tensv,
                GioiTinh_Clean = gt,
                NgaySinh_Clean = ngaysinh,
                QueQuan_Clean = que,
                MaLop_Clean = malop,

            };

            if (sinhVien_BLL.Addsv(sinhVien_Clean))
            {
                MessageBox.Show("Them thanh cong");
                ClearSv();
            }
            else
            {
                MessageBox.Show("Them k thanh cong");
            }

            LoadData();
            gbTTCT.Enabled = false;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            gbTTCT.Enabled = true;
            ClearSv();
        }

        public void ClearSv()
        {
            txtMa.Clear();
            txtTen.Clear();
            txtQueQuan.Clear();
            txtMaLop.Clear();
            
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SinhVien sinhVien = new SinhVien
            {
                MaSV = txtMa.Text.Trim()
            };

            if (sinhVien_BLL.xoaSv(sinhVien))
            {
                MessageBox.Show("Xóa sinh viên thành công!");
            }
            else { MessageBox.Show("Xóa sinh viên k thành công!"); }

            LoadData() ;
        }

        private void gbTTCT_Enter(object sender, EventArgs e)
        {
            
        }

        private void txtTkMa_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
            string masv = txtTkMa.Text;
            lsvsv.Items.Clear();
            SinhVien_BLL sinhVien_BLL = new SinhVien_BLL();
            List<SinhVien> ds = sinhVien_BLL.timKiemMa(masv);

            foreach (SinhVien sv in ds)
            {
                ListViewItem listViewItem = new ListViewItem(sv.MaSV);
                listViewItem.SubItems.Add(sv.TenSV);
                listViewItem.SubItems.Add(sv.GioiTinh);
                listViewItem.SubItems.Add(sv.NgaySinh.ToString("yyyy-MM-dd"));
                listViewItem.SubItems.Add(sv.QueQuan);
                listViewItem.SubItems.Add(sv.MaLop);

                lsvsv.Items.Add(listViewItem);

            }

            //string tensv = txtTkMa.Text;
            //lsvsv.Items.Clear ();
            //List<SinhVien> ds1 = sinhVien_BLL.timKiemTen(tensv);
            //foreach (SinhVien sv in ds1)
            //{
            //    ListViewItem listViewItem = new ListViewItem(sv.TenSV);
            //    listViewItem.SubItems.Add(sv.MaSV );
            //    listViewItem.SubItems.Add(sv.GioiTinh);
            //    listViewItem.SubItems.Add(sv.NgaySinh.ToString("yyyy-MM-dd"));
            //    listViewItem.SubItems.Add(sv.QueQuan);
            //    listViewItem.SubItems.Add(sv.MaLop);

            //    lsvsv.Items.Add(listViewItem);

            //}

        }

        private void suaSV()
        {
            
   

            SinhVien sinhVien = new SinhVien()
            {

                MaSV = txtMa.Text.Trim(),          // Chỉ dùng để xác định sinh viên
                TenSV = txtTen.Text.Trim(),
                GioiTinh = cbGioiTinh.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value,
                QueQuan = txtQueQuan.Text.Trim(),
                MaLop = txtMaLop.Text.Trim()

            };

            if (sinhVien_BLL.suaSv(sinhVien))
            {
                MessageBox.Show("Sua thanh cong");
                ClearSv();
            }
            else
            {
                MessageBox.Show("Sua k thanh cong");
            }

            LoadData();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
           suaSV();
        }
    }
}
