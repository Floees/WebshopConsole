using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webshopsimpler.Models
{
    internal class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();

    }
}
