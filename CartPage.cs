using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopsimpler.Models;

namespace webshopsimpler
{
    internal class CartPage
    {
        public static void UserCart(User u) 
        {
            using (var db = new WebshopDbContext()) 
            {
                var Carts = db.ShoppingCarts.Where(c => c.UserId == u.Id && c.Status == "In cart").Join(db.Products, c => c.ProductId, p => p.Id, (c, p) => new { c, p }).ToList();
                int row = 10;
                decimal cartTotal = 0;

                if (Carts.Count == 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition(90, 25);
                    Console.WriteLine("Your cart is empty.");
                    Console.SetCursorPosition(90, 26);
                    Console.WriteLine("Press any key to go back.");
                    Console.ReadKey();
                    return;
                }

                ElementsHelper.WindowDavinci("CartPage");

                foreach (var c in Carts)
                {
                    Console.SetCursorPosition(32, row++);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"{c.p.Name, -20} Size: {c.p.Size,-5} Stock: {c.p.Stock,-5} Quantity: [{c.c.Quantity}]{" ",-5} Price: {c.p.Price,-5} Total: {c.c.Quantity * c.p.Price} ");
                    cartTotal += (c.c.Quantity * c.p.Price);
                }

                Console.SetCursorPosition(142, 28);
                Console.WriteLine("(Excluding shipping)");
                Console.SetCursorPosition(142, 30);
                Console.Write($"Total: {cartTotal}:-");

                switch (Console.ReadKey().Key) 
                {
                    case ConsoleKey.Enter:
                        CheckOut(u , cartTotal);
                        break;
                    case ConsoleKey.Escape:
                        StartPage.Start();
                        break;
                    case ConsoleKey.E:
                        EditCart(u);
                        break;
                }

            }
        }

        static void EditCart(User u) 
        {
            using (var db = new WebshopDbContext())
            {
                Start:
                var Carts = db.ShoppingCarts.Where(c => c.UserId == u.Id && c.Status == "In cart").Join(db.Products, c => c.ProductId, p => p.Id, (c, p) => new { c, p }).ToList();
                bool browsing = true;
                int row;
                int i = 0;

                if (Carts.Count == 0) 
                {
                    UserCart(u);
                }

                ElementsHelper.WindowDavinci("CartPage");

                while (browsing)
                {
                    row = 10;
                    Console.SetCursorPosition(31, 9);
                    Console.WriteLine("[W]UP[S]DOWN [ENTER]Select [X]Remove [ESC]Cancel");
                    foreach (var c in Carts)
                    {
                        if (c == Carts[i]) 
                        {
                            Console.SetCursorPosition(32, row++);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($"{c.p.Name,-20} Size: {c.p.Size,-5} Stock: {c.p.Stock,-5} Quantity: [{c.c.Quantity}]{" ",-5} Price: {c.p.Price,-5} Total: {c.c.Quantity * c.p.Price} ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            continue;
                        }
                        Console.SetCursorPosition(32, row++);
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($"{c.p.Name,-20} Size: {c.p.Size,-5} Stock: {c.p.Stock,-5} Quantity: [{c.c.Quantity}]{" ",-5} Price: {c.p.Price,-5} Total: {c.c.Quantity * c.p.Price} ");
                    }

                    switch1:
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.W:
                            if (i > 0) 
                            {
                                i--;
                            }
                            break;
                        case ConsoleKey.S:
                            if (i < Carts.Count - 1)
                            {
                                i++;
                            }
                            break;
                       
                        case ConsoleKey.Enter:
                            var post = db.ShoppingCarts.Where(S => S.Id == Carts[i].c.Id).FirstOrDefault();
                            Console.SetCursorPosition(32, row++);
                            Console.WriteLine("[W] add 1, [S]Subtract 1, [ESC]Back");
                            
                            switch (Console.ReadKey().Key)
                            {
                                
                                case ConsoleKey.W:
                                    post.Quantity++;
                                    db.Update(post);
                                    db.SaveChanges();
                                    goto Start;
                                
                                case ConsoleKey.S:
                                    if (post.Quantity > 1)
                                    {
                                        post.Quantity--;
                                    }
                                    db.Update(post);
                                    db.SaveChanges();
                                    goto Start;
                                
                                case ConsoleKey.Escape:
                                    goto switch1;
                            }
                            break;
                       
                        case ConsoleKey.X:
                            var postnt = db.ShoppingCarts.Where(S => S.Id == Carts[i].c.Id).FirstOrDefault();
                            db.ShoppingCarts.Remove(postnt);
                            db.SaveChanges();
                            goto Start;
                        
                        case ConsoleKey.Escape:
                            browsing = false;
                            UserCart(u);
                            break;
                    }
                }

            }
        }

