using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candymania.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string? Categoryname { get; set; }
       
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
