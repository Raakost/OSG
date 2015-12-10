using System;
using System.Collections.Generic;
using Gateway.Services.IGatewayService;
using System.Net.Http;
using Gateway.DomainModel;

namespace Gateway.Services
{
    public class NewsGatewayService : IGatewayService<News>
    {
        private string HttpLink = "http://localhost:26887/api/";
        private string ControllerName = "news/";
        public News Create(News model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(HttpLink + ControllerName, model).Result;
                return response.Content.ReadAsAsync<News>().Result;
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

        public IEnumerable<News> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(HttpLink + ControllerName).Result;
                return response.Content.ReadAsAsync<IEnumerable<News>>().Result;
            }
        }

        public News ReadById(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(HttpLink + ControllerName + id).Result;
                return response.Content.ReadAsAsync<News>().Result;
            }
        }

        public News Update(News model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync(HttpLink + ControllerName + model.Id, model).Result;
                return response.Content.ReadAsAsync<News>().Result;
            }
        }
    }
}
