using System;
using System.Collections.Generic;

namespace CommonUtilities.Models
{
    public class Purchase
    {
        public List<Position> Positions { get; set; }
        public string Market { get; set; }
        public double TotalSum { get; set; }
        public DateTime PurchaseTime { get; set; }
        public string Guid { get; set; }
        public string UserGuid { get; set; }
    }
}
