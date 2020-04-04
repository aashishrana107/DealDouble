using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Entities
{
    public class Auction : BaseEntity
    {
        // agar hum kise reference table se data ja reha hai to use btana pada ga virtual keyword ke sath
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }


        [Required]
        [MinLength(10, ErrorMessage ="Minimum length should be 10 characters.")]
        [MaxLength(150, ErrorMessage = "Maximum length should be 15 characters.")]
        public string Title { get; set; }

        
        public string Description { get; set; }

        [Required]
        [Range(100,1000000, ErrorMessage ="Amount between 100,1000000.")]
        public decimal ActualAmount { get; set; }

        
        public DateTime? StartingTime { get; set; }
        public Nullable<DateTime> EndingTime { get; set; }

        public virtual List<AuctionPicture> AuctionPictures { get; set; }
    }
}
