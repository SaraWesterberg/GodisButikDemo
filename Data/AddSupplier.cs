using Candymania.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candymania.Data
{
    internal class AddSupplier
    {
        public static void AddSuppliers()
        {
            while (true)
            {
                using (var myDb = new Models.MyDbContext())
                {
                    var supplier1 = new Supplier { Name = "Godis AB", Address = "Godisvägen 1", Phone = "070-1234567", Email = "Godiskungen@CandyKing.se" };
                    var supplier2 = new Supplier { Name = "Snacks & Co", Address = "Snacksgränd 42", Phone = "070-7654321", Email = "Snacksa@ChipsOchDip.se" };
                    var supplier3 = new Supplier { Name = "SockerdrickaTrädet AB", Address = "VilleVillaKulla 2", Phone = "073-4865745", Email = "Sockerdricka@softdrink.com" };
                    var supplier4 = new Supplier { Name = "Godisgurun AB", Address = "Sockergatan 99", Phone = "073-GLAZYR", Email = "info@godisgurun.se" };
                    var supplier5 = new Supplier { Name = "Chokladhjältarna", Address = "Kakaogränden 12", Phone = "08-CHOCO4U", Email = "kontakt@chokladhjaltarna.se" };

                    myDb.Suppliers.Add(supplier1);
                    myDb.Suppliers.Add(supplier2);
                    myDb.Suppliers.Add(supplier3);
                    myDb.Suppliers.Add(supplier4);
                    myDb.Suppliers.Add(supplier5);

                    myDb.SaveChanges();
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
