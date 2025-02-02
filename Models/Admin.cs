using Candymania.Data;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowDemo;

namespace Candymania.Models
{
    internal class Admin
    {
        public int Id { get; set; }
        public Product product { get; set; }
        public Category category { get; set; }


        public static void AdminMenu()
        {
            while (true)
            {
                Console.Clear();
                List<string> AdminText = new List<string> { "Vad vill Admin göra?", "[1] Administrera produkter", "[2] Administrera kategorier", "[3] Administrera kunder", "[4] Se statetik", "[X] Tillbaka till LogIn" };
                var windowCart = new Window("Admin", 2, 2, AdminText);
                windowCart.Draw();

                var key = Console.ReadKey(true);
                switch (key.KeyChar)
                {
                    case '1':
                        AdminProdMenu();
                        break;
                    case '2':
                        AdminCategoryMenu();
                        break;
                    case '3':
                        AdminCustomerMenu();
                        break;
                    case '4':
                        QueryHelper.Querys();
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
        public static void AdminProdMenu()
        {
            Console.Clear();
            List<string> AdminText = new List<string> { "Vad vill du göra med produkter", "[1] Addera produkter", "[2] Radera produkter", "[3] Ändra produkt", "[X] Tillbaka till AdminMenu" };
            var windowCart = new Window("Admin", 2, 2, AdminText);
            windowCart.Draw();

            var key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                case '1':
                    AdminAddProd();
                    break;
                case '2':
                    DeleteProduct();
                    break;
                case '3':
                    UpdateProduct();
                    break;
                case 'x':
                    Admin.AdminMenu();
                    break;
                default:
                    Console.WriteLine("Wrong Input");
                    Console.ReadKey();
                    break;
            }
        }
        public static void AdminCategoryMenu()
        {
            Console.Clear();
            List<string> Admintext = new List<string> { "Vad vill du göra med kategorierna?", "[1] Addera en kategori", "[2] Ändra namn på kategori", "[X] Tillbaka till AdminMenu" };
            var windowcart = new Window("Admin", 2, 2, Admintext);
            windowcart.Draw();
            var key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                case '1':
                    AdminAddCat();
                    break;
                case '2':
                    UpdateCategory();
                    break;
                default:
                    Console.WriteLine("Wrong Input)");
                    Console.ReadKey();
                    break;
            }
        }
        public static void ShowCategoriesList()
        {
            using (var myDb = new Models.MyDbContext())
            {
                Console.Clear();
                Console.WriteLine("Lista kategorierna");
                foreach (var category in myDb.Categories)
                {
                    Console.WriteLine($"ID: {category.Id}, Name: {category.Categoryname}");
                }
                Console.ReadKey();
            }
        }
        public static void AdminAddCat()
        {
            try {
                using (var myDb = new Models.MyDbContext())
                {
                    ShowCategoriesList();
                    Console.WriteLine();

                    Console.WriteLine("För att lägga till kategori på listan, mata in följande: " + "\n" + "Kategorinamn: ");
                    var namn = Console.ReadLine();

                    var newCategory = new Category
                    {
                        Categoryname = namn,
                    };


                    myDb.Categories.Add(newCategory);
                    myDb.SaveChanges();

                    Console.WriteLine("En ny Kategori har lagts till!");
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Ett fel uppstod: {ex.Message}");
            }
        }
        public static void UpdateCategory()
        {
            using (var myDb = new Models.MyDbContext())
            {
                Console.Clear();
                ShowCategoriesList();

                Console.Write("\nAnge ID för kategorin du vill uppdatera: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var categoryToUpdate = myDb.Categories.FirstOrDefault(k => k.Id == id);

                    if (categoryToUpdate != null)
                    {

                        Console.WriteLine($"Nuvarande nam på kategorin: {categoryToUpdate.Categoryname}");
                        Console.Write("Ange nytt Kategorinamn (eller tryck Enter för att behålla det nuvarande): ");
                        string newCategoryName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newCategoryName))
                        {
                            categoryToUpdate.Categoryname = newCategoryName;
                        }



                        myDb.SaveChanges();
                        Console.WriteLine($"Kategorin '{categoryToUpdate.Categoryname}' har uppdaterats.");
                    }
                    else
                    {
                        Console.WriteLine("Ingen kategori hittades med det Id:t.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt Id. Försök igen.");
                }

                Console.WriteLine("\nTryck på valfri tangent för att återvända.");
                Console.ReadKey();
            }
        }
        public static void AdminAddProd()
        {
            using (var myDb = new Models.MyDbContext())
            {
                AddProduct.ShowProdList();
                Console.WriteLine();

                Console.WriteLine("För att lägga till produkt på listan, mata in följande: " + "\n" + "Produktnamn: ");
                var namn = Console.ReadLine();

                Console.WriteLine("Price: ");
                var pris = Console.ReadLine();

                Console.WriteLine("Lagersaldo: ");
                var lagersaldo = Console.ReadLine();

                Console.WriteLine("Description");
                var beskrivning = Console.ReadLine();

                
                bool presenteras = false;
                while (true)
                {
                    Console.WriteLine("Present (ja/nej):");
                    var input = Console.ReadLine().ToLower(); 

                    if (input == "ja")
                    {
                        presenteras = true;
                        break;
                    }
                    else if (input == "nej")
                    {
                        presenteras = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Felaktig inmatning. Vänligen skriv 'ja' eller 'nej'.");
                    }
                }

                Console.WriteLine("SupplierId");
                var supplierId = Console.ReadLine();

                var newProdukt = new Product
                {
                    Name = namn,
                    Price = int.Parse(pris),
                    Stock = int.Parse(lagersaldo),
                    Description = beskrivning,
                    Present = presenteras, 
                    SupplierId = int.Parse(supplierId)
                };

                
                myDb.Products.Add(newProdukt);
                myDb.SaveChanges();

                Console.WriteLine("Produkt har lagts till!");
            }
        }
        public static void DeleteProduct()
            {
            using (var myDb = new Models.MyDbContext())
            {

                Console.Clear();
                Console.WriteLine("Ta bort en produkt:");
                AddProduct.ShowProdList();

                Console.Write("\nAnge ID för produkten du vill ta bort: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var produktToDelete = myDb.Products.FirstOrDefault(p => p.Id == id); 

                    if (produktToDelete != null)
                    {
                        myDb.Products.Remove(produktToDelete); 
                        myDb.SaveChanges(); 

                        Console.WriteLine($"Produkten '{produktToDelete.Name}' har tagits bort.");
                    }
                    else
                    {
                        Console.WriteLine("Ingen produkt hittades med det ID:t.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt ID. Försök igen.");
                }

                Console.WriteLine("\nTryck på valfri tangent för att återvända.");
                Console.ReadKey();
            }
        }
        public static void UpdateProduct()
        {
            using (var myDb = new Models.MyDbContext())
            {
                Console.Clear();
                AddProduct.ShowProdList();
                Console.WriteLine("Ändra en produkt:");

                Console.Write("\nAnge ID för produkten du vill ändra: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var produktToUpdate = myDb.Products.FirstOrDefault(p => p.Id == id); 

                    if (produktToUpdate != null)
                    {
                        
                        Console.WriteLine($"Nuvarande namn: {produktToUpdate.Name}");
                        Console.Write("Ange nytt namn (eller tryck Enter för att behålla det nuvarande): ");
                        string newName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newName))
                        {
                            produktToUpdate.Name = newName; 
                        }

                        Console.WriteLine($"Nuvarande pris: {produktToUpdate.Price} kr");
                        Console.Write("Ange nytt pris (eller tryck Enter för att behålla det nuvarande): ");
                        string newPriceInput = Console.ReadLine();
                        if (int.TryParse(newPriceInput, out int newPrice))
                        {
                            produktToUpdate.Price = newPrice; 
                        }

                        Console.WriteLine($"Nuvarande lagersaldo: {produktToUpdate.Stock}");
                        Console.Write("Ange nytt lagersaldo (eller tryck Enter för att behålla det nuvarande): ");
                        string newStockInput = Console.ReadLine();
                        if (int.TryParse(newStockInput, out int newStock))
                        {
                            produktToUpdate.Stock = newStock; 
                        }

                        Console.WriteLine($"Nuvarande beskrivning: {produktToUpdate.Description}");
                        Console.Write("Ange ny beskrivning (eller tryck Enter för att behålla den nuvarande): ");
                        string newDescription = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newDescription))
                        {
                            produktToUpdate.Description = newDescription; 
                        }

                        myDb.SaveChanges(); 
                        Console.WriteLine($"Produkten '{produktToUpdate.Name}' har uppdaterats.");
                    }
                    else
                    {
                        Console.WriteLine("Ingen produkt hittades med det ID:t.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt ID. Försök igen.");
                }

                Console.WriteLine("\nTryck på valfri tangent för att återvända.");
                Console.ReadKey();
            }
        }

