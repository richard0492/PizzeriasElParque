using System;
using System.Collections.Generic;
using System.Text;
using Object;
using MySql.Data.MySqlClient;
using System.Data;
using Object;

namespace Data
{
    public class DataReport
    {
        string connectionString = "server=localhost;user id=root; password=root;persistsecurityinfo=True;database=pizzeriaelparque";

        public Report ConsulReports_Product(DateTime startDate, DateTime endDate, int CodeProduct)
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
             return report;


          
        }

     
    }
}
