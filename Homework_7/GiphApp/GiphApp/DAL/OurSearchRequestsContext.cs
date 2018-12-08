using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//added these
using GiphApp.Models;
using System.Data.Entity;

namespace GiphApp.DAL
{
    public class OurSearchRequestsContext : DbContext
    {
        public OurSearchRequestsContext() : base("name=OurSearchRequests") { }

        public virtual DbSet<SearchRequests> Entries { get; set; }


    }
}