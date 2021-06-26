using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteService.Models
{
    public class Waste
    {
        public string ClientId { get; set; }
        public string WasteId { get; set; }
        public string Market { get; set; }
        public DateTime BuyTime { get; set; }
        public List<Product> Products { get; set; }
    }
}
