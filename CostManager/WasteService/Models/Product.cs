using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteService.Models
{
    public class Product
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int Weight { get; set; }
        public int Capacity { get; set; }
    }
}
