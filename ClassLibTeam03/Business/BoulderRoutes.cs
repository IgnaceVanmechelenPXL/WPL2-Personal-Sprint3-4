using ClassLibTeam03.Data.Repositories;
using ClassLibTeam03.Business.Entities;
using ClassLibTeam03.Data.Framework;
using ClassLibTeam03.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using System.ComponentModel;

namespace ClassLibTeam03.Business
{
    public static class BoulderRoutes
    {
        public static IEnumerable<BoulderRoute> List()
        {
            return BoulderRouteRepository.BoulderRouteList;
        }

        public static SelectResult GetBoulderRoutes()
        {
            BoulderRouteData boulderRouteData = new BoulderRouteData();
            BoulderRouteData.ConnectionString = Settings.GetConnectionString();
            SelectResult result = boulderRouteData.Select();
            return result;
        }

        public static void Add(BoulderRoute route)
        {
            BoulderRouteRepository.Add(route);
        }
    }
}
