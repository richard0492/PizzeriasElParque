using System;
using System.Collections.Generic;
using System.Text;
using Object;
using MySql.Data.MySqlClient;
using System.Data;
using Object;

namespace Data
{
    /// <summary>
    /// Es la clase encargada de la capa de datos de los reportes.
    /// </summary>
    public class DataReport
    {
        string connectionString = "server=localhost;user id=root; password=root;persistsecurityinfo=True;database=pizzeriaelparque";

        /// <summary>
        /// Consulta un producto en la base de datos mediante un strore procedure usando un codigo especifico y devulve una lista con  sus datos.
        /// </summary>
        /// <param name="startDate">Fecha inicial del reporte</param>
        /// <param name="endDate">Fecha final del reporte </param>
        /// <param name="CodeProduct">Codigo del producto</param>
        /// <returns>Lista con la cantidad, total y nombre del producto</returns>
        public List<Report> ConsulReports_Product(DateTime startDate, DateTime endDate, int CodeProduct)
        {

            List<Report> reports = new List<Report>();
            string query = "CALL RegistroVentasPorProducto(@P0,@P1,@P2)";
            MySqlConnection connection = new MySqlConnection(connectionString);
            Report report = new Report();


            using (MySqlCommand command = new MySqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@P0", startDate);
                command.Parameters.AddWithValue("@P1", endDate);
                command.Parameters.AddWithValue("@P2", CodeProduct);



                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                        report = new Report(int.Parse(reader[0].ToString()),
                        reader[1].ToString(), double.Parse(reader[2].ToString()));
                }
                connection.Close();


            }
            reports.Add(report);
            return reports;



        }
        /// <summary>
        /// Consulta varios productos en la base de datos mediante un rango de fechas especifico y devulve una lista con datos de estos productos.
        /// </summary>
        /// <param name="startDate">Fecha inicial del reporte</param>
        /// <param name="endDate">Fecha final del reporte</param>
        /// <returns>Devuelve una lista de productos con su cantidad, nombre y total </returns>
        public List<Report> ConsulReports_BetweenDates(DateTime startDate, DateTime endDate)
        {

            List<Report> reports = new List<Report>();
            string query = "CALL RegistroVentas(@P0,@P1)";
            MySqlConnection connection = new MySqlConnection(connectionString);
            Report report = new Report();


            using (MySqlCommand command = new MySqlCommand(query, connection))
            {

                command.Parameters.AddWithValue("@P0", startDate);
                command.Parameters.AddWithValue("@P1", endDate);
              
                connection.Open();

                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read()) { 
                       
                        report = new Report(int.Parse(reader[0].ToString()),
                        reader[1].ToString(), double.Parse(reader[2].ToString()));
                        reports.Add(report);
                        }
                }
                connection.Close();


            }
            return reports;



        }

    }
}
