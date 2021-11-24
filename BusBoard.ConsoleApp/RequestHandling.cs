using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class RequestHandling
    {
        private RestClient client { get; }
        private RestRequest request { get; }
        private RestResponse response { get; }

        public RequestHandling(string code)
        {
            client = new RestClient("https://api.tfl.gov.uk/").UseJson();
            request = new RestRequest($"StopPoint/940GZZLUASL/Arrivals?stopcode={code}&mode=bus", DataFormat.Json);
            response = (RestResponse) client.Get(request);
        }

        private List<Dictionary<string, string>> ParseInput(RestResponse restResponse)
        {
            var model = JsonConvert.DeserializeObject<Arrival>(response.Content);
            model.ToString();
            return new List<Dictionary<string, string>>();
        }
    }
}
