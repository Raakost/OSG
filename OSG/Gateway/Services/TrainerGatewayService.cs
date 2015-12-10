using System;
using System.Collections.Generic;
using System.Net.Http;
using Gateway.DomainModel;
using Gateway.Services.IGatewayService;

namespace Gateway.Services
{
    public class TrainerGatewayService : IGatewayService<Trainer>
    {
        private string HttpLink = "http://localhost:26887/api/";
        private string ControllerName = "trainer/";
        public Trainer Create(Trainer model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(HttpLink + ControllerName, model).Result;
                return response.Content.ReadAsAsync<Trainer>().Result;
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

        public IEnumerable<Trainer> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(HttpLink + ControllerName).Result;
                return response.Content.ReadAsAsync<IEnumerable<Trainer>>().Result;
            }
        }

        public Trainer ReadById(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(HttpLink + ControllerName + id).Result;
                return response.Content.ReadAsAsync<Trainer>().Result;
            }
        }

        public Trainer Update(Trainer model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync(HttpLink + ControllerName + model.Id, model).Result;
                return response.Content.ReadAsAsync<Trainer>().Result;
            }
        }
    }
}
