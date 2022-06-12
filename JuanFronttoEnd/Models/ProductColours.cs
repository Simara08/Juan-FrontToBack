using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuanFronttoEnd.Models
{
    public class ProductColours
    {

        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColourID { get; set; }
        public Products Product { get; set; }
        public Colours Colour { get; set; }


    }
}
