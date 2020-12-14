using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopQuanAo.Models;

namespace ShopQuanAo.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            if (cart == null)
                return View();
            else
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.SanPham.DonGia * item.SoLuong);
                ViewBag.count = cart.Count();
            }
            return View();
        }
    }
}