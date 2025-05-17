using ClassLib.Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Data
{
    internal class UserData : SqlServer
    {
        public string TableName { get; set; }
        public UserData()
        {
            TableName = "Users";
        }

        public SelectResult Select()
        {
            return base.Select(TableName);
        }
    }
}
