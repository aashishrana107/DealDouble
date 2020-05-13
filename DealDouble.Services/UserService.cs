using DealDouble.Data;
using DealDouble.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealDouble.Services
{
    public class UserService
    {
        DealDoubleContext context = new DealDoubleContext();
        public int GetAllNumberUser()
        {
            return context.Users.Count();
        }
        public List<DealDoubleUser> UsersWithRoles()
        {
            return context.Users.ToList();
            
        }
        //public List<string> WithRoles()
        //{
           // return context.Roles.ToList();

       // }
    }
}
