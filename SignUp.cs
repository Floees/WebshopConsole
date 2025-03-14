using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopsimpler.Models;

namespace webshopsimpler
{
    internal class SignUp
    {
        public static void SignUpPage() 
        {
            using (var db = new WebshopDbContext())
            {
                var countries = db.Countries.ToList();
                bool success = false;

                while (!success)
                {

                    Console.Clear();
                    Console.SetCursorPosition(90, 0);
                    Console.WriteLine("Press [ESC] to go back. ");
                    Console.SetCursorPosition(90, 1);
                    Console.WriteLine("Press any other key to get started");

                    if (Console.ReadKey().Key == ConsoleKey.Escape) 
                    {
                        return;
                    }


                    User u = new User
                    {
                        Username = GetString("Enter username"),
                        Password = GetString("Enter password"),
                        Email = GetString("Enter email"),
                        FirstLastName = GetString("Enter first and last name"),
                        Address = GetString("Enter address"),
                        PostalCode = GetString("Enter postal code"),
                        City = GetString("Enter city"),
                        CountryId = GetCountryId(countries),
                        PhoneNumber = GetString("Enter phone number"),
                        IsAdmin = false
                    };

                    var country = countries.Where(c => c.Id == u.CountryId).FirstOrDefault();
                    UserInfo(u, country);
                    Console.SetCursorPosition(80, 33);
                    Console.WriteLine("[ESC] Cancel     [ENTER] Register");


                    ConsoleKey Confirmation = Console.ReadKey().Key;

                    while (Confirmation != ConsoleKey.Enter && Confirmation != ConsoleKey.Escape)
                    {
                        Confirmation = Console.ReadKey().Key;
                    }

                    if (Confirmation == ConsoleKey.Enter)
                    {
                        db.Users.Add(u);
                        db.SaveChanges();
                        success = true;
                        Console.WriteLine("\nYour account has been created");
                        Thread.Sleep(1500);
                    }
                    
                }
            }
        }


        public static int GetCountryId(List<Country> c)
        {
            Console.Clear();
            int i = 0;
            Console.SetCursorPosition(90, 28);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Select country [W] up [S] down [Enter] Select");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.SetCursorPosition(90, 30);
                foreach (var country in c)
                {
                    if (country == c[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(country.CountryName);
                        Console.SetCursorPosition(90, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    Console.WriteLine(country.CountryName);
                    Console.SetCursorPosition(90, Console.CursorTop);
                }

                Console.SetCursorPosition(0 , 0);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.S:
                        {
                            if (i < c.Count - 1)
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
                        Console.WriteLine("You selected: " + c[i].CountryName);
                        Console.SetCursorPosition(70, 30);
                        Console.WriteLine("Press [ENTER] to confirm         Press [BACKSPACE] to select another country");
                        ConsoleKey key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Enter) 
                        {
                            Console.Clear();
                            return c[i].Id;
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

        public static string GetString(string s) // input string is used to instruct user.
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(90, 28);
                Console.Write(s);
                Console.SetCursorPosition(90, 30);
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                Here:
                    Console.SetCursorPosition(70, 33);
                    Console.WriteLine("Press [ENTER] to confirm         Press [BACKSPACE] to Write something else");
                    ConsoleKey key = Console.ReadKey().Key;

                    if (key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        return input;
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

        static void UserInfo(User u, Country c) 
        {
            Window a = new Window 
            {
                Header = "User Info",
                Left = 85,
                Top = 23,
                TextRows = new List<string>
                {
                    $"Username: {u.Username}",
                    $"Email: {u.Email}",
                    $"Name: {u.FirstLastName}",
                    $"Address: {u.Address}",
                    $"Postal Code: {u.PostalCode}",
                    $"City: {u.City}",
                    $"Country: {c.CountryName}",
                    $"Phone Number: {u.PhoneNumber}"
                }
            };
            a.Draw();
        }
    }
}
