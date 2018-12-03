using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// added these

using System.ComponentModel.DataAnnotations;

/// <summary>
/// This is the namespace of the View Model for our project.
/// </summary>
namespace WorldWideImporters.Models.ViewModels
{
    /// <summary>
    /// This is the view model class for our project.
    /// </summary>
    public class DisplayModel
    {
        // property for accessing Myperson.
        public Person MyPerson { get; set; }

        // property for accessing MyCustomer.
        public Customer MyCustomer { get; set; }

        // property for accessing MyInvoiceLine.
        public List<InvoiceLine> MyInvoiceLine { get; set; }

    }
}