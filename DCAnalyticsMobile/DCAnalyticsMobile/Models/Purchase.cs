using System;
using System.Collections.Generic;
using System.Text;

namespace DCAnalyticsMobile.Models
{
    public class Purchase: DataCollectionObject
    {
        public string Farmer { get; set; }
        public int Station { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public int Product { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public decimal TotalAmount { get; set; }
        public string Lotid { get; set; }
        public int ConfigurationId { get; set; }
    }
}
