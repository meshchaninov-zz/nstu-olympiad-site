using System;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace nstu_olympiad_site.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            CreateDate = DateTime.Now;
            LastLoginDate = DateTime.Now;
        } 

        public string DisplayName { get; set; }
        public int AppUserId { get; set; }
        public User AppUser { get; set; }
        
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime LastLoginDate { get; set; }

        public int? Year { get; set; }
        public string Detail { get; set; }
        public string City { get; set; }
        public string Comment { get; set; }
    }
}