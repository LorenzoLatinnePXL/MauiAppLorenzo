using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Data.Framework
{
    abstract class SqlServer
    {
        SqlConnection connection;
        SqlDataAdapter adapter;

        protected SqlServer()
        {
            connection = new SqlConnection(Settings.GetConnectionString());
        }

        protected SelectResult Select(SqlCommand selectCommand)
        {
            var result = new SelectResult();
            try
            {
                using (connection)
                {
                    selectCommand.Connection = connection;
                    connection.Open();
                    adapter = new SqlDataAdapter(selectCommand);
                    result.DataTable = new System.Data.DataTable();
                    adapter.Fill(result.DataTable);
                    connection.Close();
                }
                result.Succeeded = true;
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
            }
            return result;
        }

        protected SelectResult Select(string tableName)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = $"Select * FROM {tableName}";
            return Select(command);
        }

        protected InsertResult InsertRecord(SqlCommand insertCommand)
        {
            InsertResult result = new InsertResult();

            try
            {
                using (connection)
                {
                    insertCommand.CommandText += "SET @new_id = SCOPE_IDENTITY();";
                    insertCommand.Parameters.Add("@new_id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    insertCommand.Connection = connection;
                    connection.Open();
                    insertCommand.ExecuteNonQuery();
                    int newId = Convert.ToInt32(insertCommand.Parameters["@new_id"].Value);
                    result.NewId = newId;
                    connection.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        internal CountResult SelectCount(SqlCommand cmd)
        {
            CountResult result = new CountResult();
            try
            {
                using (connection)
                {
                    cmd.Connection = connection;
                    connection.Open();
                    result.Count = (int)cmd.ExecuteScalar();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.AddError(ex.Message);
            }
            return result;
        }
    }
}
