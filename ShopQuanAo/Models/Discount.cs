using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class Discount
    {
        [DisplayName("Mã giảm giá")]
        public int DiscountID { get; set; }
        [DisplayName("Code giảm giá")]
        [StringLength(50)]
        public string DiscountCode { get; set; }
        [DisplayName("QR Code")]
        [StringLength(100)]
        public string QRCode { get; set; }
        [DisplayName("Giá giảm")]
        [Required]
        public double Amount { get; set; }
        [DisplayName("Hiệu lực đến")]
        [Required]
        public DateTime DateExpired { get; set; }
    }
}
