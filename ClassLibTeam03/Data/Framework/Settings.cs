using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibTeam03.Data.Framework
{
    static class Settings
    {
        public static string GetConnectionString()
        {
            string connectionString = @"Data Source = 5CD421FF2K\SQLEXPRESS; Initial Catalog = DB_Personal_MAUI_Ignace_Vanmechelen; Integrated Security = True; Trust Server Certificate = True";
            return connectionString;
        }
    }
}
