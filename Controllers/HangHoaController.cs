using BaiTapMVC.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTapMVC.Controllers
{
    public class HangHoaController : Controller
    {
        // GET: /HangHoa/Nhap
        public ActionResult Nhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThanhTien_Request()
        {
            var vm = ParseFrom(Request["MaHang"], Request["TenHang"], Request["LoaiHang"],
                               Request["DonGia"], Request["SoLuong"]);

            return View("ThanhTien", vm);
        }

        [HttpPost]
        public ActionResult ThanhTien_Form(FormCollection form)
        {
            var vm = ParseFrom(form["MaHang"], form["TenHang"], form["LoaiHang"],
                               form["DonGia"], form["SoLuong"]);

            return View("ThanhTien", vm);
        }

        private HangHoaViewModel ParseFrom(string ma, string ten, string loai, string donGiaStr, string soLuongStr)
        {
            var culture = new CultureInfo("vi-VN");

            decimal donGia = 0;
            int soLuong = 0;

            if (!decimal.TryParse(donGiaStr, NumberStyles.Number, culture, out donGia))
                decimal.TryParse(donGiaStr, NumberStyles.Number, CultureInfo.InvariantCulture, out donGia);

            int.TryParse(soLuongStr, NumberStyles.Integer, culture, out soLuong);

            return new HangHoaViewModel
            {
                MaHang = ma,
                TenHang = ten,
                LoaiHang = loai,
                DonGia = donGia,
                SoLuong = soLuong
            };
        }
    }
}