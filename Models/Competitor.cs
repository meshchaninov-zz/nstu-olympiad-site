using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nstu_olympiad_site.Models
{
    public class Competitor : User
    {
        public int ContestId { get; set; }
        public virtual Contest Contest { get; set; }

        public bool IsApproved { get; set; }        
        public bool IsDisqualify { get; set; }
        public bool IsNonOfficial { get; set; }

        //ERROR:
        // Unable to determine the relationship represented by navigation 
        // property 'Competitor.Members' of type 'ICollection<User>'. 
        // Either manually configure the relationship, or ignore this
        //  property using the '[NotMapped]' attribute or by using 
        // 'EntityTypeBuilder.Ignore' in 'OnModelCreating'.
        public virtual ICollection<User> Members { get; set; }
    }
}