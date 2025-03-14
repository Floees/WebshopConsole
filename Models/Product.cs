using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webshopsimpler.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public virtual ProductCategory? ProductCategory { get; set; }
        public int? ProductCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Dimensions { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public bool SelectProduct { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();
    }
}
