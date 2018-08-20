using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orders_API.Models;
using System.Net.Http;

namespace Orders_API.Interfaces
{
    interface ISalesService
    {
        List<Sales> GetSales();
    }

    public class SalesService : ISalesService
    {
        List<Sales> ISalesService.GetSales()
        {
            List<Sales> sales = new List<Sales>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57737");

            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Sales").Result;
            if (response.IsSuccessStatusCode)
            {
                var rsales = response.Content.ReadAsAsync<IEnumerable<Sales>>().Result;
                foreach (var x in rsales)
                {
                    sales.Add(x);
                }
            }
            else
            {
                //Handle exception
                return null;
            }
            return sales;
        }
    }
}