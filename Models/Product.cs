using Candymania.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowDemo;


namespace Candymania.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public int? Stock { get; set; }
        public string? Description { get; set; }
        public bool? Present { get; set; }

        public virtual Order? Order { get; set; }
        public virtual ICollection<Category> Kategorier { get; set; } = new List<Category>();

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }


        public static void GetChocolateProducts()
        {

            while (true)
            {

                List<string> Chokladprodukter = new List<string> { "Chokladprodukter", "[S] Snickers", "[T] Twix", "[D] Daim", "[K] Kexchoklad", "[B]Bounty", "[X] Gå tillbaka" };

                var windowChoklad = new Window("Chokladprodukter", 2, 10, Chokladprodukter);
                windowChoklad.Draw();

                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case 's':
                        ItemsInfo.BuyOrDescription(12);
                        break;
                    case 't':
                        ItemsInfo.BuyOrDescription(13);
                        break;
                    case 'd':
                        ItemsInfo.BuyOrDescription(14);
                        break;
                    case 'k':
                        ItemsInfo.BuyOrDescription(15);
                        break;
                    case 'b':
                        ItemsInfo.BuyOrDescription(16);
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

            public static void GetTablettaskProducts()
            {

                while (true)
                {

                    List<string> Tablettaskprodukter = new List<string> { "Tablettaskar", "[Z] Zoo", "[P] PimPim", "[F] Fruxo", "[S] Smurf", "[T]Tuttifrutti", "[X] Gå tillbaka" };
                    var windowCart = new Window("Tablettaskprodukter", 2, 10, Tablettaskprodukter);
                    windowCart.Draw();

                    var key = Console.ReadKey(true);
                    switch (key.KeyChar)
                    {
                        case 'z':
                            ItemsInfo.BuyOrDescription(7);
                        break;
                        case 'p':
                            ItemsInfo.BuyOrDescription(8);
                        break;
                        case 'f':
                            ItemsInfo.BuyOrDescription(9);
                        break;
                        case 's':
                            ItemsInfo.BuyOrDescription(10);
                        break;
                        case 't':
                        ItemsInfo.BuyOrDescription(11);
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
            public static void GetPåsgodisProducts()
            {

                while (true)
                {

                    List<string> Påsgodisprodukter = new List<string> { "Påsgodis", "[B] Bilar", "[P] Polly", "[D] Djungelvrål", "[M] M&Ms", "[G] Gott&Blandat", "[X] Gå tillbaka" };
                    var windowCart = new Window("Påsgodisprodukter", 2, 10, Påsgodisprodukter);
                    windowCart.Draw();

                    var key = Console.ReadKey(true);
                    switch (key.KeyChar)
                    {
                        case 'b':
                        ItemsInfo.BuyOrDescription(2);
                        break;
                        case 'p':
                        ItemsInfo.BuyOrDescription(3);
                        break;
                        case 'd':
                            ItemsInfo.BuyOrDescription(4);
                        break;
                        case 'm':
                            ItemsInfo.BuyOrDescription(5);
                        break;
                        case 'g':
                        ItemsInfo.BuyOrDescription(6);
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

