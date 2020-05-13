using DealDouble.Services;
using DealDouble.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class User1Controller : Controller
    {
        // GET: User1
        public ActionResult Index()
        {
            UserService userService = new UserService();
            UserListingViewModel model = new UserListingViewModel();
            
            model.dealDoubleUsers = userService.UsersWithRoles();
            return View(model);
        }
    }
}