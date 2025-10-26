using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTapMVC.Models
{
    public class HangHoaViewModel
    {
        public string MaHang { get; set; }
        public string TenHang { get; set; }
        public string LoaiHang { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien => DonGia * SoLuong;
    }
}