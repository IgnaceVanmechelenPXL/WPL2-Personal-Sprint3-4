using ClassLibTeam03.Data.Framework;
using ClassLibTeam03.Business.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam03.Data
{
    internal class BoulderRouteData : SqlServer
    {
        public string TableName { get; set; }
        public static string ConnectionString { get; set; }

        public BoulderRouteData() : base()
        {
            TableName = "BoulderRoutes";
        }

        public SelectResult Select()
        {
            return base.SelectTable(TableName);
        }

        public SelectResult SelectBoulderRoutes()
        {
            string query = $"SELECT * FROM {TableName}";
            return Select(query);
        }

        public InsertResult Insert(BoulderRoute route)
        {
            var result = new InsertResult();
            try
            {
                StringBuilder insertQuery = new StringBuilder();
                insertQuery.Append($"INSERT INTO {TableName} ");
                insertQuery.Append($"(Name, FontScale, Country, ClimbingStyle, Description, DateFirstAscent, CreatedAt, UpdatedAt) VALUES ");
                insertQuery.Append($"(@Name, @FontScale, @Country, @ClimbingStyle, @Description, @DateFirstAscent, @CreatedAt, @UpdatedAt);");

                using (SqlCommand insertCommand = new SqlCommand(insertQuery.ToString()))
                {
                    insertCommand.Parameters.Add("@Name", SqlDbType.VarChar).Value = route.Name;
                    insertCommand.Parameters.Add("@FontScale", SqlDbType.VarChar).Value = route.FontScale;
                    insertCommand.Parameters.Add("@Country", SqlDbType.VarChar).Value = route.Country;
                    insertCommand.Parameters.Add("@ClimbingStyle", SqlDbType.VarChar).Value = route.ClimbingStyle;
                    insertCommand.Parameters.Add("@Description", SqlDbType.VarChar).Value = route.Description;
                    insertCommand.Parameters.Add("@DateFirstAscent", SqlDbType.DateTime).Value = route.DateFirstAscent;
                    insertCommand.Parameters.Add("@CreatedAt", SqlDbType.VarChar).Value = route.CreatedAt;
                    insertCommand.Parameters.Add("@UpdatedAt", SqlDbType.VarChar).Value = route.UpdatedAt;


                    result = InsertRecord(insertCommand);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fout in Insert: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
                result.AddError($"{ex.Message}");
            }
            return result;
        }
    }
}
