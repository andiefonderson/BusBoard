using BusBoard.Web;
using System;
using System.Collections.Generic;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        public const int NUMBER_OF_ARRIVALS = 5;
        public const int NUMBER_OF_STOPPOINTS = 2;
        static void Main(string[] args)
        {
            // Test postcode: NW5 1TL

            Console.WriteLine("Enter a postcode: ");
            RequestHandling requestHandler = new RequestHandling(Console.ReadLine());
            List<StopPoint> stopPointsList = requestHandler.GetStopPoints(NUMBER_OF_ARRIVALS, NUMBER_OF_STOPPOINTS);
            foreach(StopPoint stopPoint in stopPointsList)
            {
                Console.WriteLine(stopPoint.ToString());
            }
            Console.ReadLine();
        }
    }
}
