using ClassLibTeam03.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppTeam03
{
    public static class RestService
    {
        private static readonly HttpClient httpClient = new();

        public static async Task<List<BoulderRoute>> GetBoulderRoutesAsync()
        {
            var apiUrl = "https://slrd2bgq-51035.euw.devtunnels.ms/api/BoulderRoutes/all";
            return await httpClient.GetFromJsonAsync<List<BoulderRoute>>(apiUrl);
        }
    }
}
