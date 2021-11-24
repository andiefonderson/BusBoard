using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        // 490008660N
        static void Main(string[] args)
        {            
            Console.WriteLine("Please enter the bus code");
            RequestApi(Console.ReadLine());
            Console.ReadLine();            
        }

        static void RequestApi(string busCode)
        {
            var client = new RestClient("https://api.tfl.gov.uk/");
            var request = new RestRequest($"StopPoint/{busCode}/Arrivals?mode=bus", DataFormat.Json);
           // var response = client.Get<List<Dictionary<string,string>>>(request).Data;
            var response = client.Get<List<Arrival>>(request);
            var data = response.Data;
            Console.WriteLine(GetApiData(data, busCode).ToString());
        }

        static StopPoint GetApiData(List<Arrival> response, string busCode)
        {
            List<Arrival> arrivals = new List<Arrival>();
            int count = 0;
            foreach (var item in response)
            {
                arrivals.Add(item);
                if(count >= 5)
                {
                    break;
                }
                else { count++; }                
            }
            return new StopPoint(busCode, arrivals);
        }
    }
}
