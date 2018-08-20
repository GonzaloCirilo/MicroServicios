using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orders_API.Models
{
    public class Order : Orders
    {
        public Sales Sales { get; set; }
    }
}