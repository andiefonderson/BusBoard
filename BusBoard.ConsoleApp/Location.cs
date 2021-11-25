using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    struct Location
    {
        //TODO: Rename these to match the API response so this can be used in .Get<list<Location>>().Data;
        public string longitude { get; set; }
        public string latitude { get; set; }
    }
}
