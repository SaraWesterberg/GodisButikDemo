using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowDemo;

namespace Candymania.Models
{
    internal class Customer
    {
        public int Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? Age { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();
        

        public static void CustMenu()
        {
            while (true)
            {
                Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<string> topText1 = new List<string> { "🍬  CandyMania 🍬", "Här finns något för alla" };
            var windowTop1 = new Window("", 2, 1, topText1);
            windowTop1.Draw();

                ShowSpecialItems();
            
                List<string> KundText = new List<string> { "Vad vill du göra idag?", "[H] Homepage", "[G] Godisbutiken", "[V] Varukorgen", "[S] Sök", "[X] Gå tillbaka till LogIn" };
                var windowCart = new Window("Kund", 2, 6, KundText);
                windowCart.Draw();

                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'h':
                        Homepage.StartScreen();
                        break;
                    case 'g':
                        Store.CandyMenu();
                        break;
                    case 'v':
                        Order.OrderMenu();
                        break;
                    case 's':
                        Searchfunction.SearchProducts();
                        break;
                    case 'x':
                        Homepage.StartScreen();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        Console.ReadKey();
                        break;
                }
            }                                      
        }
        public static void ShowSpecialItems()
        {
            List<string> SpecialItems = new List<string> { };
            using (var myDb = new Models.MyDbContext())
            {

                foreach (var product in myDb.Products)
                {

                    if (product.Present == true)
                    {
                        SpecialItems.Add($"{product.Name.PadRight(12)} Beskrivning: {product.Description.PadRight(15)}Pris:    {product.Price}");
                      
                    }
                }
            }
            var windowItems = new Window("Erbjudanden", 2, 20, SpecialItems);
            windowItems.Draw();
        }
    }
}

