using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Composition.Convention;
using System.Linq;
using System.Threading.Tasks;

namespace ShopQuanAo.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        [Required]
        [DisplayName("Customer Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Phone")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Address")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Message")]
        public string Message { get; set; }

    }
}
