using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopQuanAo.Models;

namespace ShopQuanAo.Controllers
{
    public class CartController : Controller
    {
        private readonly SaleContext db;
        public CartController(SaleContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            if (cart == null)
                return View();
            else
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.SanPham.DonGia * item.SoLuong);
            }
            return View();
        }
        public IActionResult GioHang()
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            if (cart == null)
                return View();
            else
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.SanPham.DonGia * item.SoLuong);
            }
            return View();
        }
        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart") == null)
            {
                List<OrderDetail> cart = new List<OrderDetail>
                {
                    new OrderDetail { SanPham = db.Sanphams.FirstOrDefault(p => p.MaSP == id), SoLuong = 1}
                };
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
                int index = IsExist(id);
                if (index != -1)
                    cart[index].SoLuong++;
                else
                    cart.Add(new OrderDetail { SanPham = db.Sanphams.FirstOrDefault(p => p.MaSP == id), SoLuong = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("GioHang");
        }
        [HttpPost]
        public IActionResult Update(int MaSP, int txtSoLuong)
        {
            List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            int index = IsExist(MaSP);
            cart[index].SoLuong = txtSoLuong;
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToAction("GioHang");

        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            int index = IsExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("GioHang");
        }
        private int IsExist(int id)
        {
            List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].SanPham.MaSP == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public IActionResult Confirm()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Checkout()
        {
            var cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
            if (cart == null)
                return View();
            else
            {
                ViewBag.cart = cart;
                ViewBag.total = cart.Sum(item => item.SanPham.DonGia * item.SoLuong);
            }
            Order order = new Order();
            return View(order);
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (ModelState.IsValid)
            {
                var codePrefix = DateTime.Now.ToString("ddMMyyyy");

                var maxOrderCount = db.Orders
                    .AsEnumerable()
                    .Where(e => e.Code.Contains(codePrefix))
                    .Count();

                maxOrderCount += 1;
                string orderCode = String.Format("{0:D4}", maxOrderCount);

                var code = String.Format("{0}-{1}", codePrefix, orderCode);

                List<OrderDetail> cart = SessionHelper.GetObjectFromJson<List<OrderDetail>>(HttpContext.Session, "cart");
                Order orderTemp = new Order
                {
                    Code = code,
                    OrderDate = DateTime.Now,
                    Phone = order.Phone,
                    Address = order.Address,
                    Email = order.Email,
                    CustomerName = order.CustomerName,
                };
                db.Orders.Add(orderTemp);
                db.SaveChanges();

                var query = db.Orders.FirstOrDefault(p => p.OrderId == orderTemp.OrderId);
                foreach (var item in cart)
                {
                    db.OrderDetails.Add(new OrderDetail()
                    {
                        OrderId = query.OrderId,
                        MaSP = item.SanPham.MaSP,
                        SoLuong = item.SoLuong,
                    });

                    var product = db.Sanphams
                        .AsEnumerable()
                        .Where(s => s.MaSP == item.SanPham.MaSP)
                        .FirstOrDefault();

                    if (product != null)
                    {
                        product.SoLuong = product.SoLuong - item.SoLuong;
                    }
                }
                db.SaveChanges();
                cart.Clear();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                return RedirectToAction("Confirm", "Cart");
            }
            return View(order);
        }

        
    }
}