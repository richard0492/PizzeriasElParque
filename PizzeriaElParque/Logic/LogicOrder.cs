using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Object;

namespace Logic
{
   public class LogicOrder
    {
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
