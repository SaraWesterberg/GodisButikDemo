using Candymania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Candymania.Data
{
    internal class QueryHelper
    {
        private static readonly string connString = "Server=tcp:sarawserver.database.windows.net,1433;Initial Catalog=MyDbSara;Persist Security Info=False;User ID=SaraWesterberg;Password=MyPassword1!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static void Querys()
        {
            while (true)
            {
                using (var myDb = new Models.MyDbContext())
                {
                    var products = myDb.Products.ToList();

                    Console.WriteLine(" [1] Högst pris \n [2] Lägsta pris \n [3] Högst lagerantal \n [4] Slut i lager \n [X] Gå tillbaka ");
                    var key = Console.ReadKey(true);

                    switch (key.KeyChar)
                    {
                        case '1':
                            using (var connection = new SqlConnection(connString))
                            {
                                connection.Open();
                                var maxPriceProduct = connection.Query<Product>("SELECT TOP 1 * FROM Products ORDER BY Price DESC").FirstOrDefault();

                                if (maxPriceProduct != null)
                                    Console.WriteLine($"Högsta pris: {maxPriceProduct.Name}  Pris: {maxPriceProduct.Price} kr (hämtat med Dapper!)");
                            }
                            break;
                        case '2':
                            var minPrice = (from c in myDb.Products
                                            select c.Price).Min();
                            foreach (var product in products)
                            {
                                if (product.Price == minPrice)
                                {
                                    Console.WriteLine($"Lägsta pris: {product.Name}   Pris: {product.Price} kronor");
                                }
                            }
                            break;
                        case '3':
                            var highestInStock = (from c in myDb.Products
                                                  select c.Stock).Max();
                            foreach (var product in products)
                            {
                                if (product.Stock == highestInStock)
                                {
                                    Console.WriteLine($"Högsta lagerantal: {product.Name}  Antal produkter i lager: {product.Stock} st ");
                                }
                            }
                            break;
                        case '4':
                            var OutOfStock = (from c in myDb.Products
                                              where c.Stock == 0
                                              select c).ToList();
                            if (OutOfStock.Count != 0)
                            {
                                foreach (var product in products)
                                {
                                    if (product.Stock == 0)
                                    {
                                        Console.WriteLine($"Produkt: {product.Name} är slut i lagret!");
                                    }
                                    if (product.Stock < 0)
                                    {
                                        Console.WriteLine("Alla produkter finns i lager!");
                                    }
                                }
                            }
                            break;
                        case 'x':
                            Admin.AdminMenu();
                            break;
                    }
                    Console.WriteLine();
                    Console.ReadKey();
                    Console.Clear();

                }
            }
        }
    }
}
       
       

