using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Brands
    {
        [Key]
        public int BrandsId { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public bool Enable { get; set; }

    }
}
