using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopQuanAo.Models;

namespace ShopQuanAo.Controllers
{
    public class ConTactController : Controller
    {
        private readonly SaleContext _context;

        public ConTactController(SaleContext context)
        {
            _context = context;
        }

        // GET: ConTact/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ConTact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContactID,Name,Email,Phone,Address,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction("Confirm1", "Contact");
            }
            return View(contact);
        }
        public IActionResult Confirm1()
        {
            return View();
        }
    }
}
