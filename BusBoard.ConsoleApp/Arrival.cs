using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BusBoard.ConsoleApp
{
    class Arrival
    {
        //routes, destinations, and the time until they arrive in minutes.
        public string lineName { get; set; }              //lineName
        public string destinationName { get; set; }          //destinationName
        public int timeToStation { get; set; }        //timeToStation (seconds?)

        //Depends on how class is initialised in main
        //public Arrival(string lineName, string destinationName, int timeToStation)
        //{
        //    this.lineName = lineName;
        //    this.destinationName = destinationName;
        //    this.timeToStation = TimeSpan.FromSeconds(timeToStation);
        //}

        public override string ToString()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(timeToStation);
            return $"This {lineName} bus is heading for {destinationName}. It will arrive in {timeSpan.TotalMinutes:0.00} minutes.";
        }
    }
}
