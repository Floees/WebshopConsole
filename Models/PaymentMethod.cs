using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webshopsimpler.Models
{
    internal class PaymentMethod
    {
        public int Id { get; set; }
        public virtual PaymentType? PaymentType { get; set; }
        public int? PaymentTypeId { get; set; }
        public string Provider { get; set; }
        public string AccountNumber { get; set; }
        public string ExpiryDate { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
    }
}
