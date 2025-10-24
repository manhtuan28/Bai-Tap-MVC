using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaiTapMVC.Models
{
    public enum ElectricityType
    {
        SinhHoat = 0,
        KinhDoanh = 1,  // +20%
        SanXuat = 2    // +30%
    }
    public class HoaDonDienViewModel
    {
        [Display(Name = "Chủ hộ")]
        [Required(ErrorMessage = "Nhập tên chủ hộ")]
        public string ChuHo { get; set; }

        [Display(Name = "Chỉ số cũ (kWh)")]
        [Range(0, int.MaxValue)]
        public int ChiSoCu { get; set; }

        [Display(Name = "Chỉ số mới (kWh)")]
        [Range(0, int.MaxValue)]
        public int ChiSoMoi { get; set; }

        [Display(Name = "Loại điện tiêu thụ")]
        public ElectricityType LoaiDien { get; set; }

        [Display(Name = "Hộ ưu tiên")]
        public bool UuTien { get; set; }

        // Kết quả
        public int SoDienTieuThu => ChiSoMoi > ChiSoCu ? (ChiSoMoi - ChiSoCu) : 0;
        public decimal? TienPhaiTra { get; set; }
        public string Loi { get; set; }
    }
}