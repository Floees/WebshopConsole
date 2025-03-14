using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webshopsimpler
{
    internal class StartPage
    {
        public static void Start() 
        {
            ElementsHelper.WindowDavinci("StartPage");
            PeepoGladStart();

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    ProductDetailsPage.ProductDetails(ElementsHelper.GetSelectProduct(0));
                    break;
                case ConsoleKey.D2:
                    ProductDetailsPage.ProductDetails(ElementsHelper.GetSelectProduct(1));
                    break;
                case ConsoleKey.D3:
                    ProductDetailsPage.ProductDetails(ElementsHelper.GetSelectProduct(2));
                    break;
                case ConsoleKey.D4:
                    Search("StartPage");
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
                case ConsoleKey.D7:
                    CategoriesPage.CatPage();
                    break;
                case ConsoleKey.Enter:
                    if (Program.superuser == true) 
                    {
                        Admin.AdminStart();
                    }
                    break;
            }

        }
        public static void PeepoGladStart() 
        {
            int i = 12;
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⣿⣿⣿⣿⣿⣿⠿⢋⣥⣴⣶⣶⣶⣬⣙⠻⠟⣋⣭⣭⣭⣭⡙⠻⣿⣿⣿⣿⣿");
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⣿⣿⣿⣿⡿⢋⣴⣿⣿⠿⢟⣛⣛⣛⠿⢷⡹⣿⣿⣿⣿⣿⣿⣆⠹⣿⣿⣿⣿");
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⣿⣿⣿⡿⢁⣾⣿⣿⣴⣿⣿⣿⣿⠿⠿⠷⠥⠱⣶⣶⣶⣶⡶⠮⠤⣌⡙⢿⣿");
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⣿⡿⢛⡁⣾⣿⣿⣿⡿⢟⡫⢕⣪⡭⠥⢭⣭⣉⡂⣉⡒⣤⡭⡉⠩⣥⣰⠂⠹");
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⡟⢠⣿⣱⣿⣿⣿⣏⣛⢲⣾⣿⠃⠄⠐⠈⣿⣿⣿⣿⣿⣿⠄⠁⠃⢸⣿⣿⡧");
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⢠⣿⣿⣿⣿⣿⣿⣿⣿⣇⣊⠙⠳⠤⠤⠾⣟⠛⠍⣹⣛⣛⣢⣀⣠⣛⡯⢉⣰");
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡶⠶⢒⣠⣼⣿⣿⣛⠻⠛⢛⣛⠉⣴⣿⣿");
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⡿⢛⡛⢿⣿⣿⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡈⢿⣿ ");
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⠸⣿⡻⢷⣍⣛⠻⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⢇⡘⣿");
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣷⣝⠻⠶⣬⣍⣛⣛⠓⠶⠶⠶⠤⠬⠭⠤⠶⠶⠞⠛⣡⣿");
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣶⣬⣭⣍⣙⣛⣛⣛⠛⠛⠛⠿⠿⠿⠛⣠⣿⣿");
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⣦⣈⠉⢛⠻⠿⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠛⣁⣴⣾⣿⣿⣿⣿");
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⣿⣿⣿⣶⣮⣭⣁⣒⣒⣒⠂⠠⠬⠭⠭⠭⢀⣀⣠⣄⡘⠿⣿⣿⣿⣿⣿⣿⣿");
            Console.SetCursorPosition(70, i); i++;
            Console.Write("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⡈⢿⣿⣿⣿⣿⣿");

            Console.SetCursorPosition(100, 20);
            Console.WriteLine("...What can i help you with today, traveler?");

        }

        public static void Search(string scene)
        {
            var searchbar = Program.allwindows.Where(w => w.Desc.Equals("Searchbar")).FirstOrDefault();
            searchbar.TextRows[0] = "                      ";
            ElementsHelper.WindowDavinci(scene);
            if (scene == "StartPage")
            {
                PeepoGladStart();
            }
            if (scene == "Categories") 
            {
                CategoriesPage.PeepoGladCat();
            }
            Console.SetCursorPosition(91, 6);
            string search = Console.ReadLine();
            searchbar.TextRows[0] = search;
            BrowseAllPage.BrowseAll(search);
        }
    }
}
