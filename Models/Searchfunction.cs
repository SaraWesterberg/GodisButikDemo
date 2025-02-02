using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candymania.Models
{
    internal class Searchfunction
    {
        public static void SearchProducts()
        {
            Console.WriteLine("Sök produkt: ");
            var searchWord = Console.ReadLine();

            using (var myDb = new MyDbContext())
            {
                var searchedProduct = from c in myDb.Products
                                      where c.Name.Contains(searchWord)
                                      select c;

                foreach (var product in searchedProduct)
                {
                    Console.WriteLine($"Id: {product.Id} Namn: {product.Name} Pris: {product.Price} ");
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
