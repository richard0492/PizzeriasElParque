using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Object;
using Data;

namespace Logic
{
    public class LogicOrder
    {
        DataOrder dataLO = new DataOrder();

        public List<LineOrder> ConsulLineOders(int IDProduct)
        {
            List<LineOrder> orders = new List<LineOrder>();

            orders = dataLO.ConsultLineOder(IDProduct);

            return orders;
        }

        public bool insertLineOders(int quantity, DateTime date, DateTime hour, int orderId, int productId)
        {
           

            dataLO.insertLineOrder(quantity, date, hour, orderId, productId);

            return true;
        }

        public bool modifytLineOders(int quantity, DateTime date, DateTime hour, int orderId, int productId, int lineOrderID)
        {


            dataLO.modifyLineOrder(quantity, date, hour, orderId, productId, lineOrderID);

            return true;
        }

        public int lastOrder() {
            return dataLO.LastOrder();
        }



        public List<Order> ConsulOders()
        {
            List<Order> orders = new List<Order>();
            return orders;
        }

        public Order ConsultOder(String Order_ID)
        {
            Order order = new Order();
            return order;
        }

        public bool DeleteOrder(String Odere_ID)
        {
            
            return false;
        }

        public bool Change_State_Order(String Odere_ID,String State)
        {

            return false;
        }

        public bool Add_Order_Local(Order order)
        {

            return false;
        }

        public bool Add_Order_Express(Order order)
        {

            return false;
        }
    }
}
