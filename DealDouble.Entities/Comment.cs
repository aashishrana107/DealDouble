using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Entities
{
    public class Comment : BaseEntity
    {
        [Required]
        [MinLength(10)]
        [MaxLength(150)]
        public string Text { get; set; }
        public int UserID { get; set; }
        public DateTime TimeStamp { get; set; }
        public int EntityID { get; set; }
        public int RecordID { get; set; }
    }
}
