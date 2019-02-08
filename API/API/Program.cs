using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace API
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://api.nobelprize.org/v1/laureate.json");
            var request = new RestRequest("/", Method.GET);
            IRestResponse response = client.Execute(request);
            String content = response.Content;
            Winners winners = JsonConvert.DeserializeObject<Winners>(content);
        }

        public class Prize
        {
            public string year { get; set; }
            public string category { get; set; }
            public string share { get; set; }
            public string motivation { get; set; }
            public List<object> affiliations { get; set; }
            public string overallMotivation { get; set; }
        }

        public class Laureate
        {
            public string id { get; set; }
            public string firstname { get; set; }
            public string surname { get; set; }
            public string born { get; set; }
            public string died { get; set; }
            public string bornCountry { get; set; }
            public string bornCountryCode { get; set; }
            public string bornCity { get; set; }
            public string diedCountry { get; set; }
            public string diedCountryCode { get; set; }
            public string diedCity { get; set; }
            public string gender { get; set; }
            public List<Prize> prizes { get; set; }
        }

        public class Winners
        {
            public List<Laureate> laureates { get; set; }
        }
    }
}
