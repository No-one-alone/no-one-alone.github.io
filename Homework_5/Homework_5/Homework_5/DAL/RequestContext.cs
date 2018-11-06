using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

//added this
using Homework_5.Models;

namespace Homework_5.DAL
{
    public class RequestContext : DbContext
    {
        public RequestContext() : base("name=OurRenters")
        {

        }

        public virtual DbSet<Request> Requests { get; set; }
    }
}