using ClassLibTeam03.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MauiAppTeam03
{
    public static class RestService
    {
        private static readonly HttpClient httpClient = new();
        private const string REST_URL = "https://slrd2bgq-51035.euw.devtunnels.ms/api/BoulderRoutes/all";
        public static async Task<List<BoulderRoute>> GetBoulderRoutesAsync()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(REST_URL);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    var routes = JsonConvert.DeserializeObject<List<BoulderRoute>>(json);

                    if (routes != null)
                    {
                        return routes;
                    } 
                    else
                    {
                        return new List<BoulderRoute>();
                    }
                }
                else
                {
                    Console.WriteLine("Could not execute Web API call");
                    return new List<BoulderRoute>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(new { message = ex.Message });
                return new List<BoulderRoute>();
            }
        }
    }
}
