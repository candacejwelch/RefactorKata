using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    internal class Program
    {
        private static void Main()
        {
            var conn = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;");

            var cmd = conn.CreateCommand();
            cmd.CommandText = "select * from Products";
           
            var reader = cmd.ExecuteReader();
            var products = new List<Product>();

            //TODO: Replace with Dapper
            while (reader.Read())
            {
                var prod = new Product {Name = reader["Name"].ToString()};
                products.Add(prod);
            }
            Console.WriteLine("Products Loaded!");
            conn.Dispose();
            
            foreach (var productName in products)
            {
                Console.WriteLine(productName.Name);
            }

            //extract get product method
        }
    }
}
