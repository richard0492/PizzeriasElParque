using System;
using System.Collections.Generic;
using System.Text;

namespace Object
{
    public class LineOrder
    {
        public int quantity { set; get; }
        public double price { set; get; }
        public DateTime date { set; get; }
        public DateTime startHour { set; get; }
        public int orderId { set; get; }
        public int productId { set; get; }
    }
}
