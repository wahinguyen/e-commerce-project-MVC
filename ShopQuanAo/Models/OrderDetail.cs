using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class OrderDetail
    {
        [DisplayName("Mã chi tiết đơn hàng")]
        public int OrderDetailId { get; set; }
        [DisplayName("Mã đơn hàng")]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        [DisplayName("Mã sản phẩm")]
        [ForeignKey("SanPham")]
        public int MaSP { get; set; }
        [DisplayName("Số lượng")]
        public int SoLuong { get; set; }
        public double ThanhTien { get; set; }
        public virtual Order Order { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
