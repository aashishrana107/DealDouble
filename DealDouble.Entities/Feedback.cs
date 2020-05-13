using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Entities
{
    public class Feedback:BaseEntity
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
       
    }
}
