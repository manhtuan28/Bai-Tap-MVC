using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BaiTapMVC.Models;


namespace BaiTapMVC.Controllers
{
    public class Chuong1_Bai3Controller : Controller
    {
        // GET: Chuong1_Bai3
        [HttpGet]
        public ActionResult Index()
        {
            return View(new PTB2());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(PTB2 model)
        {
            TinhNghiem(model);
            return View(model);
        }

        private void TinhNghiem(PTB2 m)
        {
            const double EPS = 1e-9;

            if (Math.Abs(m.A) < EPS)
            {
                if (Math.Abs(m.B) < EPS)
                {
                    m.KetQua = Math.Abs(m.C) < EPS
                        ? "Phương trình vô số nghiệm."
                        : "Phương trình vô nghiệm.";
                }
                else
                {
                    m.X1 = m.X2 = -m.C / m.B;
                    m.KetQua = $"Phương trình bậc nhất có nghiệm: x = {Fmt(m.X1)}";
                }
                return;
            }

            double delta = m.B * m.B - 4 * m.A * m.C;

            if (delta > EPS)
            {
                double sqrtD = Math.Sqrt(delta);
                m.X1 = (-m.B - sqrtD) / (2 * m.A);
                m.X2 = (-m.B + sqrtD) / (2 * m.A);
                m.KetQua = $"Phương trình có 2 nghiệm phân biệt: x1 = {Fmt(m.X1)}, x2 = {Fmt(m.X2)}";
            }
            else if (Math.Abs(delta) <= EPS)
            {
                m.X1 = m.X2 = (-m.B) / (2 * m.A);
                m.KetQua = $"Phương trình có nghiệm kép: x1 = x2 = {Fmt(m.X1)}";
            }
            else
            {
                m.KetQua = "Phương trình vô nghiệm (trong R).";
                m.X1 = m.X2 = null;
            }
        }

        private string Fmt(double? x) => x?.ToString("0.###");
    }
}