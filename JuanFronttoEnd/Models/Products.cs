using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuanFronttoEnd.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int DiscountPercentage { get; set; }
        public bool IsInStock { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsNew { get; set; }
        public ICollection<ProductsCategories> ProductsCategories { get; set; }
        public ICollection<ProductImages> Images { get; set; }
        public ICollection<ProductColours> Colours { get; set; }



    }
}
