using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Object;

namespace Logic
{
    public class LogicReport
    {

        DataReport DataReport = new DataReport();

        public Report ConsulReports_Product(DateTime startDate, DateTime endDate, int codeProduct)
        {

            Report report = new Report();
            report = DataReport.ConsulReports_Product(startDate, endDate, codeProduct);
            return report;


        }


    }
}