using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class Point
    {
        [Key]
        public int PointID { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        public double PointMember { get; set; }
    }
}
