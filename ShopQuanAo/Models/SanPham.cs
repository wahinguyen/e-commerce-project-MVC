using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class SanPham
    {
        [Key]
        [DisplayName("Mã sản phẩm")]
        public int MaSP { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string TenSP { get; set; }
        [DisplayName("Số Lượng")]
        public int SoLuong { get; set; }
        [DisplayFormat(DataFormatString ="{0:0,0}")]
        public double DonGia { get; set; }
        [ForeignKey("LoaiSanPham")]
        public int MaLoaiSP { get; set; }
        public string HinhSP { get; set; }
        public string Description { get; set; }
        public int Feature { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }

        internal object ToListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
