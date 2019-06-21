using System;
using System.Collections.Generic;
using System.Text;

namespace Object
{
   public class Sale
    {
        public int sale_Quantity { get; set; }
        public Product sale_product { get; set; }
        public Order sale_order { get; set; }
    }
}
