using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// Added this 
using System.ComponentModel.DataAnnotations;

namespace Homework_5.Models
{
    public class Request
    {
        [Key]
        public int ID { get; set }

        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required]
        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(40)]
        public string ApartmentName { get; set; }

        [Required]
        public int UnitNumber { get; set; }

        [Required]
        public string RequestExplanation { get; set; }

        [Required]
        public bool Permission { get; set; }

        [Required]
        public DateTime DateTimeOfRequest { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} {PhoneNumber} {ApartmentName} {UnitNumber} {RequestExplanation} {Permission} {DateTimeOfRequest}";
        }


    }
}