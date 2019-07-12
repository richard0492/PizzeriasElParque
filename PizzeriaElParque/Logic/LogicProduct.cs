using System;
using System.Collections.Generic;
using System.Text;
using Object;
using Data;

namespace Logic
{
    public class LogicProduct
    {
        DataProducts dataProducts = new DataProducts();

        public void InsertProduct(int code, string name, string description, double price, int minInpreparation, int quantity)
        {
            Product product = new Product();

            // if (ConsultProduct(code.ToString()) == null)
            //    {

            product.code = code;
            product.name = name;
            product.description = description;
            product.price = price;
            product.MinInPrepara = minInpreparation;
            product.quantity = quantity;
            product.enabled = 's';

            dataProducts.InsertProduct(product);
            //   return true;

            //    } else{
            //    return false;
            //  }
        }

        public bool ModifyProduct(int code, string name, string description, double price, int minInpreparation, int quantity)
        {
            try
            {
                Product product = new Product();

                
                product.name = name;
                product.description = description;
                product.price = price;
                product.MinInPrepara = minInpreparation;
                product.quantity = quantity;
                product.enabled = 's';
                product.code = code;

                dataProducts.modifyProduct(product);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<Product> ConsulProducts()
        {
            List<Product> products = new List<Product>();

            products = dataProducts.ConsulProducts();

            return products;
        }

        public string ConsultProduct(String Product_Code)
        {
            Product product = new Product();
            product = dataProducts.ConsultProduct(Product_Code);

            return product.name + "/" + product.MinInPrepara + "/" + product.price;
        }

        /// <summary>
        /// Returns an object of product type with its characteristics
        /// </summary>
        /// <param name="Product_Code"> Product code to be consulted</param>
        /// <returns>object product</returns>
        public Product consultProductObject(String Product_Code)
        {
            return dataProducts.ConsultProduct(Product_Code);

            }

        public string ConsultProductCode(String Product_Code)
        {
            Product product = new Product();
            product = dataProducts.ConsultProducCode(Product_Code);

            return product.name + "/" + product.MinInPrepara + "/" + product.price;
        }

        public List<Product> ConsultProductEnabled()
        {
            List<Product> products = new List<Product>();
            DataProducts product = new DataProducts();

            products = product.ConsulProductsEnabled();

            return products;
        }


        public bool DeleteProduct(int product_Code, char enabled)
        {
            try
            {
                dataProducts.DeleteProducts(product_Code, enabled);
                return true;
            }
            catch
            {
                return false;
            }
            
        }


    }
}
