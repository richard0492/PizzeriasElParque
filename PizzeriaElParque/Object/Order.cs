using System;
using System.Collections;
using System.Text;

namespace Object
{
   public class Order
    {
        public string estadeId { set; get; }
        public int IDcard { set; get; }
        public string nameClient { set; get; }
        public string additional { set; get; }
        public string address { set; get; }
        public int phone { set; get; }
        public int orderType { set; get; }
        public int orderID { set; get; }
        public string nameEmployed { set; get; }


        public Order()
        {
        }

        public Order(int orderID, string statadId, string nameEmployed, string nomeClient, string additional, int orderType)
        {
            this.orderID = orderID;
            this.estadeId = statadId;
            this.nameEmployed = nameEmployed;
            this.nameClient = nomeClient;
            this.additional = additional;
            this.orderType = orderType;
        }

        public Order(string estadeId, int IDcard, string nameClient, string additional, string address, int phone, int orderType)
        {
            this.estadeId = estadeId;
            this.IDcard = IDcard;
            this.nameClient = nameClient;
            this.additional = additional;
            this.address = address;
            this.phone = phone;
            this.orderType = orderType;
        }
    }
}
