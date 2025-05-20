using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibTeam03.Business.Entities;
using ClassLibTeam03.Data.Framework;

namespace ClassLibTeam03.Data.Repositories
{
    public static class BoulderRouteRepository
    {
        static BoulderRouteRepository()
        {
            BoulderRouteList = new List<BoulderRoute>();
        }
        public static List<BoulderRoute> BoulderRouteList { get; set; }

        public static InsertResult Add(BoulderRoute route)
        {
            BoulderRouteData boulderRouteData = new BoulderRouteData();
            InsertResult result = boulderRouteData.Insert(route);
            return result;
        }

        public static List<BoulderRoute> GetBoulderRoutesFromDatabase()
        {
            var boulderRouteData = new BoulderRouteData();
            var result = boulderRouteData.SelectBoulderRoutes();

            if (!result.Succeeded)
            {
                throw new Exception("Failed to retrieve routes: " + string.Join(", ", result.Errors));
            }

            return ConvertDataTableToBoulderRoutes(result.DataTable);
        }

        private static List<BoulderRoute> ConvertDataTableToBoulderRoutes(DataTable table)
        {
            var routes = new List<BoulderRoute>();

            foreach (DataRow row in table.Rows)
            {
                routes.Add(new BoulderRoute
                {
                    Id = row.Field<int?>("Id") ?? 0,
                    Name = row.Field<string>("Name"),
                    FontScale = row.Field<string>("FontScale"),
                    Country = row.Field<string>("Country"),
                    ClimbingStyle = row.Field<string>("ClimbingStyle"),
                    Description = row.Field<string>("Description"),
                    DateFirstAscent = row.Field<DateTime>("DateFirstAscent"),
                    CreatedAt = row.Field<DateTime?>("CreatedAt"),
                    UpdatedAt = row.Field< DateTime ?> ("UpdatedAt"),
                    ImageUrl = row.Field<string>("ImageUrl")
                });
            }
            return routes;
        }
    }
}
