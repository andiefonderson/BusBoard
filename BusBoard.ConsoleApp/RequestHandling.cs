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
        private RestRequest tflArrivalsRequest;
        private Location location;

        private string lon;
        private string lat;

        //TODO: Create RestRequest using the following string "StopPoint?lat=51.49454&lon=-0.100601&stopTypes=NaptanPublicBusCoachTram&radius=200&modes=bus"
        //TODO: turn postcode into stop code
        //TODO: Create an object to get the FIRST stoppoint from the JSON response from above (I think they're sorted by distance already?)
        //TODO: Add a postcodeClient, rename client to tlfClient. Rename current RestRequests to reflect this change in the program
        public RequestHandling()
        {
            tflClient = new RestClient("https://api.tfl.gov.uk/");
            postcodeClient = new RestClient("http://api.postcodes.io/");
            string postcode = GetValidPostcode();
            Location location = GetLocation(postcode);
            //Generate stopcode
            
            //Get lon lat for this request
            //postcodeRequest = new RestRequest($"StopPoint?lat={lat}&lon={lon}&stopTypes={?NaptanBusWayPoint}&radius=10000&modes=bus", DataFormat.Json);
            //tflArrivalsRequest = new RestRequest($"StopPoint/{stopcode}/Arrivals?mode=bus", DataFormat.Json);
        }

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

        private Location GetLocation(string postcode)
        {
            RestRequest postcodeLonLatRequest = new RestRequest($"postcodes/{postcode}");
            var postcodeLocationResponse = postcodeClient.Get<PostcodeLocationResult>(postcodeLonLatRequest);

            throw new NotImplementedException();
        }

        public List<Arrival> GetArrivals()
        {
            List<Arrival> arrivals = tflClient.Get<List<Arrival>>(tflArrivalsRequest).Data;
            arrivals.Sort();
            return arrivals;
        }

        private StopPoint GetStopPoint(int numberOfArrivals, string stopcode)
        {
            List<Arrival> stoppointArrivals = new List<Arrival>();
            List<Arrival> allArrivals = GetArrivals();
            for (int i = 0; i < numberOfArrivals; i++)
            {
                stoppointArrivals.Add(allArrivals[i]);
            }
            return new StopPoint(stopcode, stoppointArrivals);
        }

        //Create Request object - pass in postcode
        //Conver postcode to long and lat (as strings themselves) - these can be private properties
        //This is done in a method, which calls the postcode API
        //Bin original postcode string
        //RequestHandler.GetStopPoints is called. Pass in number of stoppoints AND number of arrivals for each stoppoint AND postcode
        //API call to TFL to get codes for nearest numOfStoppoints stopcodes.
        //ForEach this calls private method GetStopPoint, which takes number of arrivals and the stopcode
        //The private method makes the API request to tfl to get arrivals
        //returns List<stoppoint>
    }
}
