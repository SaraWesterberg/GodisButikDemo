using Candymania.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candymania.Data
{
    internal class AddProduct
    {
        public static void AddP()
        {
            while (true)
            {
                using (var myDb = new Models.MyDbContext())
                {

                    myDb.Products.Add(new Product  { Name = "Bilar", Price = 18, Stock = 42, Description = "Sveriges mest köpta bil!", Present = false, SupplierId = 1 });
                    myDb.Products.Add(new Product { Name = "Polly", Price = 35, Stock = 21, Description = "Skumtoppar dragerade med choklad", Present = false, SupplierId = 1 });
                    myDb.Products.Add(new Product { Name = "Djungelvrål", Price = 30, Stock = 18, Description = " Vrålsalta Djungeldjur", Present = true, SupplierId = 1 });
                    myDb.Products.Add(new Product { Name = "M&Ms", Price = 50, Stock = 35, Description = "Chokladgodis i olika färger", Present = false, SupplierId = 2 });
                    myDb.Products.Add(new Product { Name = "Gott&Blandat", Price = 25, Stock = 12, Description = "Behövs beskrivning?", Present = false, SupplierId = 1 });
                    myDb.Products.Add(new Product { Name = "Zoo", Price = 5, Stock = 14, Description = "Zoodjur med smaker av vattenmelon", Present = true, SupplierId = 1 });
                    myDb.Products.Add(new Product { Name = "PimPim", Price = 5, Stock = 19, Description = "Båtar med smak av hallon", Present = false, SupplierId = 1 });
                    myDb.Products.Add(new Product { Name = "Fruxo", Price = 5, Stock = 21, Description = "Gelegodis med fruksmak", Present = false, SupplierId = 1 });
                    myDb.Products.Add(new Product { Name = "Smurf", Price = 7, Stock = 22, Description = "Med smak av apelsin, aronia, vindruva och fläder", Present = false, SupplierId = 5 });
                    myDb.Products.Add(new Product { Name = "TuttiFrutti", Price = 5, Stock = 15, Description = "En blandning av hallon, päron och citron", Present = false, SupplierId = 3 });
                    myDb.Products.Add(new Product { Name = "Snickers", Price = 19, Stock = 32, Description = "Innehåller nötter, kola och choklad", Present = true, SupplierId = 2 });
                    myDb.Products.Add(new Product { Name = "Twix", Price = 15, Stock = 19, Description = "Mjölkchoklad, kex och cola", Present = false, SupplierId = 2 });
                    myDb.Products.Add(new Product { Name = "Daim", Price = 15, Stock = 13, Description = "Mandelknäcke med choklad", Present = false, SupplierId = 4 });
                    myDb.Products.Add(new Product { Name = "Kexchoklad", Price = 14, Stock = 2, Description = "Go och glá, kexchoklad", Present = false, SupplierId = 1 });
                    myDb.Products.Add(new Product { Name = "Bounty", Price = 18, Stock = 18, Description = "Kokosfylld chokladkaka", Present = false, SupplierId = 2 });

                    myDb.Categories.Add(new Category { Categoryname = "Choklad" });
                    myDb.Categories.Add(new Category { Categoryname = "Tablettsk" });
                    myDb.Categories.Add(new Category { Categoryname = "Påsgodis" });

                    myDb.SaveChanges();

                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void ShowProdList()
        {
            using (var myDb = new Models.MyDbContext())
            {

                Console.WriteLine("Lista av produkter: ");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(
                    $"{"ProduktId".PadRight(10)} | {"Name".PadRight(15)} | {"Price".PadRight(8)} | {"Lagersaldo".PadRight(12)} | {"Leverantör".PadRight(10)} | {"Description".PadRight(30)}");

                Console.ResetColor();
                Console.WriteLine(new string('-', 115)); 

                foreach (var produkt in myDb.Products)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(
                        $"{produkt.Id.ToString().PadRight(10)} | " +
                        $"{produkt.Name?.PadRight(15) ?? "Okänd"} | " +
                        $"{produkt.Price?.ToString().PadRight(8) ?? "N/A"} | " +
                        $"{produkt.Stock?.ToString().PadRight(12) ?? "N/A"} | " +
                        $"{produkt.SupplierId.ToString().PadRight(10)} | " +
                        $"{produkt.Description.PadRight(30)}");
                }
                Console.ResetColor();
            }
        }
    }
}
