using Gateway.Services.IGatewayService;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Gateway.DomainModel;

namespace Gateway.Services
{
    public class CommentGatewayService : IGatewayService<Comment>
    {
        private string HttpLink = "http://localhost:26887/api/";
        private string ControllerName = "comment/";

        public Comment Create(Comment model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(HttpLink + ControllerName, model).Result;
                return response.Content.ReadAsAsync<Comment>().Result;
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

        public IEnumerable<Comment> ReadAll()
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(HttpLink + ControllerName).Result;
                return response.Content.ReadAsAsync<IEnumerable<Comment>>().Result;
            }
        }

        public Comment ReadById(int id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.GetAsync(HttpLink + ControllerName + id).Result;
                return response.Content.ReadAsAsync<Comment>().Result;
            }
        }

        public Comment Update(Comment model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PutAsJsonAsync(HttpLink + ControllerName + model.Id, model).Result;
                return response.Content.ReadAsAsync<Comment>().Result;
            }
        }
    }
}
