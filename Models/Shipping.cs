using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowDemo;

namespace Candymania.Models
{
    internal class Shipping
    {
        public enum ShippingMenu
        {
            DHL = 39,
            PostNord = 29
        }

       
            public static void ShowShippingMenu()
            {
            Console.Clear();
                Console.WriteLine("Välj fraktalternativ:");
                Console.WriteLine("1. DHL (39 SEK)");
                Console.WriteLine("2. PostNord (29 SEK)");

                int choice = Convert.ToInt32(Console.ReadLine());
                int shippingPrice = choice == 1 ? (int)ShippingMenu.DHL : (int)ShippingMenu.PostNord;

                Console.WriteLine($"Valt frakt: {(ShippingMenu)shippingPrice} med pris: {shippingPrice} SEK");

                Console.WriteLine($"Totalt pris med moms och frakt: {TotalCostWithTaxesAndShipping(shippingPrice):C}");

            Console.ReadKey();
            Pay.ShowPayMenu();
            }

            public static decimal TotalCostWithTaxesAndShipping(int shippingPrice)
            {
                using (var myDb = new Models.MyDbContext())
                {
                    var total = myDb.Orders.Where(c => c.Total > 0).Sum(c => c.Total);
                    return total * 1.25m + shippingPrice; 
                }
            }
        }
    }
