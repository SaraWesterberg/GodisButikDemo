using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WindowDemo;

namespace Candymania.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }                       //Feldöpt från början. Totalt är priset
        public int Quantity { get; set; }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string Product { get; set; }
        

        enum OrderChoises
        {
            Visa_allt,
            Ändra_antal_på_produkten,
            Radera_produkt,
            Välj_betala,
            Återgå_till_Butiken

        }
         
        public static void OrderMenu()
        {
            Console.Clear();
                bool loop = true;
                while (loop)
                {
                    foreach (int i in Enum.GetValues(typeof(Order.OrderChoises)))
                    {
                        Console.WriteLine(i + " . " + Enum.GetName(typeof(Order.OrderChoises), i).Replace('_', ' '));
                    }

                    if (int.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int nr))
                    {
                        switch ((Order.OrderChoises)nr)
                        {
                            case Order.OrderChoises.Visa_allt:
                                Order.ShowAllProductsInOrder();
                                break;
                        case Order.OrderChoises.Ändra_antal_på_produkten:
                            Order.ChangeOrderProducts();
                            break;
                            case Order.OrderChoises.Radera_produkt:
                                Order.DeleteOrderProduct();
                                break;
                        case Order.OrderChoises.Välj_betala:
                            Shipping.ShowShippingMenu();
                            break;
                            case Order.OrderChoises.Återgå_till_Butiken:
                                loop = false;
                                break;
                            default:
                                Console.WriteLine("Fel nummer");
                                break;

                        }
                    }
                    else
                    {
                        Console.WriteLine("Fel inmatning");
                    }
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        public static void ShowAllProductsInOrder()
        {
            using (var myDb = new Models.MyDbContext())
            {
                Console.WriteLine("Produkter i varukorgen: ");

                foreach (var order in myDb.Orders)
                {
                    {
                        Console.WriteLine($"Id: {order.Id}   {order.Product}"); 
                    }
   
                }
            }
        }


        public static void AddProductToOrder(int productId)
        {
            using (var myDb = new Models.MyDbContext())
            {
                var chosenProduct = (from c in myDb.Products
                                     where c.Id == productId
                                     select c).SingleOrDefault();
                if (chosenProduct != null) 
                { 
                var order = new Order();
                order.Date = DateTime.Now;
                    order.Product = chosenProduct.Name.ToString();
                    order.Total = Convert.ToDecimal(chosenProduct.Price);
                    order.CustomerId = 1;
                    myDb.Orders.Add(order);
                    myDb.SaveChanges();

                    Console.WriteLine($"Du har lagt till  " + chosenProduct.Name + " varukorgen" );
                    Console.WriteLine($"Totalen for ordern är: " + PriceWithTaxes());
                
                }
            }
        }
        public static decimal PriceWithTaxes()
        {
            using (var myDb = new Models.MyDbContext())
            {
                
                var total = (from c in myDb.Orders
                             where c.Total > 0
                             select c.Total).Sum();

                
                var totalWithTax = total * 1.25m;

                return totalWithTax;
            }
        }

        public static void ChangeOrderProducts()
        {
            using (var myDb = new Models.MyDbContext())
            {
                ShowAllProductsInOrder();
                Console.WriteLine("Ange numret för produkten du vill ändra antal på:");
                int orderId = Convert.ToInt32(Console.ReadLine());

                var order = myDb.Orders.SingleOrDefault(o => o.Id == orderId);

                if (order != null)
                {
                    Console.WriteLine($"Nuvarande antal för produkten {order.Product}: {order.Quantity}");

                    Console.WriteLine("Ange nytt antal:");
                    
                    int newQuantity = Convert.ToInt32(Console.ReadLine());

                    if (newQuantity > 0)
                    {
                        order.Quantity += newQuantity;

                        var chosenProduct = myDb.Products.SingleOrDefault(p => p.Name == order.Product);
                        if (chosenProduct != null)
                        {
                            order.Total = Convert.ToDecimal(chosenProduct.Price * newQuantity);

                            myDb.SaveChanges();

                            Console.WriteLine($"Antalet för produkten {order.Product} har ändrats till {newQuantity}.");
                            Console.WriteLine($"Den nya totalen för ordern är: {order.Total}");
                            Console.WriteLine($"Total med skatt: {PriceWithTaxes()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Antalet måste vara större än 0.");
                    }
                }
                else
                {
                    Console.WriteLine("Ordern finns inte.");
                }
            }
        }


        public static void DeleteOrderProduct()
        {
            using (var myDb = new Models.MyDbContext())
            {
                ShowAllProductsInOrder();
                Console.WriteLine("Ange order-id för produkten du vill ta bort från varukorgen:");
                int orderId = Convert.ToInt32(Console.ReadLine());

                var order = myDb.Orders.SingleOrDefault(o => o.Id == orderId);

                if (order != null)
                {
                    myDb.Orders.Remove(order);
                    myDb.SaveChanges();

                    Console.WriteLine($"Produkten {order.Product} har tagits bort från varukorgen.");

                    Console.WriteLine($"Den nya totala summan med skatt är: {PriceWithTaxes()}");
                }
                else
                {
                    Console.WriteLine("Ordern finns inte.");
                }
            }
        }
    }
}




