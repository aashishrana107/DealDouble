using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class AuctionController : Controller
    {
        AuctionsService auctionsService = new AuctionsService();

        public ActionResult Index()
        {
            AuctionsService auctionsService = new AuctionsService();
            AuctionListingViewModel model = new AuctionListingViewModel();
            model.PageTitle = "Auctions";
            model.PageDescription = "Auction Listing Page";
            model.Auctions = auctionsService.GetAuction();
            if(Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            else
            {
                return View(model);
            }
            
        }
        public ActionResult Listing()
        {
            AuctionListingViewModel model = new AuctionListingViewModel();
            model.Auctions = auctionsService.GetAuction();
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(CreateAuctionViewModel model)
        {
            AuctionsService auctionsService = new AuctionsService();
            Auction auction = new Auction();
            auction.Title = model.Title;
            auction.Description = model.Description;
            auction.ActualAmount = model.ActualAmount;
            auction.StartingTime = model.StartingTime;
            auction.EndingTime = model.EndingTime;

            var pictureIDs = model.AuctionPictures.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(ID=>int.Parse(ID)).ToList();
            auction.AuctionPictures = new List<AuctionPicture>();
            auction.AuctionPictures.AddRange(pictureIDs.Select(x => new AuctionPicture() { PictureID = x }).ToList());
            //foreach (var picID in pictureIDs)
            //{
            //    var auctionPicture = new AuctionPicture();
            //    auctionPicture.PictureID = picID;
            //    auction.AuctionPictures.Add(auctionPicture);
            //}
            auctionsService.SaveAuction(auction);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            AuctionsService auctionsService = new AuctionsService();
            var Auction = auctionsService.GetAuctionByID(ID);
            return PartialView(Auction);
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
        [HttpGet]
        public ActionResult Details(int ID)
        {
            AuctionsService auctionsService = new AuctionsService();
            var Auction = auctionsService.GetAuctionByID(ID);
            return View(Auction);
        }
    }
}