        static void CheckOut(User u, decimal cartTotal) 
        {
            using (var db = new WebshopDbContext())
            {
                var cartcontent = 
                    db.ShoppingCarts.Where(c => c.UserId == u.Id && c.Status == "In cart").
                    Join(db.Products, c => c.ProductId, p => p.Id, (c, p) => new { c, p }).ToList();


                var orders = db.ShoppingCarts.Where(c => c.UserId == u.Id && c.Status == "In cart").ToList();
                var ShippingMethods = db.ShippingMethods.ToList();
                
                here:
                decimal Total = cartTotal;
                PaymentMethod PayMethod = PayMethodMaker();
                ShippingMethod ShipMethod = ShippingMethodGetter(ShippingMethods);
                ElementsHelper.WindowDavinci("Checkout");

                int row = 10;
                foreach (var c in cartcontent) 
                {
                    Console.SetCursorPosition(32, row++);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write($"{c.p.Name,-20} Size: {c.p.Size,-5} Stock: {c.p.Stock,-5} Quantity: [{c.c.Quantity}]{" ",-5} Price: {c.p.Price,-5} Total: {c.c.Quantity * c.p.Price} ");
                }

                Console.SetCursorPosition(142, 25);
                Console.WriteLine(ShipMethod.Name + ": " + ShipMethod.Price + ":-");
                Console.SetCursorPosition(142, 28);
                Console.WriteLine("(Including shipping)");
                Console.SetCursorPosition(142, 29);
                Console.WriteLine("(Including Taxes)");
                Console.SetCursorPosition(142, 30);
                Console.Write($"Total: {Total + ShipMethod.Price}:-");

                missclick:
                switch (Console.ReadKey().Key) 
                {
                    case ConsoleKey.Enter:
                        db.Add(PayMethod);
                        db.SaveChanges();
                        foreach (var o in orders)
                        {
                            var p = db.Products.Where(p => p.Id == o.ProductId).FirstOrDefault();
                            p.Stock = (p.Stock - o.Quantity);

                            o.PaymentMethodId = PayMethod.Id;
                            o.ShippingMethodId = ShipMethod.Id;
                            o.IsPaid = true;
                            o.Status = "Done";

                            db.Update(o);
                            db.Update(p);
                            db.SaveChanges();
                        }
                        //db.SaveChanges();
                        Console.Clear();
                        Console.SetCursorPosition(90, 15);
                        Console.WriteLine("Transaction successfull, Your items will arrive soon!");
                        Thread.Sleep(1500);
                        return;
                    case ConsoleKey.E:
                        goto here;
                    case ConsoleKey.Escape:
                        return;
                    default:
                        goto missclick;
                }

                //save payment method

            }
        }

        static PaymentMethod PayMethodMaker() 
        {
            using (var db = new WebshopDbContext()) 
            {
                var PaymentTypes = db.PaymentTypes.ToList();
                PaymentType PayType = PayTypeGetter(PaymentTypes);

                if (PayType.PaymentTypeName == "PayPal")
                {
                    int NotRandomNumber = Random.Shared.Next(100000, 999999);

                    PaymentMethod PayPal = new PaymentMethod
                    {
                        PaymentTypeId = PayType.Id,
                        Provider = "PayPal",
                        AccountNumber = "PayPal Transaction: " + NotRandomNumber,
                        ExpiryDate = "https://www.Paypal.com/invoice/transaction&info" + NotRandomNumber,
                    };
                    return PayPal;
                }

                else 
                {
                    PaymentMethod CreditCard = new PaymentMethod
                    {
                        PaymentTypeId = PayType.Id,
                        Provider = SignUp.GetString("Enter Card Provider"),
                        AccountNumber = SignUp.GetString("Enter card number"),
                        ExpiryDate = SignUp.GetString("Enter ExpiryDate MM/YY"),
                    };
                    SignUp.GetString("Enter CVV"); //lole
                    return CreditCard;
                }

            }


        }

        static PaymentType PayTypeGetter(List<PaymentType> PayType)
        {
            Console.Clear();
            int i = 0;
            Console.SetCursorPosition(90, 28);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Select Payment Method [W] up [S] down [Enter] Select");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.SetCursorPosition(90, 30);
                foreach (var Type in PayType)
                {
                    if (Type == PayType[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Type.PaymentTypeName);
                        Console.SetCursorPosition(90, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    Console.WriteLine(Type.PaymentTypeName);
                    Console.SetCursorPosition(90, Console.CursorTop);
                }

                Console.SetCursorPosition(0, 0);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.S:
                        {
                            if (i < PayType.Count - 1)
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
                        Console.WriteLine("You selected: " + PayType[i].PaymentTypeName);
                        Console.SetCursorPosition(70, 30);
                        Console.WriteLine("Press [ENTER] to confirm         Press [BACKSPACE] to select another method");
                        ConsoleKey key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            return PayType[i];
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

        static ShippingMethod ShippingMethodGetter(List<ShippingMethod> shippingMethods)
        {
            Console.Clear();
            int i = 0;
            Console.SetCursorPosition(90, 28);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Select Shipping Method [W] up [S] down [Enter] Select");
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.SetCursorPosition(90, 30);
                foreach (var s in shippingMethods)
                {
                    if (s == shippingMethods[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(s.Name + " Price: " + s.Price + ":-");
                        Console.SetCursorPosition(90, Console.CursorTop);
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                    Console.WriteLine(s.Name + " Price: " + s.Price + ":-");
                    Console.SetCursorPosition(90, Console.CursorTop);
                }

                Console.SetCursorPosition(0, 0);

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.S:
                        {
                            if (i < shippingMethods.Count - 1)
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
                        Console.WriteLine("You selected: " + shippingMethods[i].Name + " " + shippingMethods[i].Price + ":-");
                        Console.SetCursorPosition(70, 30);
                        Console.WriteLine("Press [ENTER] to confirm         Press [BACKSPACE] to select another method");
                        ConsoleKey key = Console.ReadKey().Key;
                        if (key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            return shippingMethods[i];
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
