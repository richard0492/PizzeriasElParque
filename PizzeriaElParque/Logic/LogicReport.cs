using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Object;

namespace Logic
{
    /// <summary>
    /// Es la clase encargada de la capa logica de los reportes
    /// </summary>
    public class LogicReport
    {

        DataReport DataReport = new DataReport();

        /// <summary>
        /// Consulta un producto en la capa de datos usando un codigo especifico y devulve una lista con  sus datos.
        /// </summary>
        /// <param name="startDate">Fecha inicial del reporte</param>
        /// <param name="endDate">Fecha final del reporte </param>
        /// <param name="CodeProduct">Codigo del producto</param>
        /// <returns>Lista con la cantidad, total y nombre del producto</returns>
        public List<Report> ConsulReports_Product(DateTime startDate, DateTime endDate, int codeProduct)
        {

            List<Report> reports = new List<Report>();
            reports = DataReport.ConsulReports_Product(startDate, endDate, codeProduct);
            return reports;


        }
        /// <summary>
        /// Consulta varios productos en la capa de datos mediante un rango de fechas especifico y devulve una lista con datos de estos productos.
        /// </summary>
        /// <param name="startDate">Fecha inicial del reporte</param>
        /// <param name="endDate">Fecha final del reporte</param>
        /// <returns>Devuelve una lista de productos con su cantidad, nombre y total </returns>
        public List<Report> ConsulReports_BteweenDates(DateTime startDate, DateTime endDate)
        {

            List<Report> reports = new List<Report>();
            reports = DataReport.ConsulReports_BetweenDates(startDate,endDate);
            return reports;


        }

        /// <summary>
        /// Se encarga de convertir un objeto en formato de fecha de String a DateTime
        /// </summary>
        /// <param name="date">String en formato de feha</param>
        /// <returns>Objeto DateTime</returns>

        public DateTime ConvertDateTime(String date) {

            String[] Date = date.Split('-');
            if (Date[0].ToString() == null  || Date[0].ToString() == null || Date[0].ToString() == null) {

                DateTime novaliddate = new DateTime(1997, 01, 01);
                return novaliddate;

            }

            
            int year = int.Parse(Date[0].ToString());
            int month = int.Parse(Date[1].ToString());
            int day = int.Parse(Date[2].ToString());
            DateTime dateValue = new DateTime(year,month,day);

            return dateValue;

        }

        /// <summary>
        /// Valida si un objeto es de tipo numerico o no
        /// </summary>
        /// <param name="num">Objeto a validar</param>
        /// <returns>Retorna verdadero o falso</returns>

        public bool isnumber(object num)
        {
            bool isNum;

            double retNum;

            isNum = Double.TryParse(Convert.ToString(num), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);

            return isNum;


        }
    }
}