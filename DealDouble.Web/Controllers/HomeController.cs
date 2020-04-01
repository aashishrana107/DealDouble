using DealDouble.Services;
using DealDouble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class HomeController : Controller
    {
        AuctionsService auctionsService = new AuctionsService();
        public ActionResult Index()
        {
            AuctionViewModels vmodel = new AuctionViewModels();
            vmodel.AllAuction = auctionsService.GetAuction();
            vmodel.PromotedAuction = auctionsService.GetpromotedAuctions();

            
            ViewBag.Title = "Home Page";
            ViewBag.PublishedOn = DateTime.Now;
            
            return View(vmodel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}