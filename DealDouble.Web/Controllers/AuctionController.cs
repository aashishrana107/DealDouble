using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace DealDouble.Web.Controllers
{
    public class AuctionController : Controller
    {
        AuctionsService auctionsService = new AuctionsService();
        CategoriesService categoriesService = new CategoriesService();

        public ActionResult Index()
        {
            AuctionsService auctionsService = new AuctionsService();
            AuctionListingViewModel model = new AuctionListingViewModel();
            model.PageTitle = "Auctions";
            model.PageDescription = "Auction Listing Page";
            model.Auctions = auctionsService.GetAuction();
            model.Categories = categoriesService.GetAllCategories();
            
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            else
            {
                return View(model);
            }
            
        }
        public ActionResult Listing(int? categoryID, string searchTerm, int? pageNo)
        {
            AuctionListingViewModel model = new AuctionListingViewModel();
            model.Auctions = auctionsService.SearchAuction(categoryID,searchTerm,pageNo,1);
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateAuctionViewModel model = new CreateAuctionViewModel();
            model.Categories = categoriesService.GetAllCategories();
            return PartialView(model);
        }
        [HttpPost]
        public JsonResult Create(CreateAuctionViewModel model)
        {
            JsonResult result = new JsonResult();
            if (ModelState.IsValid)
            {
                AuctionsService auctionsService = new AuctionsService();
                Auction auction = new Auction();
                auction.Title = model.Title;
                auction.CategoryID = model.CategoryID;
                auction.Description = model.Description;
                auction.ActualAmount = model.ActualAmount;
                auction.StartingTime = model.StartingTime;
                auction.EndingTime = model.EndingTime;


                if (!string.IsNullOrEmpty(model.AuctionPictures))
                {
                    var pictureIDs = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ID => int.Parse(ID)).ToList();
                    auction.AuctionPictures = new List<AuctionPicture>();
                    auction.AuctionPictures.AddRange(pictureIDs.Select(x => new AuctionPicture() { PictureID = x }).ToList());
                }

                //foreach (var picID in pictureIDs)
                //{
                //    var auctionPicture = new AuctionPicture();
                //    auctionPicture.PictureID = picID;
                //    auction.AuctionPictures.Add(auctionPicture);
                //}
                auctionsService.SaveAuction(auction);
                result.Data = new { Success = true };
                //return RedirectToAction("Index");
            }
            else
            {

                result.Data = new { Success = false, Error = "Unable to Save Auctions Please Enter Valid" };
            }
            return result;
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            CreateAuctionViewModel model = new CreateAuctionViewModel();
            AuctionsService auctionsService = new AuctionsService();
            var auction = auctionsService.GetAuctionByID(ID);

            model.ID = auction.ID;
            model.Title = auction.Title;
            model.CategoryID = auction.CategoryID;
            model.Description = auction.Description;
            model.ActualAmount = auction.ActualAmount;
            model.StartingTime = auction.StartingTime;
            model.EndingTime = auction.EndingTime;

            model.Categories = categoriesService.GetAllCategories();
            model.AuctionPicturesList = auction.AuctionPictures;

            
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(CreateAuctionViewModel model)
        {
            
            AuctionsService auctionsService = new AuctionsService();

            Auction auction = new Auction();
            auction.ID = model.ID;
            auction.Title = model.Title;
            auction.CategoryID = model.CategoryID;
            auction.Description = model.Description;
            auction.ActualAmount = model.ActualAmount;
            auction.StartingTime = model.StartingTime;
            auction.EndingTime = model.EndingTime;

            if (!string.IsNullOrEmpty(model.AuctionPictures))
            {
                var pictureIDs = model.AuctionPictures.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ID => int.Parse(ID)).ToList();
                auction.AuctionPictures = new List<AuctionPicture>();
                auction.AuctionPictures.AddRange(pictureIDs.Select(x => new AuctionPicture() {AuctionID = auction.ID ,PictureID = x }).ToList());
            }
            auctionsService.UpdateAuction(auction);
            return RedirectToAction("Index");
            
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
            AuctionDetailViewModel model = new AuctionDetailViewModel();
            AuctionsService auctionsService = new AuctionsService();
            model.Auction = auctionsService.GetAuctionByID(ID);
            model.PageTitle = "Auction Details:";
            model.PageDescription = model.Auction.Description.Substring(0,10);
            return View(model);
        }
    }
}