        public static void AdminCustomerMenu()
        {
            Console.Clear();
            List<string> AdminText = new List<string> { "Vad vill du göra med kunder?", "[1] Visa kunder", "[2] Uppdatera kund", "[3] Se kunds orderhistorik", "[X] Tillbaka till AdminMenu" };
            var windowCart = new Window("Admin - Kunder", 2, 2, AdminText);
            windowCart.Draw();

            var key = Console.ReadKey(true);
            switch (key.KeyChar)
            {
                case '1':
                    ShowAllCustomers();
                    break;
                case '2':
                    UpdateCustomer();
                    break;
                case '3':
                    ShowCustomerOrderHistory();
                    break;
                case 'x':
                    Admin.AdminMenu();
                    break;
                default:
                    Console.WriteLine("Felaktigt val, försök igen.");
                    Console.ReadKey();
                    break;
            }
        }

        public static void ShowAllCustomers()
        {
            using (var myDb = new Models.MyDbContext())
            {
                Console.Clear();
                Console.WriteLine("Lista på alla kunder:");
                foreach (var customer in myDb.Costumers)
                {
                    Console.WriteLine($"ID: {customer.Id}, Name: {customer.Firstname} {customer.Lastname}, Email: {customer.Email}, Phone: {customer.Phone}");
                }
                Console.WriteLine("\nTryck på valfri tangent för att återgå.");
                Console.ReadKey();
            }
        }

