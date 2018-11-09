// This file serves as our data access layer component of the project.

using System;
using System.Collections.Generic;
using System.Data.Entity; // This was added via installation of the entity framework.
using System.Linq;
using System.Web;

//This was added to gain access to our model class.
using Homework_5.Models;


/// <summary>
/// This is the namespace for our data access layer.
/// </summary>
namespace Homework_5.DAL
{

    /// <summary>
    /// This is the class that actually defines our data access layer.
    /// Note the use of the DbContext class.
    /// </summary>
    public class RequestContext : DbContext
    {

        /// <summary>
        /// This method allows us access to our named database with respect to web application itself
        /// </summary>
        public RequestContext() : base("name=OurRenters")
        {

        }

        /// <summary>
        /// Specifies what can be done with database with respect to extracting or inserting data.
        /// </summary>
        public virtual DbSet<Request> Requests { get; set; }
    }
}