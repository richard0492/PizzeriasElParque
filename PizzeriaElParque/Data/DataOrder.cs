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

            MySqlConnection connectionUser = new MySqlConnection(connectionString);

            string query = "CALL consultarTodasLasOrdenes()";

            using (MySqlCommand cmd = new MySqlCommand(query, connectionUser))
            {

                connectionUser.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new Order(int.Parse(reader[0].ToString()),reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), int.Parse(reader[5].ToString())));

                    }


                }
                connectionUser.Close();
            }

            return orders;
        }

        public Order ConsultOder(String Odere_ID)
        {
            Order order = new Order();
            return order;
        }

        public void modifyEstadeOrder(int ordenId, int estadeId) {

            string query = "CALL ModificarEstadoOrden(@P0,@P1)";

            MySqlConnection conn = new MySqlConnection(connectionString);

            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@P0", ordenId);
                command.Parameters.AddWithValue("@P1", estadeId);


                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }



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
                            orders.Add(new LineOrder(int.Parse(reader[0].ToString()),int.Parse(reader[1].ToString()), reader[2].ToString(), int.Parse(reader[3].ToString()), Convert.ToDouble(reader[4].ToString()),DateTime.Parse(reader[5].ToString()),int.Parse(reader[6].ToString())));

                        }
                    
                    
                }
                connectionUser.Close();
            }



            return orders;
        }

        public Boolean insertLineOrder(int quantity, DateTime date, DateTime hour,int orderId, int productId)
        {

            string query = "CALL InsertarLineaOrden(@P0,@P1,@P2,@P3,@P4)";

            MySqlConnection conn = new MySqlConnection(connectionString);

            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@P0", quantity);
                command.Parameters.AddWithValue("@P1", date);
                command.Parameters.AddWithValue("@P2", hour);
                command.Parameters.AddWithValue("@P3", orderId);
                command.Parameters.AddWithValue("@P4", productId);


                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }

            return false;

        }

        public Boolean modifyLineOrder(int quantity, DateTime date, DateTime hour, int orderId, int productId, int lineOrderID)
        {

            string query = "CALL ModificarLineaOrden(@P0,@P1,@P2,@P3,@P4,@P5)";

            MySqlConnection conn = new MySqlConnection(connectionString);

            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@P0", quantity);
                command.Parameters.AddWithValue("@P1", date);
                command.Parameters.AddWithValue("@P2", hour);
                command.Parameters.AddWithValue("@P3", orderId);
                command.Parameters.AddWithValue("@P4", productId);
                command.Parameters.AddWithValue("@P5", lineOrderID);



                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
                return true;
            }

            return false;

        }

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
