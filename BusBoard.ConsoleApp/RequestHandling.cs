using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard.ConsoleApp
{
    class RequestHandling
    {
        private RestClient tflClient;
        private RestClient postcodeClient;

        private string lon;
        private string lat;

        //tflArrivalsRequest = new RestRequest($"StopPoint/{stopcode}/Arrivals?mode=bus", DataFormat.Json)
        //TODO: Create RestRequest using the following string "StopPoint?lat=51.49454&lon=-0.100601&stopTypes=NaptanPublicBusCoachTram&radius=200&modes=bus"
        //TODO: turn postcode into stop code
        //TODO: Create an object to get the FIRST stoppoint from the JSON response from above (I think they're sorted by distance already?)
        //TODO: Add a postcodeClient, rename client to tlfClient. Rename current RestRequests to reflect this change in the program
        public RequestHandling()
        {
            tflClient = new RestClient("https://api.tfl.gov.uk/");
            postcodeClient = new RestClient("http://api.postcodes.io/");
            string postcode = GetValidPostcode();
            GetLocation(postcode);
            //Generate stopcode
        }

        //TODO: Take user input here after debugging
        public string GetValidPostcode()
        {
            // NW5 1TL
            string postcode;
            bool valid;
            RestRequest postcodeValidateRequest;
            do
            {
                // Console.WriteLine("Enter a postcode: ");
                // postcode = Console.ReadLine();
                postcode = "NW5 1TL";
                postcodeValidateRequest = new RestRequest($"postcodes/{postcode}/validate");
                var postcodeResponse = postcodeClient.Get<List<Dictionary<string, string>>>(postcodeValidateRequest).Data;
                valid = bool.Parse(postcodeResponse[0]["result"]);
            } while (!valid);
            return postcode;
        }

        private void GetLocation(string postcode)
        {
            RestRequest postcodeLonLatRequest = new RestRequest($"postcodes/{postcode}");
            var postcodeLocationResponse = postcodeClient.Get<PostcodeLocationResult>(postcodeLonLatRequest).Data;
            lon = postcodeLocationResponse.result["longitude"];
            lat = postcodeLocationResponse.result["latitude"];
        }

        public List<Arrival> GetArrivals(string stopcode)
        {
            RestRequest tflArrivalsRequest = new RestRequest($"StopPoint/{stopcode}/Arrivals?mode=bus", DataFormat.Json);
            List<Arrival> arrivals = tflClient.Get<List<Arrival>>(tflArrivalsRequest).Data;
            arrivals.Sort();
            return arrivals;
        }

        private StopPoint GetStopPoint(int numberOfArrivals, string stopcode)
        {
            List<Arrival> allArrivals = GetArrivals(stopcode);
            List<Arrival> stoppointArrivals = new List<Arrival>();
            for (int i = 0; i < numberOfArrivals; i++)
            {
                stoppointArrivals.Add(allArrivals[i]);
            }
            return new StopPoint(stopcode, stoppointArrivals);
        }

        public List<StopPoint> GetStopPoints(int numberOfArrivals, int numberOfStoppoints)
        {
            //at=51.49454&lon=-0.100601
            List<StopPoint> stoppoints = new List<StopPoint>();
            RestRequest tflStoppointsRequest = new RestRequest($"StopPoint?lat={lat}&lon={lon}&stopTypes=NaptanPublicBusCoachTram&radius=200&modes=bus");
            var response = tflClient.Get<StoppointWrapper>(tflStoppointsRequest);
            //Get stoppoints from API
            //Use num of them to full the above list
            for (int i = 0;i < numberOfStoppoints; i++)
            {

            }


            return stoppoints;
        }

        //RequestHandler.GetStopPoints is called. Pass in number of stoppoints AND number of arrivals for each stoppoint AND postcode
        //API call to TFL to get codes for nearest numOfStoppoints stopcodes.
        //ForEach this calls private method GetStopPoint, which takes number of arrivals and the stopcode
        //The private method makes the API request to tfl to get arrivals
        //returns List<stoppoint>
    }
}
