using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopsimpler.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Xml;
using Azure.Identity;

namespace webshopsimpler
{
    internal class Admin
    {
        public static void AdminStart() 
        {
            ElementsHelper.WindowDavinci("AdminStart");

            here:
            switch (Console.ReadKey().Key) 
            {
                case ConsoleKey.D1:
                    ProductManager();
                    break;
                case ConsoleKey.D2:
                    CustomerManager();
                    break;
                case ConsoleKey.D3:
                    SellStats();
                    break;
                case ConsoleKey.Escape:
                    return;
                default:
                    goto here;
            }
        }

        static async void CustomerManager() 
        {
            var db = new WebshopDbContext();
            Task<List<User>> task = UserFetcher(db);
            Console.Clear();
            ElementsHelper.WindowDavinci("AdminViewC");
            List<User> users = await task;
            Printer(users, 10);

        here:
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    User u = UserSelector(users);
                    if (u != null)
                    {
                        u = UserEditor(u);
                        UserUpdater(u, db);
                    }
                    break;
                case ConsoleKey.Escape:
                    return;
                case ConsoleKey.E:
                    User uhistory = UserSelector(users);
                    if (uhistory != null) 
                    {
                        UserOrderHistory(uhistory);
                    }
                    break;
                default:
                    goto here;
            }
        }

