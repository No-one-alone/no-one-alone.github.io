using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Homework_5.DAL
{
    public class RequestContext : DbContext
    {
        public RequestContext() : base("name=OurRenters")
        {

        }
    }
}