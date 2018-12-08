using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// added this
using System.ComponentModel.DataAnnotations;

/// <summary>
/// This is our namespace for our model
/// </summary>
namespace GiphApp.Models
{
    /// <summary>
    /// This is our model class.
    /// </summary>
    public class SearchRequests
    {
        /// <summary>
        /// This is our Primary key.
        /// </summary>
        [Key]
        [Required]
        public int ID { get; set; }

        /// <summary>
        /// This is the client's IP address.
        /// </summary>
        [Required]
        public String IPAddressOfRequestor { get; set; }

        /// <summary>
        /// This is our entered word.
        /// </summary>
        [Required]
        public String RequestWord { get; set; }

        /// <summary>
        /// This is our client's browser type information.
        /// </summary>
        [Required]
        public String ClientBrowserAgentType { get; set; }

        /// <summary>
        /// This is the timestamp for when the request was made.
        /// </summary>
        [Required]
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
}