using DealDouble.Entities;
using DealDouble.Services;
using DealDouble.Web.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DealDouble.Web.Controllers
{
    public class SharedController : Controller
    {
        SharedService service = new SharedService();

        [HttpPost]
        public JsonResult UploadPicture()
        {
            JsonResult result = new JsonResult();
            List<object> pictureJSON = new List<object>();           
            var pictures = Request.Files;
            for(int i =0;i<pictures.Count;i++)
            {
                var picture = pictures[i];
                var fileName = Guid.NewGuid()+Path.GetExtension(picture.FileName);// picture.FileName+Path.GetExtension(picture.FileName);
                

                var path = Server.MapPath("~/Content/images/") + fileName;
                picture.SaveAs(path);
                var dbPicture = new Picture();
                dbPicture.URL = fileName;
               
                int pictureID = service.SavePicture(dbPicture);
                pictureJSON.Add(new { ID = pictureID, pictureURL = fileName });
            }
            result.Data = pictureJSON;
            return result;
        }



        [HttpPost]
        public JsonResult LeaveComment(CommentViewModel model)
        {
            JsonResult result = new JsonResult();
            try
            {
                
                var comment = new Comment();
                comment.Text = model.Text;
                comment.Rating = model.Rating;
                comment.EntityID = model.EntityID;
                comment.RecordID = model.RecordID;
                comment.UserID = User.Identity.GetUserId();
                comment.TimeStamp = DateTime.Now;
                var res = service.LeaveComment(comment);
                result.Data = new { Success = res };
            }
            catch(Exception ex)
            {
                result.Data = new { Success = false, Message=ex.Message };
            }

            return result;
        }
    }
}