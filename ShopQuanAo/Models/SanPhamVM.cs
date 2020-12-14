using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class SanPhamVM
    {
        public SanPham Sanpham { get; set; }
        public List<SanPham> ListSanPhamFeature { get; set; }
        public int count { get; set; }
    }
}
