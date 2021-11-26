using System.Collections.Generic;
using System.Text;

namespace BusBoard.Api
{
    struct StopPoint
    {
        public string code { get; }
        public string busStopName { get; }
        private List<Arrival> arrivals { get; }

        public StopPoint(string code, string busStopName, List<Arrival> arrivals)
        {
            this.code = code;
            this.busStopName = busStopName;
            this.arrivals = arrivals;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Bus Stop: {busStopName}\n");
            foreach (Arrival arrival in arrivals)
            {
                stringBuilder.Append(arrival.ToString() + "\n");
            }
            return stringBuilder.ToString();
        }
    }
}
