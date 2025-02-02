using Candymania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candymania.Data
{
    internal class AddCustomer
    {
        public static void AddC()
        {
            while (true)
            {
                using (var myDb = new Models.MyDbContext())
                {

                    myDb.Costumers.Add(new Models.Customer { Firstname = "Sven", Lastname = "Settergren", Street = "Katongatan", City = "Stockholm", Country = "Sverige", Email = "TommyOchAnnikasPappa@gmail.com", Phone = "08-402 61 01", Age = 37 });
                    myDb.Costumers.Add(new Models.Customer { Firstname = "Karlsson", Lastname = "På Taket", Street = "Takvägen 1", City = "Stockholm", Country = "Sverige", Email = "Karlsson@Taket.com", Phone = "08-555 55 555", Age = 35 });
                    myDb.Costumers.Add(new Models.Customer { Firstname = "Emil", Lastname = "Svensson", Street = "Katthult", City = "Lönneberga", Country = "Sverige", Email = "Emil@Katthult.se", Phone = "0495-200 10", Age = 9 });
                    myDb.Costumers.Add(new Models.Customer { Firstname = "Madicken", Lastname = "Engström", Street = "Junibacken", City = "Stockholm", Country = "Sverige", Email = "Madicken.Junibacken@gmail.com", Phone = "08-123 45 67", Age = 8 });
                    myDb.Costumers.Add(new Models.Customer { Firstname = "Rasmus", Lastname = "På Luffen", Street = "Okänd", City = "Växjö", Country = "Sverige", Email = "Rasmus.PaLuffen@gmail.com", Phone = "070-987 65 43", Age = 9 });
                    myDb.SaveChanges();

                    foreach (var kund in myDb.Costumers)
                    {
                        Console.WriteLine(kund.Firstname);
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void AddCustomerPay()
        {
            using (var myDb = new Models.MyDbContext())
            {

                Console.WriteLine("Ange namn: ");
                var firstname = Console.ReadLine();

                Console.WriteLine("Ange efternamn: ");
                var lastname = Console.ReadLine();

                Console.WriteLine("Ange gatuadress: ");
                var street = Console.ReadLine();

                Console.WriteLine("Ange stad: ");
                var city = Console.ReadLine();

                Console.WriteLine("Ange land: ");
                var country = Console.ReadLine();

                Console.WriteLine("Ange mejladress: ");
                var email = Console.ReadLine();

                Console.WriteLine("Ange ålder");
                var age = Console.ReadLine();

                Console.WriteLine("Ange telefonnummer");
                var phone = Console.ReadLine();



                var newCustomer = new Customer
                {
                    Firstname = firstname,
                    Lastname = lastname,
                    Street = street,
                    City = city,
                    Country = country,
                    Email = email,
                    Phone = phone,
                    Age = (int.Parse(age))
                };

                myDb.Costumers.Add(newCustomer);
                myDb.SaveChanges();

                Console.WriteLine("");
            }
        }
    }
}
