using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopQuanAo.Models;

namespace ShopQuanAo.Data
{
    public class ShopQuanAoContext : DbContext
    {
        public ShopQuanAoContext (DbContextOptions<ShopQuanAoContext> options)
            : base(options)
        {
        }

        public DbSet<ShopQuanAo.Models.SanPham> SanPham { get; set; }
    }
}
