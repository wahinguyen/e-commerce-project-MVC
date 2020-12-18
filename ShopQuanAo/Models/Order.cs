using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class Order
    {
        [DisplayName("Mã đơn hàng")]
        public int OrderId { get; set; }
        [DisplayName("Mã khách hàng")]
        public string KhachHang { get; set; }
        [StringLength(250)]
        public string Code { get; set; }
        [Required]
        [DisplayName("Tên khách hàng")]
        public string CustomerName { get; set; }
        [DisplayName("Địa Chỉ")]
        [Required]
        public string Address { get; set; }
        [DisplayName("Email")]
        [Required]
        public string Email { get; set; }
        [DisplayName("Số điện thoại")]
        [Required]
        public string Phone { get; set; }
        public double Total { get; set; }
        public double GiaGiam { get; set; }
        [DisplayName("Ngày đặt hàng")]
        public DateTime OrderDate { get; set; }
        public double Shipping { get; set; }
        public int StatusID { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
