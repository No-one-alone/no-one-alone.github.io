using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework_5.Models
{
    public class Request
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string ApartmentName { get; set; }

        public int UnitNumber { get; set; }

        public string RequestExplanation { get; set; }

        public bool Permission { get; set; }

        public DateTime DateTimeOfRequest { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} {PhoneNumber} {ApartmentName} {UnitNumber} {RequestExplanation} {Permission} {DateTimeOfRequest}";
        }


    }
}