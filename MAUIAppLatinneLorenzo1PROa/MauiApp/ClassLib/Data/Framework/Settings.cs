using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Data.Framework
{
    internal static class Settings
    {
        internal static string GetConnectionString()
        {
            return $"Data Source=Lorenzo-PC\\SQLEXPRESS;Initial Catalog=LorenzoMAUI;Integrated Security=True;Connect Timeout=30;Trust Server Certificate=True;";
        }
    }
}
