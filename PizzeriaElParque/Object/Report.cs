using System;
using System.Collections;
using System.Text;

namespace Object
{
    public class Report
    {
        public int Report_Id { get; set; }
        public DateTime Report_Date { get; set; }
        public ArrayList Report_sales = new ArrayList();
        public string NameR { set; get; }
        public double priceR { set; get; }
        public double quentityR { set; get; }
        public double TotalR { set; get; }

        public Report() {

        }

        public Report( int quantity, String Name, double Total)
        {

            this.NameR = Name;
         
            this.quentityR = quantity;
            this.TotalR = Total;
        }


    }
}
