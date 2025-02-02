using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using WindowDemo;

namespace Candymania.Models
{
    internal class Homepage
    {
        public static void StartScreen()
        {

                Customer.ShowSpecialItems();

            while (true)
            {
                Console.Clear();
                List<string> loginText = new List<string> { "Login as", "[A] Admin", "[C] Customer", };
                var windowCart = new Window("Homepage", 2, 2, loginText);
                windowCart.Draw();

                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 'a':
                        Admin.AdminMenu();
                        break;
                    case 'c':
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
