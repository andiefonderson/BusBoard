using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        //TODO: Check if this is still needed anywhere - 490008660N
        //TODO: Create a function that loops until a valid postcode is given (use an API call to check it's valid), then return the valid postcode.
        //TODO: Add validation for distanceStr
        public const int NUMBER_OF_ARRIVALS = 5;
        public const int NUMBER_OF_STOPPOINTS = 2;
        static void Main(string[] args)
        {
            RequestHandling requestHandler = new RequestHandling();
            //Console.Write("Enter the distance to search in meters (defauly 200)");
            //string distanceStr = Console.ReadLine().Trim();
            //int distance = 200;
            //if (distanceStr != "")
            //{
            //    distance = int.Parse(distanceStr);
            //}
            //RequestHandling requestHandler = new RequestHandling(postcode);
            //List<StopPoint> stopPoints = new List<StopPoint>();
            //for (int i = 0; i < NUMBER_OF_STOPPOINTS; i++)
            //{
            //    //stopPoints.Add(new stoppoint);
            //}
            ////StopPoint stopPoint = requestHandler.GetStopPoint(NUMBER_OF_ARRIVALS);
            //foreach (StopPoint stopPoint in stopPoints)
            //{
            //    Console.WriteLine(stopPoint.ToString());
            //}
            Console.ReadLine();
        }
    }
}
