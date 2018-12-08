using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//added these
using GiphApp.Models;
using System.Data.Entity;

/// <summary>
/// This is the namespace for our data access layer.
/// </summary>
namespace GiphApp.DAL
{
    /// <summary>
    /// This is our database context class.
    /// </summary>
    public class OurSearchRequestsContext : DbContext
    {
        /// <summary>
        /// This relates to our context.
        /// </summary>
        public OurSearchRequestsContext() : base("name=OurSearchRequests") { }

        /// <summary>
        /// This produces our database entry objects with automatic properties.
        /// </summary>
        public virtual DbSet<SearchRequests> Entries { get; set; }
    }
}