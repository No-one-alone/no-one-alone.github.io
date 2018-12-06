using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;

// added this
using System.ComponentModel.DataAnnotations;

namespace GiphApp.Models
{
    public class SearchRequests
    {
        [Key]
        [Required]
        public int ID { get; set; }

        [Required]
        public String IPAddressOfRequestor { get; set; }

        [Required]
        public String RequestWord { get; set; }

      
        [Required]
        public String ClientBrowserAgentType { get; set; }

  
        [Required]
        public DateTime TimeStamp { get; set; } = DateTime.Now;

    }
}