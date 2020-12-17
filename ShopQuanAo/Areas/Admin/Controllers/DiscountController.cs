using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopQuanAo.Models;

namespace ShopQuanAo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountController : Controller
    {
        private readonly SaleContext _context;
        private readonly Random _random = new Random();

        public DiscountController(SaleContext context)
        {
            _context = context;
        }

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        #region Encode
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        #endregion

        // GET: Admin/Discount
        public async Task<IActionResult> Index()
        {
            return View(await _context.Discount.ToListAsync());
        }

        // GET: Admin/Discount/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discount = await _context.Discount
                .FirstOrDefaultAsync(m => m.DiscountID == id);
            if (discount == null)
            {
                return NotFound();
            }

            return View(discount);
        }

        // GET: Admin/Discount/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Discount/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Discount discount)
        {
            if (ModelState.IsValid)
            {
                var codePrefix = DateTime.Now.ToString("ddMMyyyy");

                var maxOrderCount = _context.Discount
                    .AsEnumerable()
                    .Where(e => e.DiscountCode.Contains(codePrefix))
                    .Count();

                maxOrderCount += 1;
                string orderCode = String.Format("{0:D4}", maxOrderCount);

                int random = RandomNumber(1000,100000);

                var code = String.Format("{0}-{1}-{2}", codePrefix, orderCode, random);

                var data = new Discount()
                {
                    DiscountCode = code,
                    QRCode = Base64Encode(code),
                    Amount = discount.Amount,
                    DateExpired = discount.DateExpired,
                };
                _context.Discount.Add(data);
                _context.SaveChanges();
                return RedirectToAction("Index", "Discount");
            }
            return View(discount);
        }

        // GET: Admin/Discount/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discount = await _context.Discount.FindAsync(id);
            if (discount == null)
            {
                return NotFound();
            }
            return View(discount);
        }

        // POST: Admin/Discount/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DiscountID,DiscountCode,QRCode,Amount,DateExpired")] Discount discount)
        {
            if (id != discount.DiscountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(discount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DiscountExists(discount.DiscountID))
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
            return View(discount);
        }

        // GET: Admin/Discount/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discount = await _context.Discount
                .FirstOrDefaultAsync(m => m.DiscountID == id);
            if (discount == null)
            {
                return NotFound();
            }

            return View(discount);
        }

        // POST: Admin/Discount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var discount = await _context.Discount.FindAsync(id);
            _context.Discount.Remove(discount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DiscountExists(int id)
        {
            return _context.Discount.Any(e => e.DiscountID == id);
        }
    }
}
