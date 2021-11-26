namespace BusBoard.Web.ViewModels
{
  public class BusInfo
  {
    public BusInfo(string postCode, string busStopName, string arrivalsList)
    {
      PostCode = postCode;
      BusStopName = busStopName;
      ArrivalsList = arrivalsList;
    }

    public string PostCode { get; set; }
    public string BusStopName { get; set; }
    public string ArrivalsList { get; set; }

  }
}