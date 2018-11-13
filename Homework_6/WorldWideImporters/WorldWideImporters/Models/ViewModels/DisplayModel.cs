using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// added these

using System.ComponentModel.DataAnnotations;

namespace WorldWideImporters.Models.ViewModels
{
    public class DisplayModel
    {
        public Person MyPerson { get; set; }
        public Customer MyCustomer { get; set; }

        public List<InvoiceLine> MyInvoiceLine { get; set; }

    }
}