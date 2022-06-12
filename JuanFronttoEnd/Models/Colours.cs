using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JuanFronttoEnd.Models
{
    public class Colours
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductColours> ProductColours { get; set; }
    }
}
