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

        String dataBase = @"server=localhost; user id=root; password=root; database=pizzeriaelparque";

        public List<Product> ConsulProducts()
        {
            List<Product> products = new List<Product>();
            return products;
        }


        public String ConsultProduct(String Product_Code)
        {
            String StringProduct = "";
            Product product = new Product();

            MySqlConnection connectionProduct = new MySqlConnection(dataBase);

            string query = "CALL ConsultarUnProducto(@pCodigo)";

            using (MySqlCommand cmd = new MySqlCommand(query, connectionProduct))
            {
                cmd.Parameters.AddWithValue("@pCodigo", Int32.Parse(Product_Code));

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

                StringProduct = product.code + " " + product.name + " " + product.description + " "
                + product.price + " " + product.MinInPrepara + " " + product.quantity + " " + product.enabled + " ";

            }

            return StringProduct;
        }

        public void DeleteProducts(int Product_Code)
        {
            string query = "CALL EliminarProducto(@p0)";

            MySqlConnection product = new MySqlConnection(dataBase);


            using (MySqlCommand cmd = new MySqlCommand(query, product))
            {

                cmd.Parameters.AddWithValue("@p0", Product_Code);
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
