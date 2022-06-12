using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuanFronttoEnd.Models
{
    public class ProductImages
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public  Products Product { get; set; }

    }
}
