using DealDouble.Entities;
using DealDouble.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class AuctionController : Controller
    {
        public ActionResult Index()
        {
            AuctionsService auctionsService = new AuctionsService();
            var Auction = auctionsService.GetAuction();
            return View(Auction);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Auction auction)
        {
            AuctionsService auctionsService = new AuctionsService();
            auctionsService.SaveAuction(auction);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            AuctionsService auctionsService = new AuctionsService();
            var Auction = auctionsService.GetAuctionByID(ID);
            return View(Auction);
        }
        [HttpPost]
        public ActionResult Edit(Auction auction)
        {
            AuctionsService auctionsService = new AuctionsService();
            auctionsService.UpdateAuction(auction);
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AuctionsService auctionsService = new AuctionsService();
            var Auction = auctionsService.GetAuctionByID(ID);
            return View(Auction);
        }
        [HttpPost]
        public ActionResult Delete(Auction auction)
        {
            AuctionsService auctionsService = new AuctionsService();
            auctionsService.DeleteAuction(auction);
            return RedirectToAction("Index");
        }
    }
}