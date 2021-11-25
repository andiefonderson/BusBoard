using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBoard.ConsoleApp
{
    struct  Location
    {
        //TODO: Rename these to match the API response so this can be used in .Get<list<Location>>().Data;
        public string lon { get; set; }
        public string lat { get; set; }

        public Location(string lon, string lat)
        {
            this.lon = lon;
            this.lat = lat;
        }
    }
}
