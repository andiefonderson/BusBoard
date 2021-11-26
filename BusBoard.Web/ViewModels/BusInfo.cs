using System.Collections.Generic;

namespace BusBoard.Web.ViewModels
{
    public class BusInfo
    {

        public BusInfo(string postCode)
        {
            PostCode = postCode;
        }

        public BusInfo(string postCode, List<List<string>> busStopsInfo)
        {
            PostCode = postCode;
            BusStopsInfo = busStopsInfo;
        }

        public string PostCode { get; set; }
        public List<List<string>> BusStopsInfo { get; set; }

    }
}