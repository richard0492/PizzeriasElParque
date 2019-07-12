using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Object;

namespace Data
{
    public class DataOrder
    {
        string connectionString = "server=localhost;user id=root; password=root ;persistsecurityinfo=True;database=pizzeriaelparque";


        public List<Order> ConsulOders()
        {
            List<Order> orders = new List<Order>();
            return orders;
        }

        public Order ConsultOder(String Odere_ID)
        {
            Order order = new Order();
            return order;
        }

        public List<LineOrder> ConsultLineOder(int Oder_ID)
        {
            List<LineOrder> orders = new List<LineOrder>();


            MySqlConnection connectionUser = new MySqlConnection(connectionString);

            string query = "CALL ConsultarLineaOrden(@p0)";

            using (MySqlCommand cmd = new MySqlCommand(query, connectionUser))
            {
                cmd.Parameters.AddWithValue("@p0", Oder_ID);


                connectionUser.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                        while (reader.Read())
                        {
                            orders.Add(new LineOrder(int.Parse(reader[0].ToString()),int.Parse(reader[1].ToString()), reader[2].ToString(), int.Parse(reader[3].ToString()), Convert.ToDouble(reader[4].ToString())));

                        }
                    
                    
                }
                connectionUser.Close();
            }



            return orders;
        }
        /// <summary>
        /// Método para insertar una orden a la base de datos
        /// </summary>
        /// <param name="lineOrderToAdd"></param>
        /// <returns> confirma la insercción con un boolean</returns>
        public Boolean insertLineOrder(LineOrder lineOrderToAdd)
        {

            string query = "CALL InsertarLineaOrden(@P0,@P1,@P2)";

            MySqlConnection conection = new MySqlConnection(connectionString);

            using (MySqlCommand command = new MySqlCommand(query, conection))
            {
                command.Parameters.AddWithValue("@P0", lineOrderToAdd.quantity);
                command.Parameters.AddWithValue("@P1",lineOrderToAdd.orderId);
                command.Parameters.AddWithValue("@P2", lineOrderToAdd.productId);
               


                conection.Open();
                command.ExecuteNonQuery();
                conection.Close();
                return true;
            }

           

        }
        /// <summary>
        /// Método para insertar una línea de orden a la base de datos
        /// </summary>
        /// <param name="orderToInsert"></param>
        /// <returns> confirma la insercción</returns>
        public Boolean insertOrder(Order orderToInsert)
        {
           
            
                string query = "CALL InsertarOrden(@P0,@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)";

                MySqlConnection conection = new MySqlConnection(connectionString);

                using (MySqlCommand command = new MySqlCommand(query, conection))
                {
                    command.Parameters.AddWithValue("@P0", orderToInsert.estadeId);
                    command.Parameters.AddWithValue("@P1", orderToInsert.partyId);
                    command.Parameters.AddWithValue("@P2", orderToInsert.nameClient);
                    command.Parameters.AddWithValue("@P3", orderToInsert.additional);
                    command.Parameters.AddWithValue("@P4", orderToInsert.address);
                    command.Parameters.AddWithValue("@P5", orderToInsert.phone);
                    command.Parameters.AddWithValue("@P6", orderToInsert.orderType);
                    command.Parameters.AddWithValue("@P7", orderToInsert.orderID);
                    command.Parameters.AddWithValue("@P8", orderToInsert.tableNumber);


                    conection.Open();
                    command.ExecuteNonQuery();
                    conection.Close();
                    return true;
                }
            
            
            



        }

        
        /// <summary>
        /// Método que consulta el Id de la última orden insertada
        /// </summary>
        /// <returns> Retorna el Id de la última orden insertada</returns>
        public int LastOrder()
        {

            string query = "SELECT UltimaOrden()";

            MySqlConnection conn = new MySqlConnection(connectionString);

            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
               
                conn.Open();
                using (IDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return int.Parse(reader[0].ToString());
                    }


                }
                conn.Close();
            }

            return 0;

        }
    }
}
