using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopQuanAo.Models;

namespace ShopQuanAo.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class SanPhamController : Controller
    {
        private readonly SaleContext _context;

        public SanPhamController(SaleContext context)
        {
            _context = context;
        }

        // GET: SanPham
        public IActionResult Index()
        {
            var sanphams = _context.Sanphams.Include(s => s.LoaiSanPham);
            return View(sanphams.ToList());
        }

        // GET: SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.Sanphams
                .Include(s => s.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }
        public IActionResult Nhap()
        {
            ViewData["MaSP"] = new SelectList(_context.Sanphams, "MaSP", "TenSP");
            return View();
        }

        // POST: Admin/NhapHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Nhap(int maSP, SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var data = _context.Sanphams
                    .AsEnumerable()
                    .Where(s => s.MaSP == maSP)
                    .FirstOrDefault();

                int soLuongHienTai = _context.Sanphams
                    .AsEnumerable()
                    .Where(s => s.MaSP == maSP)
                    .Select(s => s.SoLuong)
                    .FirstOrDefault();

                data.SoLuong = soLuongHienTai + sanPham.SoLuong;

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanPham);
        }

        // GET: SanPham/Create
        public IActionResult Create()
        {
            ViewData["MaLoaiSP"] = new SelectList(_context.LoaiSanPhams, "MaLoaiSP", "TenLoaiSP");
            return View();
        }

        // POST: SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( SanPham sanPham,IFormFile photo)
        {

            if (ModelState.IsValid)
            {
                SanPham newProduct = new SanPham();
                if (photo == null || photo.Length == 0)
                {
                    newProduct.HinhSP = "";
                }
                else
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    photo.CopyToAsync(stream);
                    newProduct.HinhSP = photo.FileName;
                }
                newProduct.TenSP = sanPham.TenSP;
                newProduct.DonGia = sanPham.DonGia;
                newProduct.Description = sanPham.Description;
                newProduct.MaLoaiSP = sanPham.MaLoaiSP;
                newProduct.SoLuong = 0;

                _context.Sanphams.Add(newProduct);
                _context.SaveChanges();
                return RedirectToAction("Index", "SanPham");
            }
            else
            {
                return View(sanPham);
            }
        }

        // GET: SanPham/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = _context.Sanphams.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["MaLoaiSP"] = new SelectList(_context.LoaiSanPhams, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);
            return View(sanPham);
        }

        // POST: SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, SanPham sanPham, IFormFile photo)
        {
            var data = _context.Sanphams
                .AsEnumerable()
                .Where(s => s.MaSP == id)
                .FirstOrDefault();

            if (data == null)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    if (photo == null || photo.Length == 0)
                    {
                        data.HinhSP = data.HinhSP;
                        _context.SaveChanges();
                    }
                    else
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.FileName);
                        var stream = new FileStream(path, FileMode.Create);
                        photo.CopyToAsync(stream);
                        data.HinhSP = photo.FileName;
                        _context.SaveChanges();
                    }

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(data.MaSP))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoaiSP"] = new SelectList(_context.LoaiSanPhams, "MaLoaiSP", "TenLoaiSP", sanPham.MaLoaiSP);

            return View(sanPham);
        }

        // GET: SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.Sanphams
                .Include(s => s.LoaiSanPham)
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return View(sanPham);
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var validate = _context.Sanphams
               .AsEnumerable()
               .Where(s => s.MaSP == id
                   && s.SoLuong == 0)
               .FirstOrDefault();

            if (validate != null)
            {
                _context.Sanphams.Remove(validate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                throw new Exception("Sản phẩm này đang tồn tại");
            }
        }

        private bool SanPhamExists(int id)
        {
            return _context.Sanphams.Any(e => e.MaSP == id);
        }

    }
}
