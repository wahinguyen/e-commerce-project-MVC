using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopQuanAo.Models;

namespace ShopQuanAo.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly SaleContext db;
        private readonly UserManager<User> _userManager;

        public KhachHangController(UserManager<User> userManager, SaleContext context)
        {
            db = context;
            _userManager = userManager;
        }

        // GET: KhachHang
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                var query = db.Orders
                        .AsEnumerable()
                        .Where(o => o.KhachHang == User.Identity.Name)
                        .ToList();

                return View(query);
            }    
            return View();
        }

        // GET: KhachHang/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await db.Orders
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: KhachHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,KhachHang,Code,CustomerName,Address,Email,Phone,Total,GiaGiam,OrderDate")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Add(order);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: KhachHang/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: KhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,KhachHang,Code,CustomerName,Address,Email,Phone,Total,GiaGiam,OrderDate")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(order);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
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
            return View(order);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Order oldOrder = db.Orders.FirstOrDefault(p => p.OrderId == id);
            return View(oldOrder);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.FirstOrDefault(p => p.OrderId == id);
            order.StatusID = -1;
            db.SaveChanges();

            return RedirectToAction("Index", "KhachHang");
        }

        private bool OrderExists(int id)
        {
            return db.Orders.Any(e => e.OrderId == id);
        }
    }
}
