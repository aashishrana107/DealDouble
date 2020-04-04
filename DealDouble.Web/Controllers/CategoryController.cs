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
    public class CategoryController : Controller
    {
        CategoriesService categoriesService = new CategoriesService();
        public ActionResult Index()
        {
            
            CategoryListingViewModel model = new CategoryListingViewModel();
            model.PageTitle = "Categories";
            model.PageDescription = "Categories Listing Page";
            return View(model);

        }
        public ActionResult Listing()
        {
            CategoryListingViewModel model = new CategoryListingViewModel();
            model.Categories = categoriesService.GetAllCategories();
            return PartialView(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            CreateCategoryViewModel model = new CreateCategoryViewModel();
            
            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Create(CreateCategoryViewModel model)
        {
            Category category = new Category();
            category.Name = model.Name;
            
            category.Description = model.Description;
            categoriesService.SaveCategory(category);
            return RedirectToAction("Listing");
        }
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            CreateCategoryViewModel model = new CreateCategoryViewModel();
            
            var category = categoriesService.GetCategoryByID(ID);

            model.ID = category.ID;
            model.Name = category.Name;
            model.Description = category.Description;
            

            return PartialView(model);
        }
        [HttpPost]
        public ActionResult Edit(CreateCategoryViewModel model)
        {
            
            Category category = new Category();
            category.ID = model.ID;
            category.Name = model.Name;
            category.Description = model.Description;
           
            categoriesService.UpdateCategory(category);
            return RedirectToAction("Listing");

        }
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            AuctionsService auctionsService = new AuctionsService();
            var Auction = auctionsService.GetAuctionByID(ID);
            return View(Auction);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            categoriesService.DeleteCategory(category);
            return RedirectToAction("Listing");
        }
        [HttpGet]
        public ActionResult Details(int ID)
        {
            CategoryDetailViewModel model = new CategoryDetailViewModel();
            
            model.Category = categoriesService.GetCategoryByID(ID);
            model.PageTitle = "Category Details:";
            model.PageDescription = model.Category.Description.Substring(0, 10);
            return View(model);
        }
    }
}