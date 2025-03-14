using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopsimpler.Models;
using static webshopsimpler.ElementsHelper;

namespace webshopsimpler
{
    internal class ElementsManager
    {
        
        public static List<Window> Windows { get; set; }

        public static List<Window> GetAllWindows()
        {

            if (Windows == null || !Windows.Any())
                {
                    Windows = new List<Window>
                {
                    new Window()
                    {
                        Header = "Product of the day(1)",
                        Left = 55,
                        Top = 30,
                        TextRows = new List<string>()
                        {
                            GetSelectProduct(0).Name,
                            "Price: " + GetSelectProduct(0).Price.ToString() + ":-",
                            "",
                            ""
                        },
                        Scene = new List<string>()
                        {
                            "StartPage",
                            "",
                            "",
                            ""
                        },
                        Desc = "Potd1",
                        Singleid = (GetSelectProduct(0).Id),
                    }, //special product1
                    new Window()
                    {
                        Header = "Product of the day(2)",
                        Left = 90,
                        Top = 30,
                        TextRows = new List<string>()
                        {
                            GetSelectProduct(1).Name,
                            "Price: " + GetSelectProduct(1).Price + ":-",
                            "",
                            ""
                        },
                        Scene = new List<string>()
                        {
                            "StartPage",
                            "",
                            "",
                            ""
                        },
                        Desc = "Potd2",
                        Singleid = (GetSelectProduct(1).Id),

                    }, //special product2
                    new Window()
                    {
                        Header = "Product of the day(3)",
                        Left = 125,
                        Top = 30,
                        TextRows = new List<string>()
                        {
                            GetSelectProduct(2).Name,
                            "Price: " + GetSelectProduct(2).Price + ":-",
                            "",
                            ""
                        },
                        Scene = new List<string>()
                        {
                            "StartPage",
                            "",
                            "",
                            ""
                        },
                        Desc = "Potd3",
                        Singleid = (GetSelectProduct(2).Id),

                    }, //special product3
                    new Window()
                    {
                        Header = "Category (1)",
                        Left = 60,
                        Top = 28,
                        TextRows = new List<string>()
                        {
                            "",
                           "    [" + GetProductCategory(0).CategoryName + "]",
                            "     " + GetProductCategory(0).Description,
                            ""
                        },
                        Scene = new List<string>()
                        {
                            "Categories",
                            "",
                            "",
                            ""
                        },
                        Desc = "Cat1",
                        Singleid = (GetProductCategory(0).Id),
                    }, //category 1
                    new Window()
                    {
                        Header = "Category (2)",
                        Left = 85,
                        Top = 28,
                        TextRows = new List<string>()
                        {
                            "",
                            "[" + GetProductCategory(1).CategoryName + "]",
                            GetProductCategory(1).Description,
                            ""
                        },
                        Scene = new List<string>()
                        {
                            "Categories",
                            "",
                            "",
                            ""
                        },
                        Desc = "Cat2",
                        Singleid = GetProductCategory(1).Id,
                    }, //category 2
                    new Window()
                    {
                        Header = "Category (3)",
                        Left = 118,
                        Top = 28,
                        TextRows = new List<string>()
                        {
                            "",
                            "[" + GetProductCategory(2).CategoryName + "]",
                            GetProductCategory(2).Description,
                            ""
                        },
                        Scene = new List<string>()
                        {
                            "Categories",
                            "",
                            "",
                            ""
                        },
                        Desc = "Cat3",
                        Singleid = GetProductCategory(2).Id,
                    }, //category 3
                    new Window()
                    {
                        Header = "──────────────────────",
                        Left = 90,
                        Top = 5,
                        TextRows = new List<string>()
                        {
                            " Search...  (4)       "
                        },
                        Scene = new List<string>()
                        {
                            "StartPage",
                            "Categories",
                            "BrowseAll",
                            "ProductPage"
                        },
                        Desc = "Searchbar",
                        Aesthetic = true,
                    }, //Searchbar
                    new Window()
                    {
                        Header = "Selected product",
                        Left = 15,
                        Top = 20,
                        TextRows = new List<string>()
                        {
                            ""
                        },
                        Scene = new List<string>()
                        {
                            "ProductPage",
                            "",
                            "",
                            ""
                        },
                        Desc = "Product",
                    }, //UserSelected product
                    new Window()
                    {
                        Header = "[Enter]",
                        Left = 130,
                        Top = 15,
                        TextRows = new List<string>()
                        {
                            "ADD TO CART",
                        },
                        Scene = new List<string>()
                        {
                            "ProductPage",
                        },
                        Desc = "ADDTOCART",
                        Aesthetic = true,
                    }, //ADDTOCARTbutton
                    new Window()
                    {
                        Header = "5",
                        Left = 189,
                        Top = 1,
                        TextRows = new List<string>()
                        {
                            "Login"
                        },
                        Scene = new List<string>()
                        {
                            "StartPage",
                            "Categories",
                            "BrowseAll",
                            "ProductPage",
                            "CartPage",
                            "AdminView",
                            "AdminStart",
                            "AdminViewC",
                            "AdminViewS"
                        },
                        Desc = "Login",
                    }, //LoginButton
                    new Window()
                    {
                        Header = "6",
                        Left = 178,
                        Top = 1,
                        TextRows = new List<string>()
                        {
                            "Sign up"
                        },
                        Scene = new List<string>()
                        {
                            "StartPage",
                            "Categories",
                            "ProductPage",
                            "BrowseAll",
                            "CartPage",
                            "AdminView",
                            "AdminStart",
                            "AdminViewC",
                            "AdminViewS"
                        },
                        Desc = "Sign up",
                    }, //Sign up
                    new Window()
                    {
                        Header = "",
                        Left = 1,
                        Top = 1,
                        TextRows = new List<string>()
                        {
                            "   Home",
                            "  (ESC)"
                        },
                        Scene = new List<string>()
                        {
                            "StartPage",
                            "Categories",
                            "ProductPage",
                            "BrowseAll",
                            "CartPage",
                            "AdminView",
                            "AdminStart",
                            "AdminViewC",
                            "AdminViewS"
                        },
                        Desc = "Home",
                    }, //home/logo
                    new Window()
                    {
                        Header = "",
                        Left = 146,
                        Top = 28,
                        TextRows = new List<string>()
                        {
                            "      (7)",
                            "See all products",
                            "",
                            ""
                        },
                        Scene = new List<string>()
                        {
                            "Categories",
                            "",
                            "",
                            ""
                        },
                        Desc = "BrowseAllButton",
                    }, //BrowseAllButton
                    new Window()
                    {
                        Header = "See more",
                        Left = 105,
                        Top = 12,
                        TextRows = new List<string>()
                        {
                            "click here to see more products!!!!!",
                            "                (7)        ",
                            "",
                            ""
                        },
                        Scene = new List<string>()
                        {
                            "StartPage",
                            "",
                            "",
                            ""
                        },
                        Desc = "SeeCategoriesButton",
                    }, // see categories from startpage
                    new Window()
                    {
                        Header = "[BackSpace]",
                        Left = 145,
                        Top = 15,
                        TextRows = new List<string>()
                        {
                            "Return to browsing",
                        },
                        Scene = new List<string>()
                        {
                            "ProductPage",
                        },
                        Desc = "Return to browsing",
                        Aesthetic = true,
                    }, // return to browsing from product
                    new Window()
                    {
                        Header = "Username",
                        Left = 93,
                        Top = 19,
                        TextRows = new List<string>()
                        {
                            "               ",
                        },
                        Scene = new List<string>()
                        {
                            "LoginPage",
                        },
                        Desc = "UsernameInput",
                        Aesthetic = true,
                    }, // Loginbox username
                    new Window()
                    {
                        Header = "Password",
                        Left = 93,
                        Top = 22,
                        TextRows = new List<string>()
                        {
                            "               ",
                        },
                        Scene = new List<string>()
                        {
                            "LoginPage",
                        },
                        Desc = "PasswordInput",
                        Aesthetic = true,
                    }, // Loginbox Password
                    new Window()
                    {
                        Header = "Shopping Cart",
                        Left = 30,
                        Top = 8,
                        TextRows = new List<string>()
                        {
                            $"{" ",-100}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                        },
                        Scene = new List<string>()
                        {
                            "CartPage",
                        },
                        Desc = "Cart",
                        Aesthetic = true,
                    }, // Cartbox
                    new Window()
                    {
                        Header = "[Enter]",
                        Left = 139,
                        Top = 38,
                        TextRows = new List<string>()
                        {
                            "",
                            "Checkout",
                        },
                        Scene = new List<string>()
                        {
                            "CartPage",
                        },
                        Desc = "CheckoutButton",
                        Aesthetic = true,
                    }, // CheckoutButton
                    new Window()
                    {
                        Header = "[E]",
                        Left = 155,
                        Top = 38,
                        TextRows = new List<string>()
                        {
                            "",
                            "Edit Cart",
                        },
                        Scene = new List<string>()
                        {
                            "CartPage",
                        },
                        Desc = "EditCart",
                        Aesthetic = true,
                    }, // edit cart button
                    new Window()
                    {
                        Header = "",
                        Left = 139,
                        Top = 8,
                        TextRows = new List<string>()
                        {
                            $"{" ",-25}",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                        },
                        Scene = new List<string>()
                        {
                            "CartPage",
                        },
                        Desc = "InfoBox",
                        Aesthetic = true,
                    }, // InfoBox CartPage
                    new Window()
                    {
                        Header = "",
                        Left = 30,
                        Top = 8,
                        TextRows = new List<string>()
                        {
                            $"{" ",-100}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                            $"{" ",-85}",
                        },
                        Scene = new List<string>()
                        {
                            "Checkout",
                            "AdminView",
                            "AdminViewC",
                            "AdminViewS"
                        },
                        Desc = "CheckoutCartBox",
                        Aesthetic = true,
                    }, //Checkout Cartbox
                    new Window()
                    {
                        Header = "",
                        Left = 139,
                        Top = 8,
                        TextRows = new List<string>()
                        {
                            $"{" ",-25}",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                            "",
                        },
                        Scene = new List<string>()
                        {
                            "Checkout",
                            "AdminView",
                            "AdminViewC",
                        },
                        Desc = "CheckoutInfoBox",
                        Aesthetic = true,
                    }, //Checkout infobox
                    new Window()
                    {
                        Header = "[E]",
                        Left = 161,
                        Top = 38,
                        TextRows = new List<string>()
                        {
                            "",
                            "Change payment details",
                        },
                        Scene = new List<string>()
                        {
                            "Checkout",
                        },
                        Desc = "ChangePayment",
                        Aesthetic = true,
                    }, // Checkout change details
                    new Window()
                    {
                        Header = "[Enter]",
                        Left = 139,
                        Top = 38,
                        TextRows = new List<string>()
                        {
                            "",
                            "Confirm purchase",
                        },
                        Scene = new List<string>()
                        {
                            "Checkout",
                        },
                        Desc = "Purchase",
                        Aesthetic = true,
                    }, // confirm purchase
                    new Window()
                    {
                        Header = "[1]",
                        Left = 55,
                        Top = 30,
                        TextRows = new List<string>()
                        {
                            "",
                            "Edit or add products",
                        },
                        Scene = new List<string>()
                        {
                            "AdminStart",
                        },
                        Desc = "EditOrAddProducts",
                        Aesthetic = true,
                    }, //adminstart edit products
                    new Window()
                    {
                        Header = "[2]",
                        Left = 90,
                        Top = 30,
                        TextRows = new List<string>()
                        {
                            "",
                            "Access customer data",
                        },
                        Scene = new List<string>()
                        {
                            "AdminStart",
                        },
                        Desc = "CustomerDataStart",
                        Aesthetic = true,
                    }, // Adminstart customer data
                    new Window()
                    {
                        Header = "[3]",
                        Left = 125,
                        Top = 30,
                        TextRows = new List<string>()
                        {
                            "",
                            "Statistics",
                        },
                        Scene = new List<string>()
                        {
                            "AdminStart",
                        },
                        Desc = "Statsbutton",
                        Aesthetic = true,
                    }, //adminstart statsbutton
                    new Window()
                    {
                        Header = "[Enter]",
                        Left = 139,
                        Top = 38,
                        TextRows = new List<string>()
                        {
                            "",
                            " Select ",
                        },
                        Scene = new List<string>()
                        {
                            "AdminView",
                            "AdminViewC"
                        },
                        Desc = "AdminSelect",
                        Aesthetic = true,
                    }, //Admin select
                    new Window()
                    {
                        Header = "[E]",
                        Left = 155,
                        Top = 38,
                        TextRows = new List<string>()
                        {
                            "",
                            "Add new product",
                        },
                        Scene = new List<string>()
                        {
                            "AdminView"
                        },
                        Desc = "AdminAdd",
                        Aesthetic = true,
                    }, // Admin Add
                    new Window()
                    {
                        Header = "[E]",
                        Left = 155,
                        Top = 38,
                        TextRows = new List<string>()
                        {
                            "",
                            "Customer orders",
                        },
                        Scene = new List<string>()
                        {
                            "AdminViewC"
                        },
                        Desc = "AdminAdd",
                        Aesthetic = true,
                    }, //adminviewC customer ordersbutton

                }; 
                }

            return Windows;
        }



        
        //public static void WindowPositioner(List<Window> allwindows) 
        //{
        //    var testWindow = allwindows.Where(x => x.Header == "Username"); // Window to position
        //    var otherwindows = allwindows.Where(x => x.Scene.Contains("LoginPage"));


        //    while (true)
        //    {
        //        //StartPage.PeepoGladStart();
        //        foreach (var w in otherwindows)
        //        { w.Draw(); }
        //        foreach (var w in testWindow)
        //        {

        //            Console.SetCursorPosition(0, 0);
        //            Console.WriteLine("Left: " + w.Left + " Top: " + w.Top);
        //            w.Draw();
        //            var a = Console.ReadKey();


        //            switch (a.KeyChar)
        //            {
        //                case 'a':
        //                    w.Left++; Console.Clear(); w.Draw();
        //                    break;
        //                case 'd':
        //                    if (w.Left != 0) { w.Left--; }
        //                    Console.Clear(); w.Draw();
        //                    break;
        //                case 'w':
        //                    w.Top++; Console.Clear(); w.Draw();
        //                    break;
        //                case 's':
        //                    if (w.Top != 0) { w.Top--; }
        //                    Console.Clear(); w.Draw();
        //                    break;

        //            }

        //        }
        //    }
        //}
    }
}