        static async void ProductManager()
        {
            var db = new WebshopDbContext();

            Task<List<Product>> task = ProductFetcher(db);
            ElementsHelper.WindowDavinci("AdminView");

            List<Product> products = await task;
            Task<List<ProductCategory>> task2 = CatFetcher(db);
            Printer(products, 10);

        here:
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                    Product p = ProductSelector(products);
                    if (p != null)
                    {
                        p = ProductEditor(p);
                        ProductUpdater(p, db);
                    }
                    break;
                case ConsoleKey.Escape:
                    return;
                case ConsoleKey.E:
                    List<ProductCategory> cats = await task2;
                    Product pNew = ProductMaker(cats);
                    ProductSaver(pNew, db);
                    break;
                default:
                    goto here;
            }
        }

        static void SellStats() 
        {
            ElementsHelper.WindowDavinci("AdminViewS");
            Console.SetCursorPosition(32, 14);
            Console.WriteLine("Product stats!");

            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Webshop;Trusted_connection=True;TrustServerCertificate=True;"))
            {
                string query = @"  SELECT 
                                        [Products].Name,
                                        [Products].Size,
                                        SUM(Quantity) AS TotalSold,
                                        SUM(Quantity * [Products].Price) AS Total,
                                        [Status]
                                    FROM ShoppingCarts
                                    INNER JOIN Products ON ShoppingCarts.ProductId = Products.Id
                                    where [Status] = 'Done'
                                    GROUP BY 
                                        [Products].Name, [Products].Size, 
                                        [Products].Dimensions,  
                                        [Products].Price, IsPaid, Status;";

                var result = connection.Query(query)
                                                .Select(row => new
                                                {
                                                    row.Name,
                                                    row.Size,
                                                    row.TotalSold,
                                                    row.Total,
                                                    row.Status
                                                })
                                                .ToList();
                int i = 0;
                while (true)
                {
                    int row = 10;
                    foreach (var o in result)
                    {
                        if (o == result[i])
                        {
                            Console.SetCursorPosition(32, row++);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"Product: {o.Name},  Size: {o.Size},  Total Sold: {o.TotalSold},  Earnings: {o.Total} ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            continue;
                        }
                        Console.SetCursorPosition(32, row++);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"Product: {o.Name},  Size: {o.Size},  Total Sold: {o.TotalSold},  Earnings: {o.Total} ");
                    }

                    Console.SetCursorPosition(0,0);
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.W:
                            if (i > 0)
                            {
                                i--;
                            }
                            break;
                        case ConsoleKey.S:
                            if (i < result.Count - 1)
                            {
                                i++;
                            }
                            break;

                        case ConsoleKey.Escape:
                            return;
                    }
                }
            }

        }

        static User UserSelector(List<User> Users)
        {
            Console.Clear();
            ElementsHelper.WindowDavinci("AdminViewC");
            int row;
            int i = 0;

            while (true)
            {
                row = 10;
                Console.SetCursorPosition(31, 9);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("[W]UP[S]DOWN [ENTER]Select [ESC]Cancel");

                foreach (var u in Users)
                {
                    if (u == Users[i])
                    {
                        Console.SetCursorPosition(32, row++);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"Username: {u.Username,-5} Email: {u.Email,-5} Name: {u.FirstLastName,-5} Phone: {u.PhoneNumber}");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        continue;
                    }
                    row = Printer(u, row);
                }
                Console.SetCursorPosition(0, 0);

            here:
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.W:
                        if (i > 0)
                        {
                            i--;
                        }
                        break;
                    case ConsoleKey.S:
                        if (i < Users.Count - 1)
                        {
                            i++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        var post = Users[i];
                        return post;

                    case ConsoleKey.Escape:
                        return null;

                    default:
                        goto here;
                }
            }
        } //longstringprintcheck

        static User UserEditor(User u)
        {
            int i = 0;
            Console.Clear();
            ElementsHelper.WindowDavinci("AdminView");
            Printer(u, 10);

            List<string> options =
            [
                "Username",
                "Password",
                "Email",
                "Name",
                "Address",
                "PostalCode",
                "City",
                "Country",
                "PhoneNumber",
                "Admin privs",
            ];

            Console.SetCursorPosition(141, 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[W][S][Enter]");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            while (true)
            {
                int row = 12;
                foreach (var s in options)
                {
                    if (s == options[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(141, row++);
                        Console.Write(s);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        continue;
                    }
                    Console.SetCursorPosition(141, row++);
                    Console.Write(s);
                }

                Console.CursorVisible = false;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Escape:
                        return null;
                    case ConsoleKey.W:
                        if (i > 0)
                        {
                            i--;
                        }
                        break;
                    case ConsoleKey.S:
                        if (i < options.Count - 1)
                        {
                            i++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        u = UserMaker(u, i);
                        return u;
                }
            }
        }

        static User UserMaker(User u, int i)
        {
            if (i == 0)
            {
                u.Username = SignUp.GetString("Enter new username");
                return u;
            }
            if (i == 1)
            {
                u.Password = SignUp.GetString("Enter new password");
                return u;
            }
            if (i == 2)
            {
                u.Email = SignUp.GetString("Enter new email");
                return u;
            }
            if (i == 3)
            {
                u.FirstLastName = SignUp.GetString("Enter new first and last name");
                return u;
            }
            if (i == 4)
            {
                u.Address = SignUp.GetString("Enter new adress");
                return u;
            }
            if (i == 5)
            {
                u.PostalCode = SignUp.GetString("Enter new postal code");
                return u;
            }
            if (i == 6)
            {
                u.City = SignUp.GetString("Enter new city");
                return u;
            }
            if (i == 7)
            {
                using (var db = new WebshopDbContext())
                {
                    var countries = db.Countries.ToList();
                    u.CountryId = SignUp.GetCountryId(countries);
                    return u;
                }
            }
            if (i == 8)
            {
                u.PhoneNumber = SignUp.GetString("Enter new phonenumber");
                return u;
            }
            if (i == 9)
            {
                u.IsAdmin = !u.IsAdmin;
                return u;
            }
            if (i == 10)
            {
                using (var db = new WebshopDbContext())
                {
                    db.Users.Remove(u);
                    db.SaveChanges();
                    Console.SetCursorPosition(90, 15);
                    Console.WriteLine("Account was deleted");
                    Console.SetCursorPosition(90, 16);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        static void UserOrderHistory(User u) 
        {
            using (var connection = new SqlConnection(@"Server=.\SQLEXPRESS;Database=Webshop;Trusted_connection=True;TrustServerCertificate=True;")) 
            {
                string query = @"  SELECT 
                                    UserId,
	                                [Users].Username,
                                    [Products].Name,
                                    [Products].Size,
                                    [Products].Dimensions,
                                    SUM(Quantity) AS TotalBought,
                                    [Products].Price,
                                    SUM(Quantity * [Products].Price) AS Total,
                                    Status
                                 FROM ShoppingCarts
                                 INNER JOIN Products ON ShoppingCarts.ProductId = Products.Id
                                 INNER JOIN Users ON ShoppingCarts.UserId = Users.Id
                                 WHERE [UserId] = @UserId
                                 GROUP BY 
                                    UserId, [Users].Username, [Products].Name, [Products].Size, 
                                    [Products].Dimensions,  
                                    [Products].Price, IsPaid, Status;";
                
                var result = connection.Query(query, new { UserId = u.Id })
                                                .Select(row => new 
                                                {
                                                    row.Userid,
                                                    row.Username,
                                                    Pname = row.Name,
                                                    row.Size,
                                                    row.Dimensions,
                                                    row.TotalBought,
                                                    row.Price,
                                                    row.Total,
                                                    row.Status
                                                })
                                                .ToList();
                int i = 0;
                while (true)
                {
                    int row = 10;
                    foreach (var o in result)
                    {
                        if (o == result[i])
                        {
                            Console.SetCursorPosition(32, row++);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"Username: {o.Username},  Product: {o.Pname},  Size: {o.Size},  Total Bought: {o.TotalBought},  Total price: {o.Total},  Status: {o.Status}");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            continue;
                        }
                        Console.SetCursorPosition(32, row++);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"Username: {o.Username},  Product: {o.Pname},  Size: {o.Size},  Total Bought: {o.TotalBought},  Total price: {o.Total},  Status: {o.Status}");
                    }

                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.W:
                            if (i > 0)
                            {
                                i--;
                            }
                            break;
                        case ConsoleKey.S:
                            if (i < result.Count - 1)
                            {
                                i++;
                            }
                            break;

                        case ConsoleKey.Escape:
                            return;
                    }
                }
            }
        }

        static void UserUpdater(User u, WebshopDbContext db)
        {
            if (u != null)
            {
                db.Users.Update(u);
                db.SaveChanges();
                Console.SetCursorPosition(90, 17);
                Console.WriteLine("account has been updated. Press any key to continue");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.SetCursorPosition(90, 17);
                Console.WriteLine("Something went wrong... changes not saved.");
                Console.SetCursorPosition(90, 18);
                Console.WriteLine("Or you successfully deleted the account.");
                Console.SetCursorPosition(90, 19);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }
        }

        static Product ProductSelector(List<Product> products) 
        {
            Console.Clear();
            ElementsHelper.WindowDavinci("AdminView");
            int row;
            int i = 0;

             while (true)
             {
                 row = 10;
                 Console.SetCursorPosition(31, 9);
                 Console.ForegroundColor = ConsoleColor.White;
                 Console.WriteLine("[W]UP[S]DOWN [ENTER]Select [ESC]Cancel");

                    foreach (var p in products)
                    {
                        if (p == products[i])
                        {
                            Console.SetCursorPosition(32, row++);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{p.Name,-20} Size: {p.Size,-5} Stock: {p.Stock,-5} Price: {p.Price,-5} Startpage: {p.SelectProduct}");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            continue;
                        }
                        row = Printer(p, row);
                    }
                    Console.SetCursorPosition(0, 0);
                    Console.CursorVisible = false;

                    here:
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.W:
                            if (i > 0)
                            {
                                i--;
                            }
                            break;
                        case ConsoleKey.S:
                            if (i < products.Count - 1)
                            {
                                i++;
                            }
                            break;

                        case ConsoleKey.Enter:
                            var post = products[i];
                            return post;

                        case ConsoleKey.Escape:
                            return null;

                        default:
                            goto here;
                    }
             } 
        }

        static Product ProductEditor(Product p) 
        {
            int i = 0;
            Console.Clear();
            ElementsHelper.WindowDavinci("AdminView");
            Printer(p , 10);
            
            List<string> options =
            [
                "Name",
                "Size",
                "Stock",
                "Price",
                "Startpage",
                "DELETE",
            ];

            Console.SetCursorPosition (141, 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("[W][S][Enter]");
            Console.ForegroundColor = ConsoleColor.DarkGray;

            while (true)
            {
                int row = 12;
                foreach (var s in options)
                {
                    if (s == options[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(141, row++);
                        Console.Write(s);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        continue;
                    }
                    Console.SetCursorPosition(141, row++);
                    Console.Write(s);
                }

                Console.CursorVisible = false;
                switch (Console.ReadKey().Key) 
                {
                    case ConsoleKey.Escape:
                        return null;
                    case ConsoleKey.W:
                        if (i > 0)
                        {
                            i--;
                        }
                        break;
                    case ConsoleKey.S:
                        if (i < options.Count - 1)
                        {
                            i++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        p = ProductMaker(p, i);
                        return p;
                }
            }
        } // lets admin choose a property to edit then also edit.

        static Product ProductMaker(List<ProductCategory> cats) 
        {
            Product p = new Product()
            {
                Name = SignUp.GetString("Enter product name"),
                Description = SignUp.GetString("Enter a description"),
                Size = SignUp.GetString("Enter size, XXL, XL , etc"),
                Dimensions = SignUp.GetString("Enter Dimensions, 500x450x3 etc"),
                Stock = IntGetter("Enter current stock"),
                Price = DecimalGetter("Enter Price"),
                SelectProduct = false,
                ProductCategoryId = IdGetter(cats),
            };
            Printer(p, 15);
            Console.SetCursorPosition (35, 14);
            Console.WriteLine("Confirm product creation y/n");
            Console.CursorVisible=false;
            
            here:
            switch (Console.ReadKey().Key) 
            { 
                case ConsoleKey.Y:
                    return p;
                case ConsoleKey.N: 
                    return null;
                default: 
                    goto here;
            }
        } // mby use enums for size and dimensions // lets admin make new product

        static Product ProductMaker(Product p, int i) 
        {
            if (i == 0) 
            {
                p.Name = SignUp.GetString("Enter new name");
                return p;
            }
            if (i == 1) 
            {
                p.Size = SignUp.GetString("Enter new size");
                return p;
            }
            if (i == 2) 
            {
                p.Stock = IntGetter("Enter new stock");
                return p;
            }
            if (i == 3) 
            {
                p.Price = DecimalGetter("Enter new price");
                return p;
            }
            if (i == 4)
            {
                using (var db = new WebshopDbContext())
                {
                    var selectproducts = db.Products.Where(x => x.SelectProduct == true).Count();
                    if (selectproducts < 3 && p.SelectProduct == false || p.SelectProduct == true)
                    {
                        p.SelectProduct = !p.SelectProduct;
                        return p;
                    }
                    else
                    {
                        Console.Clear();
                        Console.SetCursorPosition(90, 15);
                        Console.WriteLine("You can only have 3 select products");
                        Console.SetCursorPosition(90,16);
                        Console.WriteLine("Press any key to return");
                        Console.ReadKey();
                        return null;
                    }
                }
            }
            if (i == 5) 
            {
                using (var db = new WebshopDbContext()) 
                {
                    db.Products.Remove(p);
                    db.SaveChanges();
                    Console.SetCursorPosition(90, 15);
                    Console.WriteLine("Product was deleted");
                    Console.SetCursorPosition(90, 16);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    return null;
                }
            }
            else
            {
                return null;
            }
            
        } // lets admin edit 1 product property

        static void ProductUpdater(Product p, WebshopDbContext db) 
        {
            if (p != null)
            {
                db.Products.Update(p);
                db.SaveChanges();
                Console.SetCursorPosition(90, 17);
                Console.WriteLine("Product has been updated. Press any key to continue");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.SetCursorPosition(90, 17);
                Console.WriteLine("Something went wrong... Product not saved.");
                Console.SetCursorPosition(90, 18);
                Console.WriteLine("Or you successfully deleted the product.");
                Console.SetCursorPosition(90, 19);
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }
        }

        static void ProductSaver(Product p, WebshopDbContext db) 
        {
            if (p != null)
            {
                db.Products.Add(p);
                db.SaveChanges();
                Console.SetCursorPosition(35, 16);
                Console.WriteLine("Product has been added. Press any key to continue");
                Console.ReadKey();
                return;
            }
            else 
            {
                Console.WriteLine("Something went wrong... Product not saved.");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }

        }

        static async Task<List<Product>> ProductFetcher(WebshopDbContext db) 
        {
            var products = await db.Products.ToListAsync();
            return products;
        }

        static async Task<List<User>> UserFetcher(WebshopDbContext db)
        {
            var Users = await db.Users.Where(u => u.Username != "Admin").ToListAsync();
            return Users;
        }

        static async Task<List<ProductCategory>> CatFetcher(WebshopDbContext db)
        {
            var cats = await db.ProductCategories.ToListAsync();
            return cats;
        }

        static void Printer(List<Product> products, int row) 
        {
            foreach (var p in products)
            {
                Console.SetCursorPosition(32, row++);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"{p.Name,-20} Size: {p.Size,-5} Stock: {p.Stock,-5} Price: {p.Price,-5} Startpage: {p.SelectProduct}");
            }
        }

        static void Printer(List<User> Users, int row)
        {
            foreach (var u in Users)
            {
                Console.SetCursorPosition(32, row++);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"Username: {u.Username,-5} Email: {u.Email,-5} Name: {u.FirstLastName,-5} Phone: {u.PhoneNumber}");
            }
        }

        static int Printer(User u, int row)
        {
            Console.SetCursorPosition(32, row++);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"Username: {u.Username,-5} Email: {u.Email,-5} Name: {u.FirstLastName,-5} Phone: {u.PhoneNumber}");
            return row;
        }

        static int Printer(Product p, int row)
        {
            Console.SetCursorPosition(32, row++);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write($"{p.Name,-20} Size: {p.Size,-5} Stock: {p.Stock,-5} Price: {p.Price,-5} Startpage: {p.SelectProduct}");
            return row;
        }

        static decimal DecimalGetter(string s)
        {
            while (true)
            {
                error:
                Console.Clear();
                Console.SetCursorPosition(90, 28);
                Console.Write(s);
                Console.SetCursorPosition(90, 30);
                string input = Console.ReadLine();
                decimal d;

                if (!string.IsNullOrWhiteSpace(input))
                {
                    try 
                    {
                        d = Convert.ToDecimal(input);
                    }
                    catch 
                    {
                        Console.SetCursorPosition(75, 33);
                        Console.WriteLine("Invalid input, Field cannot be blank or empty.");
                        Thread.Sleep(1000);
                        goto error;
                    }
                Here:
                    Console.SetCursorPosition(70, 33);
                    Console.WriteLine("Press [ENTER] to confirm         Press [BACKSPACE] to Write something else");
                    ConsoleKey key = Console.ReadKey().Key;

                    if (key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        return d;
                    }

                    if (key == ConsoleKey.Backspace)
                    {
                        continue;
                    }

                    else
                    {
                        goto Here;
                    }
                }
                else
                {
                    Console.SetCursorPosition(75, 33);
                    Console.WriteLine("Invalid input, Field cannot be blank or empty.");
                    Thread.Sleep(1000);
                }
            }
        }

        static int IntGetter(string s) 
        {
            while (true)
            {
            error:
                Console.Clear();
                Console.SetCursorPosition(90, 28);
                Console.Write(s);
                Console.SetCursorPosition(90, 30);
                string input = Console.ReadLine();
                int i;

                if (!string.IsNullOrWhiteSpace(input))
                {
                    try
                    {
                        i = int.Parse(input);
                    }
                    catch
                    {
                        Console.SetCursorPosition(75, 33);
                        Console.WriteLine("Invalid input, Field cannot be blank or empty.");
                        Thread.Sleep(1000);
                        goto error;
                    }
                Here:
                    Console.SetCursorPosition(70, 33);
                    Console.WriteLine("Press [ENTER] to confirm         Press [BACKSPACE] to Write something else");
                    ConsoleKey key = Console.ReadKey().Key;

                    if (key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        return i;
                    }

                    if (key == ConsoleKey.Backspace)
                    {
                        continue;
                    }

                    else
                    {
                        goto Here;
                    }
                }
                else
                {
                    Console.SetCursorPosition(75, 33);
                    Console.WriteLine("Invalid input, Field cannot be blank or empty.");
                    Thread.Sleep(1000);
                }
            }
        }

        static int IdGetter(List<ProductCategory> cats)
        {
            Console.Clear();
            int i = 0;
            Console.SetCursorPosition(90, 28);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Select category [W] up [S] down [Enter] Select");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.SetCursorPosition(90, 30);
                foreach (var c in cats)
                {
                    if (c == cats[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(c.CategoryName);
                        Console.SetCursorPosition(90, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    Console.WriteLine(c.CategoryName);
                    Console.SetCursorPosition(90, Console.CursorTop);
                }

                Console.SetCursorPosition(0 , 0);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.S:
                        {
                            if (i < cats.Count - 1)
                            {
                                i++;
                            }
                        }
                        break;
                   
                    case ConsoleKey.W:
                        {
                            if (i >= 1)
                                i--;
                        }
                        break;
                    
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.SetCursorPosition(90, 28);
                        Console.WriteLine("You selected: " + cats[i].CategoryName);
                        Console.SetCursorPosition(70, 30);
                        Console.WriteLine("Press [ENTER] to confirm         Press [BACKSPACE] to select another category");
                        ConsoleKey key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Enter) 
                        {
                            Console.Clear();
                            return cats[i].Id;
                        }
                        if (key != ConsoleKey.Backspace)
                        {
                            goto case ConsoleKey.Enter;
                        }
                        Console.Clear();
                        break;
                }
            }
        
        }

    }
}
