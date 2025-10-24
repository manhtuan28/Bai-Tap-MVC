using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTapMVC.Controllers
{
    public class Chuong1_Bai1Controller : Controller
    {
        // GET: Chuong1_Bai1
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Result(double a, double b, string radioTinh)
        {
            double? result = null;
            string opSymbol = radioTinh;

            switch (radioTinh)
            {
                case "+":
                    result = a + b; break;
                case "-":
                    result = a - b; break;
                case "*":
                    result = a * b; break;
                case "/":
                    if (Math.Abs(b) < double.Epsilon)
                    {
                        ViewBag.Error = "Không thể chia cho 0.";
                    }
                    else
                    {
                        result = a / b;
                    }
                    break;
                default:
                    ViewBag.Error = "Vui lòng chọn phép tính hợp lệ.";
                    break;
            }

            ViewBag.A = a;
            ViewBag.B = b;
            ViewBag.Op = opSymbol;
            ViewBag.C = result;

            return View();
        }
    }
}