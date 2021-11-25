using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    internal class PostcodeLocationResult
    {
        public int status { get; set; }
        public Dictionary<string, string> result { get; set; }
    }
}
