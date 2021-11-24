using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class RequestHandling
    {
        private RestClient client;
        private RestRequest arrivalsRequest;
        private RestRequest postcodeRequest;
        private string stopcode;

        //TODO: turn postcode into stop code
        public RequestHandling(string code)
        {
            client = new RestClient("https://api.tfl.gov.uk/");
            
            //Get lon lat for this request
            //postcodeRequest = new RestRequest($"StopPoint?lat={lat}&lon={lon}&stopTypes={?NaptanBusWayPoint}&radius=10000&modes=bus", DataFormat.Json);
            //this.stopcode = postcode result
            this.stopcode = code;
            arrivalsRequest = new RestRequest($"StopPoint/{stopcode}/Arrivals?mode=bus", DataFormat.Json);
        }

        private string GetStopCode(string postcode)
        {
            //
            return "";
        }

        public List<Arrival> GetArrivals()
        {
            List<Arrival> arrivals = client.Get<List<Arrival>>(arrivalsRequest).Data;
            arrivals.Sort();
            return arrivals;
        }

        public StopPoint GetStopPoint(int numberOfArrivals)
        {
            List<Arrival> stoppointArrivals = new List<Arrival>();
            List<Arrival> allArrivals = GetArrivals();
            for (int i = 0; i < numberOfArrivals; i++)
            {
                stoppointArrivals.Add(allArrivals[i]);
            }
            return new StopPoint(stopcode, stoppointArrivals);
        }

        public void ParsePostcode()
        {
            //Parse postcode, get lat and lon
        }
    }
}
