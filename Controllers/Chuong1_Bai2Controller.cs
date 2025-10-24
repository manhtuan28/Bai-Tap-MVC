using BaiTapMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTapMVC.Controllers
{
    public class Chuong1_Bai2Controller : Controller
    {
        // GET: Chuong1_Bai2
        public ActionResult Index()
        {
            return View(new HoaDonDienViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Result(HoaDonDienViewModel model)
        {
            if (model.ChiSoMoi < model.ChiSoCu)
            {
                model.Loi = "Chỉ số mới phải lớn hơn hoặc bằng chỉ số cũ.";
                return View(model);
            }

            int kwh = model.SoDienTieuThu;
            decimal baseMoney = TinhTienBacThang(kwh);

            decimal factor = 1m;
            switch (model.LoaiDien)
            {
                case ElectricityType.KinhDoanh:
                    factor += 0.20m;
                    break;
                case ElectricityType.SanXuat:
                    factor += 0.30m;
                    break;
            }

            if (model.UuTien) factor -= 0.10m;

            model.TienPhaiTra = Math.Round(baseMoney * factor, 0, MidpointRounding.AwayFromZero);
            return View(model);
        }

        private decimal TinhTienBacThang(int kwh)
        {
            if (kwh <= 0) return 0m;

            int remain = kwh;
            decimal total = 0m;

            int b1 = Math.Min(remain, 100);
            total += b1 * 2000m;
            remain -= b1;

            if (remain > 0)
            {
                int b2 = Math.Min(remain, 50);
                total += b2 * 2500m;
                remain -= b2;
            }

            if (remain > 0)
            {
                int b3 = Math.Min(remain, 50);
                total += b3 * 3000m;
                remain -= b3;
            }

            if (remain > 0)
            {
                total += remain * 4000m;
            }

            return total;
        }
    }
}