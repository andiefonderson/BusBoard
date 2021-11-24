using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BusBoard.ConsoleApp
{
    class Arrival
    {
        //routes, destinations, and the time until they arrive in minutes.
        private string route;               //lineName
        private string destination;         //destinationName
        private TimeSpan timeToArrive;      //timeToStation (seconds?)

        //Depends on how class is initialised in main
        public Arrival(string route, string destination, int timeToArrive)
        {
            this.route = route;
            this.destination = destination;
            this.timeToArrive = TimeSpan.FromSeconds(timeToArrive);
        }

        public Arrival(string route, string destination, TimeSpan timeToArrive)
        {
            this.route = route;
            this.destination = destination;
            this.timeToArrive = timeToArrive;
        }

        public override string ToString()
        {
            return $"This {route} bus is heading for {destination}. It will arrive in {timeToArrive.TotalMinutes.ToString()}";
        }
    }
}
