using ClassLib.Business.Entities;
using ClassLib.Data.Framework;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

        internal InsertResult Insert(User user)
        {
            InsertResult result;
            try
            {
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"Insert INTO {TableName} ");
                insertQuery.Append($"(username, password, email) VALUES ");
                insertQuery.Append($"(@username, @password, @email); ");
                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = user.Username;
                    insertCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = user.Password;
                    insertCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = user.Email;
                    result = InsertRecord(insertCommand);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            return result;
        }

        internal CountResult SelectCountUsername(string username)
        {
            using SqlCommand cmd = new($"SELECT COUNT(*) FROM {TableName} WHERE Username = @Username");
            cmd.Parameters.AddWithValue("@Username", username);
            return base.SelectCount(cmd);
        }

        internal CountResult SelectCountEmail(string email)
        {
            using SqlCommand cmd = new($"SELECT COUNT(*) FROM {TableName} WHERE Email = @Email");
            cmd.Parameters.AddWithValue("@Email", email);
            return base.SelectCount(cmd);
        }
    }
}
