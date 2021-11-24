using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusBoard.ConsoleApp
{
    class Program
    {
        // 490008660N
        static void Main(string[] args)
        {
            Console.Write("Please enter the bus code: ");
            string stopcode = Console.ReadLine();
            Console.Write("Enter the number of stops: ");
            int numberOfArrivals = int.Parse(Console.ReadLine());
            RequestHandling requestHandler = new RequestHandling(stopcode);
            StopPoint stopPoint = requestHandler.GetStopPoint(5);
            Console.WriteLine(stopPoint.ToString());
            Console.ReadLine();
        }

        //static StopPoint GetApiData(List<Arrival> response, string busCode)
        //{
        //    List<Arrival> arrivals = new List<Arrival>();
        //    int count = 0;
        //    foreach (var item in response)
        //    {
        //        arrivals.Add(item);
        //        if(count >= 5)
        //        {
        //            break;
        //        }
        //        else { count++; }                
        //    }
        //    return new StopPoint(busCode, arrivals);
        //}
    }
}
