﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Gateway.Services.IGatewayService;
using OSG.Models;

namespace Gateway.Services
{
    public class TrainerGatewayService : IGatewayService<Trainer>
    {
        private string HttpLink = "http://localhost:26887/api/";
        private string ControllerName = "trainer/";
        public Trainer Add(Trainer model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.PostAsJsonAsync(HttpLink + ControllerName, model).Result;
                return response.Content.ReadAsAsync<Trainer>().Result;
            }
        }

        public bool Delete(Trainer model)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response =
                    client.DeleteAsync(HttpLink + ControllerName + model.Id).Result;
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
