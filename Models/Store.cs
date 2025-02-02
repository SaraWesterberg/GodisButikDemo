using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowDemo;

namespace Candymania.Models
{
    internal class Store
    {
        public static void CandyMenu()
        {
            while (true)
            {
                Console.Clear();

                List<string> KategoriText = new List<string> { "Vad är du sugen på idag?", "[C] Choklad", "[T] Tablettask", "[P] Påsgodis", "[X] Gå tillbaka till kundsidan" };
                var windowCart = new Window("Kategorier", 2, 2, KategoriText);
                windowCart.Draw();

                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'c':
                        Product.GetChocolateProducts();
                        break;
                    case 't':
                        Product.GetTablettaskProducts();
                        break;
                    case 'p':
                        Product.GetPåsgodisProducts();
                        break;
                    case 'x':
                        Customer.CustMenu();
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}

