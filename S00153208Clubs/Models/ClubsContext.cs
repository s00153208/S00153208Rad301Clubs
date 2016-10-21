using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using S00153208Clubs.Models.ClubModels;

namespace S00153208Clubs.Models
{
    public class ClubContext : DbContext
    {

        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubEvent> ClubEvents { get; set; }
        public DbSet<Member> Member { get; set; }

        public ClubContext()
            : base("DefaultConnection")
        {
        }

        public static ClubContext Create()
        {
            return new ClubContext();
        }
    }

}