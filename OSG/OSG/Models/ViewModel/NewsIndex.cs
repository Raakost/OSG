using Gateway.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OSG.Models.ViewModel
{
    public class NewsIndex
    {
        public List<News> newsList { get; set; }
        public int? Id { get; set; }
    }
}