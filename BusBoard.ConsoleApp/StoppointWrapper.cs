using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    internal class StoppointWrapper
    {
        public string type { get; set; }
        public string[] centrePoint { get; set; }
        public List<Dictionary<string, string>> stopPoints { get; set; }
    }
}
