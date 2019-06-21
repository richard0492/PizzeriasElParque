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

        public bool ModifyProduct(Product product, String product_Code)
        {
            return false;
        }

        public List<Product> ConsulProducts()
        {
            List<Product> products = new List<Product>();
            return products;
        }

        public String ConsultProduct(String Product_Code)
        {
            String ProductData = dataProducts.ConsultProduct(Product_Code);
            return ProductData;
        }

        public void DeleteProducts(int number)

        {
            dataProducts.DeleteProducts(number);

        }

        public bool DeleteProduct(String product_Code)
        {
            return false;
        }


    }
}
