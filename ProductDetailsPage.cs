using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopsimpler.Models;

namespace webshopsimpler
{
    internal class ProductDetailsPage
    {
        public static void ProductDetails(Product p)
        {
            int amount = 1;
            bool browsing = true;

            if (p == null || p.Id == 00)
            {
                Console.Clear();
                Console.WriteLine("Error 404: Product not found");
                Console.WriteLine("Press any key to return to the startpage");
                Console.ReadKey();
                Console.Clear();
                StartPage.Start();
                return;
            }

            ElementsHelper.WindowDavinci("ProductPage", p);

            while (browsing)
            {
                Console.SetCursorPosition(130, 18);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Amount: " + amount + " [W+][S-]");
                Console.ForegroundColor = ConsoleColor.Gray;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D4:
                        StartPage.Search("ProductPage");
                        break;
                    case ConsoleKey.D5:
                        LoginPage.Login();
                        break;
                    case ConsoleKey.D6:
                        if (Program.user == false)
                        {
                            SignUp.SignUpPage();
                        }
                        if (Program.user == true)
                        {
                            CartPage.UserCart(Program.CurrentUser);
                        }
                        break;
                    case ConsoleKey.W:
                        if (amount < p.Stock)
                        {
                            amount++;
                        }
                        break;
                    case ConsoleKey.S:
                        if (amount > 1)
                            {
                                amount--;
                            }
                        break;
                    case ConsoleKey.Enter: // Add to cart if logged in.
                        if (Program.CurrentUser == null)
                        {
                            Console.SetCursorPosition(130, 19);
                            Console.WriteLine("You need to create an account or log in for this action");
                        }
                        else
                        {
                            if (p.Stock - amount >= 0)
                            {
                                AddToCart(Program.CurrentUser, p, amount);
                                Console.SetCursorPosition(130, 19);
                                Console.WriteLine("Added " + amount + "x" + " to cart");
                            }
                            else
                            {
                                Console.SetCursorPosition(130, 19);
                                Console.WriteLine("There's not enough in stock to do that!");
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        browsing = false;
                        BrowseAllPage.BrowseAll();
                        break;
                    case ConsoleKey.Escape:
                        browsing = false;
                        StartPage.Start();
                        break;
                }
            }
        }

        public static void ProductDetails(Product p, int cat, string name)
        {
            int amount = 1;
            bool browsing = true;

            ElementsHelper.WindowDavinci("ProductPage", p);

            while (browsing)
            {
                Console.SetCursorPosition(130, 18);
                Console.Write("Amount: " + amount + " [W]+[S]-");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D4:
                        StartPage.Search("ProductPage");
                        break;
                    case ConsoleKey.D5:
                        LoginPage.Login();
                        break;
                    case ConsoleKey.D6:
                        if (Program.user == false)
                        {
                            SignUp.SignUpPage();
                        }
                        if (Program.user == true)
                        {
                            CartPage.UserCart(Program.CurrentUser);
                        }
                        break;
                    case ConsoleKey.W:
                        if (amount < p.Stock)
                        {
                            amount++;
                        }
                        break;
                    case ConsoleKey.S:
                        if (amount > 1)
                            {
                                amount--;
                            }
                        break;
                    case ConsoleKey.Enter: // add to cart if logged in.
                        if (Program.CurrentUser == null)
                        {
                            Console.SetCursorPosition(130,19);
                            Console.WriteLine("You need to create an account or log in for this action");
                        }
                        else
                        {
                            if (p.Stock - amount >= 0)
                            {
                                AddToCart(Program.CurrentUser, p, amount);
                                Console.SetCursorPosition(130, 19);
                                Console.WriteLine("Added " + amount + "x" + " to cart");
                            }
                            else
                            {
                                Console.SetCursorPosition(130, 19);
                                Console.WriteLine("There's not enough in stock to do that!");
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        browsing = false;
                        BrowseAllPage.BrowseAll(cat,name);
                        break;
                    case ConsoleKey.Escape:
                        browsing = false;
                        StartPage.Start();
                        break;
                }
            }
        }

        static void AddToCart(User u, Product p, int quantity)
        {
            using (var db = new WebshopDbContext()) 
            {
                ShoppingCart item = new ShoppingCart
                {
                    UserId = u.Id,
                    ProductId = p.Id,
                    Quantity = quantity,
                    Status = "In cart" // In cart
                };
                db.ShoppingCarts.Add(item);
                db.SaveChanges();
            }
        }
    }
}
