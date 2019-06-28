using System;
using System.Collections.Generic;
using System.Text;
using Object;
using MySql.Data.MySqlClient;
using System.Data;

namespace Data
{
    public class DataProducts
    {

        String dataBase = @"server=localhost; user id=root; password=ucr.info; database=pizzeriaelparque";

        public List<Product> ConsulProducts()
        {
            List<Product> products = new List<Product>();

            string query = "CALL VerProdutos()";

            MySqlConnection conn = new MySqlConnection(dataBase);

            MySqlCommand command = new MySqlCommand(query, conn);


            conn.Open();

            MySqlDataAdapter commandDatabase = new MySqlDataAdapter(query,conn);

            DataSet dataSet = new DataSet();

            commandDatabase.Fill(dataSet, "Product");

            foreach (DataTable tabla in dataSet.Tables)
            {
                foreach (DataRow dr in tabla.Rows)
                {
                    Product product = new Product(Convert.ToInt32(dr.ItemArray[0].ToString()),dr.ItemArray[1].ToString(), dr.ItemArray[2].ToString(),Convert.ToDouble(dr.ItemArray[3].ToString()),Convert.ToInt32(dr.ItemArray[4].ToString()),Convert.ToInt32(dr.ItemArray[5].ToString()));

                    products.Add(product);
                }
            }

            conn.Close();




            return products;
        }

        public void modifyProduct(Product product) {
            string query = "CALL ModificarProducto(@P0,@P1,@P2,@P3,@P4,@P5,@P6)";

            MySqlConnection conn = new MySqlConnection(dataBase);

            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@P0", product.name);
                command.Parameters.AddWithValue("@P1", product.description);
                command.Parameters.AddWithValue("@P2", product.price);
                command.Parameters.AddWithValue("@P3", product.MinInPrepara);
                command.Parameters.AddWithValue("@P4", product.quantity);
                command.Parameters.AddWithValue("@P5", product.enabled);
                command.Parameters.AddWithValue("@P6", product.code);


                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }

        public List<Product> ConsulProductsEnabled()
        {
            List<Product> products = new List<Product>();
            string query = "Call CompararProducto()";

            DBConection connection = new DBConection();


            connection.Connection().Open();

            MySqlDataAdapter commandDatabase = new MySqlDataAdapter(query, connection.Connection());

            DataSet dataSet = new DataSet();

            commandDatabase.Fill(dataSet, "Product");

            foreach (DataTable tabla in dataSet.Tables)
            {
                foreach (DataRow dr in tabla.Rows)
                {
                    Product product = new Product(dr.ItemArray[0].ToString(), Convert.ToInt32(dr.ItemArray[1].ToString()));

                    products.Add(product);
                }
            }

            connection.Connection().Close();
            return products;
        }


        public Product ConsultProduct(String Product_Code)
        {
            Product product = new Product();

            MySqlConnection connectionProduct = new MySqlConnection(dataBase);

            string query = "CALL ConsultarProducto(@P0)";

            using (MySqlCommand cmd = new MySqlCommand(query, connectionProduct))
            {
                cmd.Parameters.AddWithValue("@P0", Int32.Parse(Product_Code));

                connectionProduct.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        product = new Product(Int32.Parse(reader[0].ToString()),
                        reader[1].ToString(), reader[2].ToString(), double.Parse(reader[3].ToString()),
                        Int32.Parse(reader[4].ToString()), Int32.Parse(reader[5].ToString()),
                        char.Parse(reader[6].ToString()));
                }
                connectionProduct.Close();

                
            }


            return product;
        }

        public Product ConsultProducCode(String Product_Code)
        {
            Product product = new Product();

            MySqlConnection connectionProduct = new MySqlConnection(dataBase);

            string query = "CALL ConsultarProductoCodigo(@P0)";

            using (MySqlCommand cmd = new MySqlCommand(query, connectionProduct))
            {
                cmd.Parameters.AddWithValue("@P0", Int32.Parse(Product_Code));

                connectionProduct.Open();

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                        product = new Product(Int32.Parse(reader[0].ToString()),
                        reader[1].ToString(), reader[2].ToString(), double.Parse(reader[3].ToString()),
                        Int32.Parse(reader[4].ToString()), Int32.Parse(reader[5].ToString()),
                        char.Parse(reader[6].ToString()));
                }
                connectionProduct.Close();


            }


            return product;
        }

        public void DeleteProducts(int Product_Code, char enabled)
        {
            string query = "CALL ModificarHabilitadoProducto(@p0,@p1)";

            MySqlConnection product = new MySqlConnection(dataBase);


            using (MySqlCommand cmd = new MySqlCommand(query, product))
            {

                cmd.Parameters.AddWithValue("@p0", enabled);
                cmd.Parameters.AddWithValue("@p1", Product_Code);
                product.Open();
                cmd.ExecuteNonQuery();
                product.Close();
            }
        }

        public void InsertProduct(Product product)
        {

            string query = "CALL InsertarProducto(@P0,@P1,@P2,@P3,@P4,@P5,@P6)";

            MySqlConnection conn = new MySqlConnection(dataBase);

            using (MySqlCommand command = new MySqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@P0", product.code);
                command.Parameters.AddWithValue("@P1", product.name);
                command.Parameters.AddWithValue("@P2", product.description);
                command.Parameters.AddWithValue("@P3", product.price);
                command.Parameters.AddWithValue("@P4", product.MinInPrepara);
                command.Parameters.AddWithValue("@P5", product.quantity);
                command.Parameters.AddWithValue("@P6", product.enabled);


                conn.Open();
                command.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
