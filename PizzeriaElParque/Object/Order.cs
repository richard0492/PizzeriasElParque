﻿using System;
using System.Collections;
using System.Text;

namespace Object
{
    /// <summary>
    /// Clase para objeto de la orden
    /// </summary>
    public class Order
    {
        public int estadeId { set; get; }
        public int orderID { set; get; }
        public string nameClient { set; get; }
        public string additional { set; get; }
        public string address { set; get; }
        public int phone { set; get; }
        public char orderType { set; get; }
        public string tableNumber { set; get; }
        public int partyId { set; get; }
        public string estadeIdName { set; get; }
        public int orderTypeNumber { set; get; }
        public string nameEmployed { set; get; }
        /// <summary>
        /// Constructor
        /// </summary>
        public Order()
        {
        }

        public Order(int orderID, string estadeIdName, string nameEmployed, string nameClient, string additional, int orderTypeNumber)
        {
            this.orderID = orderID;
            this.estadeIdName = estadeIdName;
            this.nameEmployed = nameEmployed;
            this.nameClient = nameClient;
            this.additional = additional;
            this.orderTypeNumber = orderTypeNumber;
        }

        public Order(int statadId, int IDcard, string nomeClient, char orderType)
        {
            this.estadeId = statadId;
            this.orderID = IDcard;
            this.nameClient = nomeClient;
            this.orderType = orderType;
        }

        public Order(int estadeId, int IDcard, string nameClient, string additional, string address, int phone, char orderType)
        {
            this.estadeId = estadeId;
            this.orderID = IDcard;
            this.nameClient = nameClient;
            this.additional = additional;
            this.address = address;
            this.phone = phone;
            this.orderType = orderType;
        }

        public Order(int estadeId, int orderID, string nameClient, string additional, string address, int phone, char orderType, string tableNumber, int partyId)
        {
            this.partyId = partyId;
            this.estadeId = estadeId;
            this.orderID = orderID;
            this.nameClient = nameClient;
            this.additional = additional;
            this.address = address;
            this.phone = phone;
            this.orderType = orderType;
            this.tableNumber = tableNumber;
        }


    }
}