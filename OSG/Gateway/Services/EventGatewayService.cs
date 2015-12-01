using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gateway.Services.IGatewayService;
using OSG.Models;
using System.Net.Http;

namespace Gateway.Services
{
    public class EventGatewayService : IGatewayService<Event>
    {
        private string HttpLink = "http://localhost:26887/api/";
        private string ControllerName = "event/";
        public Event Add(Event model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(HttpLink + ControllerName, model).Result;
                return response.Content.ReadAsAsync<Event>().Result;
            }
        }

        public bool Delete(Event model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync(HttpLink + ControllerName + model.Id).Result;
                return response.Content.ReadAsAsync<Boolean>().Result;
            }
        }

        public IEnumerable<Event> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(HttpLink + ControllerName).Result;
                return response.Content.ReadAsAsync<IEnumerable<Event>>().Result;
            }
        }

        public Event ReadById(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(HttpLink + ControllerName + id).Result;
                return response.Content.ReadAsAsync<Event>().Result;
            }
        }

        public Event Update(Event model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync(HttpLink + ControllerName + model.Id, model).Result;
                return response.Content.ReadAsAsync<Event>().Result;
            }
        }
    }
}
