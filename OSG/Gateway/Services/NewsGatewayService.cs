using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool Delete(News model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync(HttpLink + ControllerName + model.Id).Result;
                return response.Content.ReadAsAsync<Boolean>().Result;
            }
        }

        public IEnumerable<News> ReadAll(int amound = 10)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(HttpLink + ControllerName + "/GetByAmound/" + amound).Result;
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
