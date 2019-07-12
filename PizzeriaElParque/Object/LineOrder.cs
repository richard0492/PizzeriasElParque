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
        public string nameProduct { set; get; }
        public int lineOrderID { set; get; }
        public int timeMinuteCook { set; get; }


        public LineOrder()
        {
        }

        public LineOrder(int quantity, double price, DateTime date, DateTime startHour, int orderId, int productId)
        {
            this.quantity = quantity;
            this.price = price;
            this.date = date;
            this.startHour = startHour;
            this.orderId = orderId;
            this.productId = productId;
        }


        public LineOrder(int lineOrderID,int productId, string nameProduct, int quantity, double price, DateTime startHour, int timeMinuteCook)
        {
            this.lineOrderID = lineOrderID;
            this.nameProduct = nameProduct;
            this.productId = productId;
            this.quantity = quantity;
            this.price = price;
            this.startHour = startHour;
            this.timeMinuteCook = timeMinuteCook;
        }

        public LineOrder(int quantity, double price, DateTime date, DateTime startHour, int orderId, int productId, int lineOrderID)
        {
            this.quantity = quantity;
            this.price = price;
            this.date = date;
            this.startHour = startHour;
            this.orderId = orderId;
            this.productId = productId;
            this.lineOrderID = lineOrderID;
        }
    }


}
