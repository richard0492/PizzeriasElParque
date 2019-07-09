using System;
using System.Collections;
using System.Text;

namespace Object
{
    /// <summary>
    /// clase de tipo objeto Reporte
    /// </summary>
    public class Report
    {

        public double quantity { set; get; }
        public string Name { set; get; }
        public double Total { set; get; }

        /// <summary>
        /// Constructor vacio de Reporte
        /// </summary>
       
        public Report() {

        }

        /// <summary>
        /// Constructor de Reportes
        /// </summary>
        /// <param name="quantity">Cantidad del producto del repote</param>
        /// <param name="Name">Nombre del producto del reporte</param>
        /// <param name="Total">Total del producto del reporte</param>
        /// 
        public Report( int quantity, String Name, double Total)
        {

            this.Name = Name;
            this.quantity = quantity;
            this.Total = Total;
        }


    }
}
