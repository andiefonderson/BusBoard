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
            RequestHandling requestHandler = new RequestHandling();
            List<StopPoint> stopPointsList = requestHandler.GetStopPoints(NUMBER_OF_ARRIVALS, NUMBER_OF_STOPPOINTS);
            foreach(StopPoint stopPoint in stopPointsList)
            {
                Console.WriteLine(stopPoint.ToString());
            }
            Console.ReadLine();
        }
    }
}
