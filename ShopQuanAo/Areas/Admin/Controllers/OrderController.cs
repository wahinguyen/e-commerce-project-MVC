using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopQuanAo.Models;

namespace ShopQuanAo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class OrderController : Controller
    {
        private readonly SaleContext dataContext;
        public OrderController(SaleContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index(int? statusID, DateTime? timeStart, DateTime? timeEnd)
        {
            var query = dataContext.Orders.AsEnumerable();
            
            if(statusID == null || statusID == -100)
            {
                query = query.ToList();
            } 
            if(statusID == 0)
            {
                query = query.Where(o => o.StatusID == 0).ToList();
            }
            if (statusID == 1)
            {
                query = query.Where(o => o.StatusID == 1).ToList();
            }
            if (statusID == 2)
            {
                query = query.Where(o => o.StatusID == 2).ToList();
            }
            if (statusID == 3)
            {
                query = query.Where(o => o.StatusID == 3).ToList();
            }
            if (statusID == -1)
            {
                query = query.Where(o => o.StatusID == -1).ToList();
            }
            if (timeStart != null && timeEnd != null)
            {
                query = query.Where(o =>
                    (timeStart <= o.OrderDate && o.OrderDate <= timeEnd)).ToList();
            }

            return View(query);
        }
        

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Order oldOrder = dataContext.Orders.FirstOrDefault(p => p.OrderId == id);
            return View(oldOrder);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Order order = dataContext.Orders.FirstOrDefault(p => p.OrderId == id);
            

            var products = dataContext.Sanphams.AsEnumerable().ToList();

            var productOrders = dataContext.OrderDetails.Where(i => i.OrderId == order.OrderId).Select(i =>new {i.MaSP, i.SoLuong }).ToList();

            var orderdetails = dataContext.OrderDetails.Where(i => i.OrderId == order.OrderId).ToList();

            

            orderdetails.ForEach(item =>
            {
                var product = products.Where(p => p.MaSP == item.MaSP).FirstOrDefault();
                if(product != null)
                {
                    product.SoLuong = product.SoLuong + item.SoLuong;
                }
                dataContext.SaveChanges();
            });

            foreach (var item in orderdetails)
            {
                dataContext.OrderDetails.Remove(item);
                dataContext.SaveChanges();
            }

            dataContext.Orders.Remove(order);
            dataContext.SaveChanges();

            return RedirectToAction("Index", "Order");
        }

        //[HttpGet("Order/{id}/{name}")]
        public IActionResult Detail(int id)
        {
            Order order = dataContext.Orders.FirstOrDefault(p => p.OrderId == id);
            List<OrderDetail> item = dataContext.OrderDetails.Where(p => p.OrderId == order.OrderId).ToList();
            List<SanPham> products = new List<SanPham>();
            foreach (var item2 in item)
            {
                SanPham product = dataContext.Sanphams.FirstOrDefault(p => p.MaSP == item2.MaSP);
                products.Add(product);
            }

            ViewBag.Total = item.Sum(item => item.SanPham.DonGia * item.SoLuong);
            ViewBag.Order = item;

            return View(order);
        }

        [HttpPost, ActionName("Detail")]
        public IActionResult UpdateStatus(int id, int statusID)
        {
            var order = dataContext.Orders.Where(o => o.OrderId == id).FirstOrDefault();

            order.StatusID = statusID;
            dataContext.SaveChanges();

            return RedirectToAction("Index", "Order");
        }
    }
}