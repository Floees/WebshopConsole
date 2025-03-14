using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webshopsimpler.Models;

namespace webshopsimpler
{
    internal class ElementsHelper
    {
        public static Product GetSelectProduct(int i) 
        {
            using (var db = new WebshopDbContext()) 
            {
                var products = db.Products.Where(p => p.SelectProduct.Equals(true)).ToList();

                if (products.Count > i)
                {
                    Product SelectProduct = new Product
                    {
                        Id = products[i].Id,
                        Name = products[i].Name,
                        Description = products[i].Description,
                        Price = products[i].Price,
                        SelectProduct = products[i].SelectProduct,
                        ProductCategoryId = products[i].ProductCategoryId,
                        ProductCategory = products[i].ProductCategory,
                        Size = products[i].Size,
                        Dimensions = products[i].Dimensions,
                        Stock = products[i].Stock
                    };
                    return SelectProduct;
                }
                else
                {
                    Product product = new Product
                    {
                        Name = "Come back later!",
                        Price = 0,
                        Id = 00,
                    };
                    return product;
                }
            }

        } // Provides admins select products to be displayed on the front page.

        public static ProductCategory GetProductCategory(int i)
        {
            using (var db = new WebshopDbContext())
            {
                var productCategories = db.ProductCategories.ToList();
                if (productCategories.Count > i)
                {
                    ProductCategory productCategory = new ProductCategory
                    {
                        Id = productCategories[i].Id,
                        CategoryName = productCategories[i].CategoryName,
                        Description = productCategories[i].Description,
                    };
                    return productCategory;
                }
                else
                {
                    ProductCategory productCategory = new ProductCategory
                    {
                        CategoryName = "Oops there's nothing here yet!",
                        Id = 00,
                    };
                    return productCategory;
                }
            }
        } // this gets an entry from category table.

        public static List<Product> GetProducts(int i)
        {
            using (var db = new WebshopDbContext())
            {
                var products = db.Products.Where(p => p.ProductCategoryId == i).ToList();
                return products;
            }
        } // Returns a list of products by category.

        public static List<Product> GetProducts()
        {
            using (var db = new WebshopDbContext())
            {
                var products = db.Products.ToList();
                return products;
            }
        } // Returns a list of all products.

        public static List<Product> GetProducts(string Search)
        {
            using (var db = new WebshopDbContext())
            {
                var products = db.Products.Where(p => EF.Functions.Like(p.Name, Search) ||
                                                      EF.Functions.Like(p.Description, Search) ||
                                                      EF.Functions.Like(p.Size, Search)).ToList();
                return products;
            }
        }

        public static void WindowDavinci(string Scene)
        {
            here:
            try
            {
                Console.Clear();

                var windows = Program.allwindows.Where(x => x.Scene.Contains(Scene));

                foreach (var w in windows)
                {
                    w.Draw();
                }
                if (Program.superuser == true && Scene == "StartPage") 
                {
                    Window admin = new Window()
                    {
                        Header = "[Enter]",
                        Left = 150,
                        Top = 40,
                        TextRows = [ "", "AdminMode", ],
                        Scene = [ "StartPage", ],
                        Desc = "AdminButton",
                        Aesthetic = true,
                    };
                    admin.Draw();
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Please use fullscreen");
                Console.WriteLine("Press any key to restart");
                Console.ReadKey();
                goto here;
            }
        } // Draws windows by scene.

        public static void WindowDavinci(string Scene, Product p) 
        {
            Console.Clear();
            var windows = Program.allwindows.Where(x => x.Scene.Contains(Scene));

            foreach (var w in windows) 
            {
                if (w.Desc == "Product")
                {
                    w.Header = "[" + p.Name + "]";
                    w.TextRows.Clear();
                    w.TextRows.Add("");
                    w.TextRows.Add($"Size: {p.Size}");
                    w.TextRows.Add($"Dimensions: {p.Dimensions}mm");
                    w.TextRows.Add($"Stock: {p.Stock}");
                    w.TextRows.Add($"Price: {p.Price}:-");
                    w.TextRows.Add($"Description: {p.Description}");
                }
                w.Draw();
            }
        } // Draws windows by scene and product.

    }
}