        public static void UpdateCustomer()
        {
            using (var myDb = new Models.MyDbContext())
            {
                Console.Clear();
                ShowAllCustomers();

                Console.Write("\nAnge ID för kunden du vill uppdatera: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var customerToUpdate = myDb.Costumers.FirstOrDefault(k => k.Id == id);

                    if (customerToUpdate != null)
                    {
                        
                        Console.WriteLine($"Nuvarande förnamn: {customerToUpdate.Firstname}");
                        Console.Write("Ange nytt förnamn (eller tryck Enter för att behålla det nuvarande): ");
                        string newFirstName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newFirstName))
                        {
                            customerToUpdate.Firstname = newFirstName;
                        }

                        Console.WriteLine($"Nuvarande efternamn: {customerToUpdate.Lastname}");
                        Console.Write("Ange nytt efternamn (eller tryck Enter för att behålla det nuvarande): ");
                        string newLastName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newLastName))
                        {
                            customerToUpdate.Lastname = newLastName;
                        }

                        Console.WriteLine($"Nuvarande mejl: {customerToUpdate.Email}");
                        Console.Write("Ange ny mejl (eller tryck Enter för att behålla det nuvarande): ");
                        string newEmail = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newEmail))
                        {
                            customerToUpdate.Email = newEmail;
                        }

                        Console.WriteLine($"Nuvarande telefonnummer: {customerToUpdate.Phone}");
                        Console.Write("Ange nytt telefonnummer (eller tryck Enter för att behålla det nuvarande): ");
                        string newPhone = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newPhone))
                        {
                            customerToUpdate.Phone = newPhone;
                        }

                        Console.WriteLine($"Nuvarande adress: {customerToUpdate.Street}, {customerToUpdate.City}, {customerToUpdate.Country}");
                        Console.Write("Ange ny adress (eller tryck Enter för att behålla den nuvarande): ");
                        string newAddress = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newAddress))
                        {
                            customerToUpdate.Street = newAddress;
                        }

                        Console.Write("Ange ny stad (eller tryck Enter för att behålla den nuvarande): ");
                        string newCity = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newCity))
                        {
                            customerToUpdate.City = newCity;
                        }

                        Console.Write("Ange nytt land (eller tryck Enter för att behålla det nuvarande): ");
                        string newCountry = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newCountry))
                        {
                            customerToUpdate.Country = newCountry;
                        }

                        Console.WriteLine($"Nuvarande ålder: {customerToUpdate.Age}");
                        Console.Write("Ange ny ålder (eller tryck Enter för att behålla den nuvarande): ");
                        string newAgeInput = Console.ReadLine();
                        if (int.TryParse(newAgeInput, out int newAge))
                        {
                            customerToUpdate.Age = newAge;
                        }

                        myDb.SaveChanges();
                        Console.WriteLine($"Kunden '{customerToUpdate.Firstname} {customerToUpdate.Lastname}' har uppdaterats.");
                    }
                    else
                    {
                        Console.WriteLine("Ingen kund hittades med det ID:t.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt ID. Försök igen.");
                }

                Console.WriteLine("\nTryck på valfri tangent för att återvända.");
                Console.ReadKey();
            }
        }
        public static void ShowCustomerOrderHistory()
        {
            using (var myDb = new Models.MyDbContext())
            {
                Console.Clear();
                Console.WriteLine("Kunds orderhistorik:");
                ShowAllCustomers();

                Console.Write("\nAnge ID för kunden vars orderhistorik du vill se: ");
                if (int.TryParse(Console.ReadLine(), out int id))
                {
                    var customer = myDb.Costumers.FirstOrDefault(k => k.Id == id);

                    if (customer != null)
                    {
                        var orders = myDb.Orders.Where(o => o.CustomerId == id).ToList();

                        if (orders.Any())
                        {
                            Console.WriteLine($"\nOrderhistorik för {customer.Firstname} {customer.Lastname}:");
                            foreach (var order in orders)
                            {
                                Console.WriteLine($"OrderID: {order.Id}, Datum: {order.Date}, Total: {order.Total} kr");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Ingen orderhistorik hittades för kunden {customer.Firstname} {customer.Lastname}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ingen kund hittades med det ID:t.");
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt ID. Försök igen.");
                }

                Console.WriteLine("\nTryck på valfri tangent för att återvända.");
                Console.ReadKey();
            }
        }
    }
}



       
