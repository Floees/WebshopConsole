using System.Drawing;
using System.Security.Principal;
using static webshopsimpler.ElementsManager;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using webshopsimpler.Models;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Storage;

namespace webshopsimpler
    
{
    internal class Program
    {
        public static List<Window> allwindows = GetAllWindows();
        public static bool user = false;
        public static bool superuser = false;
        public static User CurrentUser = null;
        static void Main(string[] args)
        {

            while (true)
            {
                StartPage.Start();
            }


        }
    }

}
