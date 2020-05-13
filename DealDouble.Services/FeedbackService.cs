using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class FeedbackService
    {
        public void SaveFeedback(Feedback feedback)
        {
            DealDoubleContext context = new DealDoubleContext();
            context.Feedbacks.Add(feedback);
            context.SaveChanges();
        }
        public List<Feedback> GetAllFeedback()
        {
            DealDoubleContext context = new DealDoubleContext();
            return context.Feedbacks.OrderByDescending(x=>x.ID).ToList();
        }
    }
}
