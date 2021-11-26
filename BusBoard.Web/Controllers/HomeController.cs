using System;
using System.Collections.Generic;
using System.Web.Mvc;
using BusBoard.Api;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;

namespace BusBoard.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BusInfo(PostcodeSelection selection)
        {
            // Add some properties to the BusInfo view model with the data you want to render on the page. - DONE...?
            // Write code here to populate the view model with info from the APIs.
            // Then modify the view (in Views/Home/BusInfo.cshtml) to render upcoming buses.

            var info = new BusInfo(selection.Postcode, APICall(selection.Postcode));

            return View(info);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Information about this site";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us!";

            return View();
        }

        public List<List<string>> APICall(string selection)
        {
            RequestHandling requestHandler = new RequestHandling(selection.ToString());
            List<StopPoint> stopPointsList = requestHandler.GetStopPoints(5, 2);
            List<List<string>> busArrivalsList = new List<List<string>>();
            
            foreach (StopPoint stopPoint in stopPointsList)
            {
                busArrivalsList.Add(stopPoint.GetInfo());
            }

            return busArrivalsList;
        }
    }
}