using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static webshopsimpler.ElementsHelper;

namespace webshopsimpler
{
    internal class CategoriesPage
    {
        public static void CatPage()
        {
            ElementsHelper.WindowDavinci("Categories");
            PeepoGladCat();

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    BrowseAllPage.BrowseAll(GetProductCategory(0).Id, GetProductCategory(0).CategoryName);
                    break;
                case ConsoleKey.D2:
                    BrowseAllPage.BrowseAll(GetProductCategory(1).Id, GetProductCategory(1).CategoryName);
                    break;
                case ConsoleKey.D3:
                    BrowseAllPage.BrowseAll(GetProductCategory(2).Id, GetProductCategory(2).CategoryName);
                    break;
                case ConsoleKey.D4:
                    //Search
                    break;
                case ConsoleKey.D5:
                    //Login
                    break;
                case ConsoleKey.D6:
                    //SignUp
                    break;
                case ConsoleKey.D7:
                    BrowseAllPage.BrowseAll();
                    break;
                case ConsoleKey.Escape:
                    StartPage.Start();
                    break;
                case ConsoleKey.Backspace:
                    StartPage.Start();
                    break;
            }
        }

        public static void PeepoGladCat()
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
            Console.WriteLine("...Tell me, what are you looking for?");
        }
    }
}
