using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class KhachHangModels
    {
        public double PointMember {get; set;}
        public List<Order> Orders { get; set; }
    }
}
