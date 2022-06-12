using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuanFronttoEnd.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ProductsCategories> ProductsCategories { get; set; }

    }
}
