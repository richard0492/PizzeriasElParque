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
        DataOrder orderInData = new DataOrder();
       
        /// <summary>
        /// Call insertOrden to Data
        /// </summary>
        /// <param name="orderToInsert"> Object</param>
        /// <returns> Boolean</returns>
        public Boolean insertOrder(Order orderToInsert) {

            return orderInData.insertOrder(orderToInsert);
        }


      

        /// <summary>
        /// Call to insertOrder in the Data
        /// </summary>
        /// <param name="lineOrderToAdd"> Object</param>
        /// <returns> Boolean </returns>
        public bool insertLineOders(LineOrder lineOrderToAdd)
        {
           

           return  orderInData.insertLineOrder(lineOrderToAdd);

           
        }
        public List<LineOrder> ConsulLineOders(int IDProduct)
        {
            List<LineOrder> orders = new List<LineOrder>();

            orders = orderInData.ConsultLineOder(IDProduct);

            return orders;
        }
       

        public int lastOrder() {
            return orderInData.LastOrder();
        }



        public List<Order> consultOrders()
        {
            List<Order> orders = new List<Order>();
            orders = orderInData.ConsulOders();
            return orders;
        }

        public Order consultOrder(String Order_ID)
        {
            Order order = new Order();
            return order;
        }

        public bool DeleteOrder(String Odere_ID)
        {
            
            return false;
        }

        public bool Change_State_Order(int Odrer_ID,int State)
        {

            orderInData.modifyEstadeOrder(Odrer_ID, State);

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
