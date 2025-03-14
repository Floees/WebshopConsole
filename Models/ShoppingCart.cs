using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webshopsimpler.Models
{
    internal class ShoppingCart
    {
        public int Id { get; set; }
        public virtual User? User { get; set; }
        public int? UserId { get; set; }
        public virtual Product? Product { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
        public int? PaymentMethodId { get; set; }
        public virtual ShippingMethod? ShippingMethod { get; set; }
        public int? ShippingMethodId { get; set; }
        public bool IsPaid { get; set; }
        public string Status { get; set; }
    }
}
