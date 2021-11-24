using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
  class Program
  {
    static void Main(string[] args)
    {
            Console.WriteLine("Please enter the bus code");
            string busCode = Console.ReadLine();
            Console.WriteLine(busCode + " Good job.");
            Console.ReadLine();
    }

    static void RequestApi()
        {
            var client = new RestClient("https://api.tfl.gov.uk/StopPoint/940GZZLUASL/Arrivals?stopcode=490008660N&mode=bus");
            var request = new RestRequest("statuses/home_timeline.json", DataFormat.Json);

            var response = client.Get(request);
        }
  }
}
