using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BusBoard.ConsoleApp
{
    class Arrival : IComparable
    {
        public string lineName { get; set; }
        public string destinationName { get; set; }
        public int timeToStation { get; set; }


        public override string ToString()
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(timeToStation);
            return $"This {lineName} bus is heading for {destinationName}. It will arrive in {timeSpan.Minutes} minutes {timeSpan.Seconds} second.";
        }

        public int CompareTo(object obj)
        {
            Arrival comparator = (Arrival) obj;
            return timeToStation.CompareTo(comparator.timeToStation);
        }

    }
}
