using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Data.Framework
{
    internal class Settings
    {
        internal static string GetConnectionString()
        {
            return $"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MauiAppLorenzo;Integrated Security=True;Connect Timeout=30;TrustServerCertificate=False;";
        }
    }
}
