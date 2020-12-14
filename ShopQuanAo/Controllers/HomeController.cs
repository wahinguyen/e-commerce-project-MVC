using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopQuanAo.Models;
using SQLitePCL;

namespace ShopQuanAo.Controllers
{
    public class HomeController : Controller
    {
        private readonly SaleContext _context;

        public HomeController(SaleContext _context)
        {
            this._context = _context;
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
                ViewBag.count = cart.Count();
            }
            return View();
        }

        public IActionResult Index(int? page, int maloaisp = 0)
        {
            

            var loaiSP = _context.LoaiSanPhams.ToList();
            Hashtable tenloaiSP = new Hashtable();
            foreach (var item in loaiSP)
            {
                tenloaiSP.Add(item.MaLoaiSP, item.TenLoaiSP);
            }
            ViewBag.TenLoaiSP = tenloaiSP;
            if (maloaisp == 0)
            {
                int sotrang = _context.Sanphams.Count() / 6;
                ViewBag.Count = sotrang;

                int number = 1;
                if (page != null)
                {
                    number = page.GetValueOrDefault() * 6;
                }
                var sanphams = _context.Sanphams.Include(s => s.LoaiSanPham);
                //var item = from p in _context.Sanphams
                //           select p;
                return View(sanphams.OrderBy(s => s.MaSP).Skip(number).Take(6).ToList());
                //var sanphams = _context.Sanphams.Include(s => s.LoaiSanPham);
                //return View(sanphams.ToList());
            }
            else
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
                var sanPhams = _context.Sanphams.Include(s => s.LoaiSanPham).Where(x => x.MaLoaiSP == maloaisp);
                return View(sanPhams);
            }

        }
        public async Task<IActionResult> Trangchu(int id)
        {
            var sanPham = await _context.Sanphams.Include(s => s.LoaiSanPham).FirstOrDefaultAsync(m => m.MaSP == id);

            var sanPhamFeature = await _context.Sanphams.Include(s => s.LoaiSanPham).Where(m => m.Feature == 1).ToListAsync();

            SanPhamVM spVM = new SanPhamVM()
            {
                Sanpham = sanPham,
                ListSanPhamFeature = sanPhamFeature
            };

            return View(spVM);
        }
        public async Task<IActionResult> Thongtinsanpham(int id)
        {
            var sanPham = await _context.Sanphams.Include(s => s.LoaiSanPham).FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            var sanPhamFeature = await _context.Sanphams.Include(s => s.LoaiSanPham).Where(m => m.Feature == 1).ToListAsync();

            SanPhamVM spVM = new SanPhamVM()
            {
                Sanpham = sanPham,
                ListSanPhamFeature = sanPhamFeature
            };

            return View(spVM);
        }
        public ActionResult TimKiem(long max, long min)
        {
            var link = _context.Sanphams.Where(x => x.DonGia >= min && x.DonGia <= max).ToList();
            return View(link);
        }
    }
    }

