using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
            Console.WriteLine("Please enter the bus code");
            string busCode = Console.ReadLine();
            Console.WriteLine(busCode + " Good job.");
            Console.ReadLine();

            //Get input as List<Dict<str str>>
            //List<Arrival> arrivals = new List<Arrival>
            //int count = 0;
            //Foreach (Dict<str str> in List:
            //make new arrival using Arrival(Dict["route"], Dict["time"]...)
            //arrivals.append(new arrival)
            //if count >= 5 break;
            //StopPoint s = new StopPoint(code, arrivals)
        }

        static void Test()
        {
            RestResponse response = RequestApi();
            var model = JsonConvert.DeserializeObject<Arrival>(response.Content);
            Console.WriteLine(model.ToString());
        }

        static RestResponse RequestApi()
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest("StopPoint/940GZZLUASL/Arrivals?stopcode=490008660N&mode=bus", DataFormat.Json);
            return (RestResponse)client.Get(request);
        }
    }
}
