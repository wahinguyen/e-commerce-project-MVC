using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class LoaiSanPham
    {
        [Key]
        public int MaLoaiSP { get; set; }
        public string TenLoaiSP { get; set; }
        public virtual ICollection<SanPham> Sanphams { get; set; }
    }
}
