using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopsimpler.Models;

namespace webshopsimpler
{
    internal class LoginPage
    {
        public static void Login()
        {
            Program.CurrentUser = null;
            Program.user = false;
            Program.superuser = false;
            bool success = false;
            ElementsHelper.WindowDavinci("LoginPage");

            Console.SetCursorPosition(94, 20);
            string username = Console.ReadLine();

            Console.SetCursorPosition(94, 23);
            string password = Console.ReadLine();

            using (var db = new WebshopDbContext()) 
            {
                var users = db.Users.ToList();

                foreach (var u in users)
                { 
                    if (u.Username == username && u.Password == password)
                    {
                        Program.CurrentUser = u;

                        if (u.IsAdmin == true)
                        {
                            Program.user = true;
                            Program.superuser = true;
                        }
                        else
                        {
                            Program.user = true;
                        }
                        success = true;
                        Console.SetCursorPosition(94, 26);
                        Console.WriteLine("Login successful.");

                        foreach (var w in Program.allwindows)
                        {
                            if (w.Desc.Equals("Login"))
                            {
                                w.TextRows.Clear();
                                w.TextRows.Add("Logout");
                            }
                            if (w.Desc.Equals("Sign up"))
                            {
                                w.TextRows.Clear();
                                w.TextRows.Add(u.Username);
                                w.TextRows.Add("(Cart)");
                            }
                        }

                        Thread.Sleep(1500);
                        
                        break;
                    }
                }

                if (!success)
                {
                    Console.SetCursorPosition(94, 26);
                    Console.Write("Login failed.");
                    Console.SetCursorPosition(72, 30);
                    Console.Write("Press [ENTER] to try again. Press [ESC] to return to startpage");

                    foreach (var w in Program.allwindows) 
                    {
                        if (w.Desc.Equals("Login"))
                        {
                            w.TextRows.Clear();
                            w.TextRows.Add("Login");
                        }
                        if (w.Desc.Equals("Sign up"))
                        {
                            w.TextRows.Clear();
                            w.TextRows.Add("Sign up");
                        }
                    }

                    switch (Console.ReadKey().Key)
                        {
                        case ConsoleKey.Enter:
                            LoginPage.Login();
                            break;
                        case ConsoleKey.Escape:
                            StartPage.Start();
                            break;
                    }
                }

            }

        }
    }
}
