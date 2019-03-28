using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using P208_ASP_Front.Models;

namespace P208_ASP_Front.ViewModels
{
    public class HomeIndexVM
    {
        public List<Slider> Sliders { get; set; }
        public About About { get; set; }
        public Parallax Parallax { get; set; }
    }
}