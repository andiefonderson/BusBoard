using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    struct StopPoint
    {
        public string code { get; }
        private List<Arrival> arrivals { get; }

        public StopPoint(string code, List<Arrival> arrivals)
        {
            this.code = code;
            this.arrivals = arrivals;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Arrival arrival in arrivals)
            {
                stringBuilder.Append(arrival.ToString() + "\n");
            }
            return stringBuilder.ToString();
        }
    }
}
