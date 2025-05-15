using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam03.Data.Framework
{
    public abstract class SqlServer
    {
        SqlConnection connection;
        SqlDataAdapter adapter;

        public SqlServer()
        {
            string connStr = Settings.GetConnectionString();

            Console.WriteLine($"Connection string from Settings: {connStr}");

            if (string.IsNullOrWhiteSpace(connStr))
            {
                throw new InvalidOperationException("Connection string is empty.");
            }

            connection = new SqlConnection(connStr);
        }
        protected SelectResult Select(string query, SqlParameter[] parameters = null)
        {
            var result = new SelectResult();

            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        result.DataTable = new DataTable();
                        adapter.Fill(result.DataTable);

                        if (result.DataTable.Rows.Count > 0)
                        {
                            result.Succeeded = true;
                        }
                        else
                        {
                            result.Succeeded = false;
                            result.AddError("No result found");
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                result.AddError(ex.Message);
                result.Succeeded = false;
            }
            return result;
        }

        protected SelectResult SelectTable(string tableName)
        {
            string selectQuery = $"SELECT * FROM {tableName}";
            return Select(selectQuery);
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
                    result.Succeeded = true;
                }
            }
            catch (Exception ex)
            {
                result.Succeeded = false;
                result.AddError(ex.Message);
            }
            return result;
        }

        protected UpdateResult UpdateRecord(SqlCommand updateCommand)
        {
            UpdateResult result = new UpdateResult();
            try
            {
                using (connection)
                {
                    updateCommand.Connection = connection;
                    connection.Open();
                    result.AffectedRows = updateCommand.ExecuteNonQuery();
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
        public void RenewConnection()
        {
            connection = new SqlConnection(Settings.GetConnectionString());
        }
    }
}
