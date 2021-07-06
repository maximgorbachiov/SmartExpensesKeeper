using System;

namespace MobileClient.Models
{
    public class Purchase
    {
        public Position[] Positions { get; set; }
        public string Shop { get; set; }
        public int TotalSum { get; set; }
        public DateTime purchaseTime { get; set; }
        public int Guid { get; set; }
        public string UserGuid { get; set; }
    }
}