using Candymania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowDemo;

namespace Candymania.Data
{
    internal class ItemsInfo
    {
        public static void BuyOrDescription(int productID)
        {
            Console.Clear();
            List<string> Itemtext = new List<string> { "[1] Information om produkten", "[2] Lägg till produkten i varukorgen", "[X] Tillbaka till Godisbutiken" };
            var windowcart = new Window("Item", 2, 2, Itemtext);
            windowcart.Draw();
            var key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                case '1':
                    InfoAboutItems(productID);
                    break;
                case '2':
                    Order.AddProductToOrder(productID);
                    break;
                case '3':
                    ItemsInfo.BuyOrDescription(productID);
                    break;
                default:
                    Console.WriteLine("Wrong Input)");
                    Console.ReadKey();
                    break;
            }
        }
        public static void InfoAboutItems(int productId)
        {
            using (var myDb = new Models.MyDbContext())
            {


                var chosenProduct = (from c in myDb.Products
                                     where c.Id == productId
                                     select c).SingleOrDefault();
                if (chosenProduct != null)
                {
                    
                    Console.WriteLine($"Namn: " + chosenProduct.Name + "    Beskrivning: " + chosenProduct.Description + "    Pris: " + chosenProduct.Price);
                    Console.WriteLine("Tryck på valfri knapp för att backa");
                    Console.ReadKey();
                    BuyOrDescription(productId);

                }
            }
        }
    }
}
