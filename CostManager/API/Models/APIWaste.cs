using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class APIWaste
    {
        public string ClientId { get; set; }
        public string WasteId { get; set; }
        public string Market { get; set; }
        public DateTime BuyTime { get; set; }
        public List<Product> Products { get; set; }
    }
}
