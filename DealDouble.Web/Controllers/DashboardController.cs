using DealDouble.Data.Migrations;
using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;

namespace DealDouble.Web.Controllers
{
    public class DashboardController : Controller
    {
        CategoriesService categoriesService = new CategoriesService();
        AuctionsService auctionsService = new AuctionsService();
        UserService userService = new UserService();
        
        private DealDoubleUserManager _userManager;
        private DealDoubleRoleManager _roleManager;

        public DashboardController()
        {
        }

        public DashboardController(DealDoubleUserManager userManager, DealDoubleRoleManager roleManager)
        {
            UserManager = userManager;
            RoleManager = roleManager;
          
        }

        public DealDoubleUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<DealDoubleUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public DealDoubleRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<DealDoubleRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }
        public ActionResult Index()
        { 
           DashboardViewModel model = new DashboardViewModel();
           int number= categoriesService.GetAllNumberCategories();
            model.TotalUsers = userService.GetAllNumberUser();
            model.TotalAuctions = auctionsService.GetAllNumberAuctions();
            model.TotalCategories = number;
            return View(model);
        }
        public ActionResult User1()
        {
            UserService userService = new UserService();
            UserListingViewModel model = new UserListingViewModel();
            model.Roles = RoleManager.Roles.ToList();
            //model.dealDoubleUsers = userService.UsersWithRoles();
            model.dealDoubleUsers = UserManager.Users.ToList();
            return View(model);
        }
        public ActionResult Status()
        {
            BidsService bidsService = new BidsService();
            BidStatusViewModel model = new BidStatusViewModel();
            string ID = User.Identity.GetUserId();
            var model1 = new List<BidStatusViewModel>();
            List<string> TitleAmountList = new List<string>();
            
            var nobids = bidsService.NoOfBids(ID);
            int no = nobids.Count();
            
            for (int i = 0; i < no; i++)
            {
                model.Bids = bidsService.GetBidByUserID(ID, nobids[i]);
                TitleAmountList = bidsService.GetBidByID(model.Bids, ID);
                var Title = TitleAmountList[0];
                var BidAmount1 = Convert.ToDecimal(TitleAmountList[1]);
                
                var BidAmount = Convert.ToDecimal(TitleAmountList[2]);
                var EndingTime = Convert.ToDateTime(TitleAmountList[3]);

                


                model1.Add(new BidStatusViewModel {BidID=ID, Title = Title, BidAmount1 = BidAmount1, BidAmount = BidAmount, EndingTime = EndingTime } );
               // model1.Add(new BidStatusViewModel { BidAmount1 = BidAmount1 });
               /// model1.Add(new BidStatusViewModel { BidAmount = BidAmount });
               // model1.Add(new BidStatusViewModel { EndingTime = EndingTime });
                
            //  Amount = TitleAmountList
                // var latestBidder = model.Bid.OrderByDescending(s => s.UserID == ID).FirstOrDefault();
                //   model.LatestBidder = latestBidder != null ? latestBidder.User : null;

            }
            return View(model1);
            
        }

        public ActionResult Payment()
        {

            return View();
        }
      
        public ActionResult Report(string title, string bid)
        {
            List<BidStatusViewModel> model = new List<BidStatusViewModel>();
            // var Title = title;
            //// model.BidAmount = amount;
            // ReportDocument rd = new ReportDocument();

            // rd.Load(Path.Combine(Server.MapPath("~/ReportNew"), "CrystalReport1.rpt"));
            // DataSet ds = new DataSet();
            // ds.Tables.Add("Ashish");
            // ds.Tables.Add("Manish");
            // rd.SetDataSource(ds);

            // Response.Buffer = false;
            // Response.ClearContent();
            // Response.ClearHeaders();
            // try
            // {
            //     Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            //     stream.Seek(0, SeekOrigin.Begin);
            //     return File(stream, "application/pdf", "Product.pdf");

            // }
            // catch (Exception e)
            // {
            //     throw ;
            // }

            model.Add(new BidStatusViewModel() { Title = title, UserID = bid  });
           return View(model);
        //   return new Rotativa.ActionAsPdf("Report");
        }

        public ActionResult GeneratePDF(string title, string bid)
        {
            return new Rotativa.ActionAsPdf("Report", new { title = title, bid=bid });
           
        }

        [HttpPost]
        public ActionResult Hash()
        {
            byte[] hash;
            string postData = new System.IO.StreamReader(Request.InputStream).ReadToEnd();
            dynamic data = JsonConvert.DeserializeObject(postData);
            string d = data.key + "|" + data.txnid + "|" + data.amount + "|" + data.pinfo + "|" + data.fname + "|" + data.email + "|||||" + data.udf5 + "||||||" + data.salt;
            var datab = Encoding.UTF8.GetBytes(d);
            using (SHA512 shaM = new SHA512Managed())
            {
                hash = shaM.ComputeHash(datab);
            }


            string json = "{\"success\":\"" + GetStringFromHash(hash) + "\"}";
            Response.Clear();
            Response.ContentType = "application/json; charset=utf-8";
            Response.Write(json);
            Response.End();
            return View();
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2").ToLower());
            }
            return result.ToString();
        }


        public async Task<ActionResult> UserRole(string userID)
        {
            UserRolesViewModel model = new UserRolesViewModel();
            model.AvailableRoles = RoleManager.Roles.ToList();
            if(!string.IsNullOrEmpty(userID))
            {
                model.user = await UserManager.FindByIdAsync(userID);
                if(model.user != null)
                {
                    model.UserRoles = model.user.Roles.Select(userRole => model.AvailableRoles.FirstOrDefault(role => role.Id == userRole.RoleId)).ToList();
                }
            }
            return View(model);
        }

        public async Task<ActionResult> AssignUserRole(string userID, string roleID)
        {
           if(!string.IsNullOrEmpty(userID) && !string.IsNullOrEmpty(roleID))
            {
                var user = await UserManager.FindByIdAsync(userID);
                if (user != null)
                {
                    var role = await RoleManager.FindByIdAsync(roleID);
                    if (role != null)
                    {
                        await UserManager.AddToRoleAsync(userID, role.Name);

                    }
                }
            }
            return RedirectToAction("UserRole", new { userID = userID });
        }

        public async Task<ActionResult> DeleteUserRole(string userID, string roleID)
        {
            if (!string.IsNullOrEmpty(userID) && !string.IsNullOrEmpty(roleID))
            {
                var user = await UserManager.FindByIdAsync(userID);
                if (user != null)
                {
                    var role = await RoleManager.FindByIdAsync(roleID);
                    if (role != null)
                    {
                        await UserManager.RemoveFromRoleAsync(userID, role.Name);

                    }
                }
            }
            return RedirectToAction("UserRole", new { userID = userID });
        }

    }
}