using System;
using System.Collections.Generic;
using RestSharp;

namespace BusBoard.Api
{
    public class RequestHandling
    {
        private RestClient tflClient;
        private RestClient postcodeClient;

        private string lon;
        private string lat;

        public RequestHandling(string postcodeInput)
        {
            tflClient = new RestClient("https://api.tfl.gov.uk/");
            postcodeClient = new RestClient("http://api.postcodes.io/");
            if (GetValidPostcode(postcodeInput))
            {
                GetLocation(postcodeInput);
            }            
        }

        public bool GetValidPostcode(string postcode)
        {
            
            RestRequest postcodeValidateRequest;
            postcodeValidateRequest = new RestRequest($"postcodes/{postcode}/validate");
            var postcodeResponse = postcodeClient.Get<List<Dictionary<string, string>>>(postcodeValidateRequest).Data;
            return bool.Parse(postcodeResponse[0]["result"]);
        }

        private void GetLocation(string postcode)
        {
            RestRequest postcodeLonLatRequest = new RestRequest($"postcodes/{postcode}");
            var postcodeLocationResponse = postcodeClient.Get<PostcodeLocationResult>(postcodeLonLatRequest).Data;
            lon = postcodeLocationResponse.result["longitude"];
            lat = postcodeLocationResponse.result["latitude"];
        }

        public List<StopPoint> GetStopPoints(int numberOfArrivals, int numberOfStoppoints)
        {
            List<StopPoint> stoppoints = new List<StopPoint>();
            RestRequest tflStoppointsRequest = new RestRequest($"StopPoint?lat={lat}&lon={lon}&stopTypes=NaptanPublicBusCoachTram&radius=200&modes=bus");
            var response = tflClient.Get<StoppointWrapper>(tflStoppointsRequest).Data;
            for (int i = 0; i < numberOfStoppoints; i++)
            {
                string stopCode = response.stopPoints[i].naptanId.ToString();
                string stopName = response.stopPoints[i].commonName.ToString();
                stoppoints.Add(GetStopPoint(5, stopName, stopCode));
            }
            return stoppoints;
        }

        private List<Arrival> GetArrivals(string stopcode)
        {
            RestRequest tflArrivalsRequest = new RestRequest($"StopPoint/{stopcode}/Arrivals?mode=bus", DataFormat.Json);
            List<Arrival> arrivals = tflClient.Get<List<Arrival>>(tflArrivalsRequest).Data;
            arrivals.Sort();
            return arrivals;
        }

        private StopPoint GetStopPoint(int numberOfArrivals, string stopName, string stopcode)
        {
            List<Arrival> allArrivals = GetArrivals(stopcode);
            List<Arrival> stoppointArrivals = new List<Arrival>();
            for (int i = 0; i < numberOfArrivals; i++)
            {
                stoppointArrivals.Add(allArrivals[i]);
            }
            return new StopPoint(stopcode, stopName, stoppointArrivals);
        }
    }
}
