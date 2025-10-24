using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BaiTapMVC.Models
{
    public class PTB2
    {
        [Display(Name = "Hệ số a")]
        public double A { get; set; }

        [Display(Name = "Hệ số b")]
        public double B { get; set; }

        [Display(Name = "Hệ số c")]
        public double C { get; set; }

        public string KetQua { get; set; }
        public double? X1 { get; set; }
        public double? X2 { get; set; }
    }
}