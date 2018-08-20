using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orders_API.Models
{
    public class Sales
    {
        public int Sales_Id { get; set; }
        public String Customer { get; set; }
        public String SalesPerson { get; set; }
        public String Product { get; set; }
        public Double Product_Price { get; set; }
        public int Quantity { get; set; }
    }
}