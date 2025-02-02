using Candymania.Data;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Candymania.Models
{
    internal class Pay
    {
        public enum PayMenu
        {
            Klarna,
            PayPal 
        }


        public static void ShowPayMenu()
        {
            using (var myDb = new Models.MyDbContext())

                Console.Clear();
            Console.WriteLine("Välj betalternativ:");
            Console.WriteLine("1. Klarna");
            Console.WriteLine("2. Paypal");

            int choice = Convert.ToInt32(Console.ReadLine());
            int shippingChoise = choice == 1 ? (int)PayMenu.Klarna : (int)PayMenu.PayPal;

            Console.WriteLine($"Valt betalsätt: " + choice);

            Console.WriteLine("---------------------------------------------------------");

            AddCustomer.AddCustomerPay();
            
            Console.WriteLine("---------------------------------------------------------");
            
            Console.WriteLine("Tack för din beställning");
            Console.ReadKey();

            ClearVarukorg();
            
            Homepage.StartScreen();
        }
        public static void ClearVarukorg()
        {
            using (var myDb = new Models.MyDbContext())
            {
                Console.Clear();
                Console.WriteLine("Tömmer varukorgen...");

                var allItems = myDb.Orders.ToList();
                if (allItems.Count > 0)
                {
                    myDb.Orders.RemoveRange(allItems);
                    myDb.SaveChanges();
                    Console.WriteLine("Varukorgen är nu tom.");
                }
                else
                {
                    Console.WriteLine("Varukorgen är redan tom.");
                }

                Console.WriteLine("\nTryck på valfri tangent för att återgå.");
                Console.ReadKey();
            }
        }

    }
}
 
