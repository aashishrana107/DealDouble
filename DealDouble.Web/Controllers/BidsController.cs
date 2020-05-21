using DealDouble.Entities;
using DealDouble.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    [Authorize]
    public class BidsController : Controller
    {

        BidsService service = new BidsService();

        [HttpPost]
        public ActionResult Bid(int ID)
        {
            JsonResult result = new JsonResult();
            if (User.Identity.IsAuthenticated)
            {
                Bid bid = new Bid();
                bid.AuctionID = ID;
                bid.UserID = User.Identity.GetUserId();  ///login user
                bid.Timestamp = DateTime.Now;
                bid.BidAmount = 10;
                var bidResult = service.AddBid(bid);
                if(bidResult)
                {
                    result.Data = new { Success = true};

                }
                else
                {
                    result.Data = new { Success = false, Message = "Unable to add Bids to auctions" };

                }
            }
            else
            {
                result.Data = new { Success = false, Message = "User Need to Login for Bid" };
            }
            return result;
        }
    }
}