using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopsimpler.Models;
using static System.Formats.Asn1.AsnWriter;

namespace webshopsimpler
{
    internal class BrowseAllPage
    {
        public static void BrowseAll()
        {
            ElementsHelper.WindowDavinci("BrowseAll");
            List<Product> productList = ElementsHelper.GetProducts();
            int lookingAt = 0;
            bool browsing = true;

            Console.SetCursorPosition(80, 20);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Browsing all products");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(135, 20);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("[W] UP [S] Down [Enter] See Details [BackSpace] Back");
            Console.ForegroundColor = ConsoleColor.White;

            while (browsing)
            {
                Console.SetCursorPosition(50, 21);
                foreach (var p in productList)
                {
                    if (p == productList[lookingAt])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Name: [{p.Name}] \t Size: {p.Size} \t Stock: {p.Stock} \t Price: {p.Price} \t [See Details]");
                        Console.SetCursorPosition(50, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    Console.WriteLine($"Name: [{p.Name}] \t Size: {p.Size} \t Stock: {p.Stock} \t Price: {p.Price} \t [See details]");
                    Console.SetCursorPosition(50, Console.CursorTop);
                }

                Console.SetCursorPosition(0, 0);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.S:
                        {
                            if (lookingAt < productList.Count -1)
                            {
                                lookingAt++;
                            }
                        }
                        break;
                    case ConsoleKey.W:
                        {
                            if (lookingAt >= 1)
                                lookingAt--;
                        }
                        break;
                    case ConsoleKey.Escape:
                        {
                            browsing = false;
                            StartPage.Start();
                        }
                        break;
                    case ConsoleKey.Enter:
                        browsing = false;
                        ProductDetailsPage.ProductDetails(productList[lookingAt]);
                        break;
                    case ConsoleKey.Backspace:
                        browsing = false;
                        CategoriesPage.CatPage();
                        break;
                    case ConsoleKey.D4:
                        browsing = false;
                        StartPage.Search("BrowseAll");
                        break;
                    case ConsoleKey.D5:
                        browsing = false;
                        LoginPage.Login();
                        break;
                    case ConsoleKey.D6:
                        browsing = false;
                        if (Program.user == false)
                        {
                            SignUp.SignUpPage();
                        }
                        if (Program.user == true)
                        {
                            CartPage.UserCart(Program.CurrentUser);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public static void BrowseAll(int cat, string name)
        {
            ElementsHelper.WindowDavinci("BrowseAll");
            List<Product> productList = ElementsHelper.GetProducts(cat);
            int lookingAt = 0;
            bool browsing = true;

            if (cat == 00) 
            {
                browsing = false;
                Console.Clear();
                Console.WriteLine("Error 404: There's nothing here");
                Console.WriteLine("Press any key to return to the startpage");
                StartPage.Start();
            }

            Console.SetCursorPosition(80, 20);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Browsing [" + name + "]");
            Console.ForegroundColor = ConsoleColor.White;

            Console.SetCursorPosition(135, 20);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("[W] UP [S] Down [Enter] See Details [BackSpace] Back");
            Console.ForegroundColor = ConsoleColor.White;

            while (browsing)
            {
                Console.SetCursorPosition(50, 21);
                foreach (var p in productList)
                {
                    if (p == productList[lookingAt])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Name: [{p.Name}] \t Size: {p.Size} \t Stock: {p.Stock} \t Price: {p.Price} \t [See Details]");
                        Console.SetCursorPosition(50, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    Console.WriteLine($"Name: [{p.Name}] \t Size: {p.Size} \t Stock: {p.Stock} \t Price: {p.Price} \t [See details]");
                    Console.SetCursorPosition(50, Console.CursorTop);
                }

                Console.SetCursorPosition(0, 0);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.S:
                        {
                            if (lookingAt < productList.Count - 1)
                            {
                                lookingAt++;
                            }
                        }
                        break;
                    case ConsoleKey.W:
                        {
                            if (lookingAt >= 1)
                                lookingAt--;
                        }
                        break;
                    case ConsoleKey.Escape:
                        {
                            browsing = false;
                            StartPage.Start();
                        }
                        break;
                    case ConsoleKey.Enter:
                        browsing = false;
                        ProductDetailsPage.ProductDetails(productList[lookingAt], cat, name);
                        break;
                    case ConsoleKey.Backspace:
                        browsing = false;
                        CategoriesPage.CatPage();
                        break;
                    case ConsoleKey.D4:
                        browsing = false;
                        StartPage.Search("BrowseAll");
                        break;
                    case ConsoleKey.D5:
                        browsing = false;
                        LoginPage.Login();
                        break;
                    case ConsoleKey.D6:
                        browsing = false;
                        if (Program.user == false)
                        {
                            SignUp.SignUpPage();
                        }
                        if (Program.user == true)
                        {
                            CartPage.UserCart(Program.CurrentUser);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        public static void BrowseAll(string Search)
        {
            ElementsHelper.WindowDavinci("BrowseAll");
            List<Product> productList = ElementsHelper.GetProducts(Search);
            int lookingAt = 0;
            bool browsing = true;

            Console.SetCursorPosition(80, 20);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Browsing " + productList.Count + " Results");
            Console.ForegroundColor = ConsoleColor.White;

            if (productList.Count == 0)
            {
                Console.SetCursorPosition(80, 21);
                Console.WriteLine("nothing was found press any key to go back");
                Console.ReadKey();
                return;
            }

            Console.SetCursorPosition(135, 20);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("[W] UP [S] Down [Enter] See Details [BackSpace] Back");
            Console.ForegroundColor = ConsoleColor.White;

            while (browsing)
            {
                Console.SetCursorPosition(50, 21);
                foreach (var p in productList)
                {
                    if (p == productList[lookingAt])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Name: [{p.Name}] \t Size: {p.Size} \t Stock: {p.Stock} \t Price: {p.Price} \t [See Details]");
                        Console.SetCursorPosition(50, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    Console.WriteLine($"Name: [{p.Name}] \t Size: {p.Size} \t Stock: {p.Stock} \t Price: {p.Price} \t [See details]");
                    Console.SetCursorPosition(50, Console.CursorTop);
                }

                Console.SetCursorPosition(0, 0);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.S:
                        {
                            if (lookingAt < productList.Count - 1)
                            {
                                lookingAt++;
                            }
                        }
                        break;
                    case ConsoleKey.W:
                        {
                            if (lookingAt >= 1)
                                lookingAt--;
                        }
                        break;
                    case ConsoleKey.Escape:
                        {
                            browsing = false;
                            StartPage.Start();
                        }
                        break;
                    case ConsoleKey.Enter:
                        browsing = false;
                        ProductDetailsPage.ProductDetails(productList[lookingAt]);
                        break;
                    case ConsoleKey.Backspace:
                        browsing = false;
                        CategoriesPage.CatPage();
                        break;
                    case ConsoleKey.D4:
                        browsing = false;
                        StartPage.Search("BrowseAll");
                        break;
                    case ConsoleKey.D5:
                        browsing = false;
                        LoginPage.Login();
                        break;
                    case ConsoleKey.D6:
                        browsing = false;
                        if (Program.user == false)
                        {
                            SignUp.SignUpPage();
                        }
                        if (Program.user == true)
                        {
                            CartPage.UserCart(Program.CurrentUser);
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
