using System;
using System.Collections.Generic;
using System.Linq;
using Gateway.Services.IGatewayService;
using System.Net.Http;
using Gateway.DomainModel;

namespace Gateway.Services
{
    public class EventGatewayService : IGatewayService<Event>
    {
        private string HttpLink = "http://localhost:26887/api/";
        private string ControllerName = "event/";
        public Event Create(Event model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(HttpLink + ControllerName, model).Result;
                return response.Content.ReadAsAsync<Event>().Result;
            }
        }

        public bool Delete(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync(HttpLink + ControllerName + id).Result;
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

        public List<Event> ReadByMonth(DateTime month)
        {
            using (var client = new HttpClient())
            {
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response =
                    client.GetAsync(HttpLink + ControllerName + "?month=" + month.Year+"-"+month.Month+"-"+month.Day).Result;
                return response.Content.ReadAsAsync<IEnumerable<Event>>().Result.ToList();
            }
        }
    }
}
