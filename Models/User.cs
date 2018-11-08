using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace nstu_olympiad_site.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public long? GoogleId {get; set;}
        public long? VkId {get;set;}
        public long? GithubId {get; set;}
        public bool IsHidden { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public DateTime? RegistrationDate { get; set; }

        [ForeignKey("Coach")]
        public int? CoachId { get; set; }
        public virtual User Coach { get; set; }

        public int? SchoolId { get; set; }
        public virtual School School { get; set; }

        public virtual ICollection<Competitor> Memberships { get; set; }
        public virtual ICollection<Solution> Solutions { get; set; }
        public virtual ICollection<ClarificationToUser> Clarifications { get; set; }
    }
}