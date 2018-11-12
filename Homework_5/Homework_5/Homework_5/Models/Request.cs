// This file serves as our model class for the project.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// This was added to the standard empty template to allow for the data annotations seen below.
using System.ComponentModel.DataAnnotations;


/// <summary>
/// This is the namespace that contains the model class for the project.
/// </summary>
namespace Homework_5.Models
{

    /// <summary>
    /// This is the model class which actually contains the properties for interacting with the data.
    /// Note the use of various data annotations such as "Required", "StringLength", and "Display".
    /// </summary>
    public class Request
    {
        /// <summary>
        /// This the property for accessing the id of the database entries.
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// This is the property for accessing the first name field of a database field.
        /// </summary>
        [Required]
        [StringLength(20)]
        [DataType(DataType.Text),
         RegularExpression(@"^[a-zA-Z ]*$",
         ErrorMessage = "Must be a name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        /// <summary>
        /// This is the property for accessing last name field of a database field.
        /// </summary>
        [Required]
        [StringLength(20)]
        [DataType(DataType.Text),
         RegularExpression(@"^[a-zA-Z ]*$",
         ErrorMessage = "Must be a name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        // Consulted Nick on how to do the validation.
        /// <summary>
        /// This is the property for accessing the phone number field of a database entry.
        /// </summary>
        [Required]
        [StringLength(12)]
        [DataType(DataType.PhoneNumber), 
         RegularExpression(@"^\d{3}-\d{3}-\d{4}$", 
         ErrorMessage = "Must have format: ###-###-####")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        /// <summary>
        /// This is the property for accessing the apartment name field of a database entry.
        /// </summary>
        [Required]
        [StringLength(40)]
        [DataType(DataType.Text),
         RegularExpression(@"^[a-zA-Z ]*$",
         ErrorMessage = "Must be an apartment name")]
        [Display(Name = "Apartment Name")]
        public string ApartmentName { get; set; }


        /// <summary>
        /// This is the property for accessing the unit number field of a database entry.
        /// </summary>
        [Required]
        [RegularExpression(@"^[0-9]*$",
         ErrorMessage = "Must be a positive number")]
        [Display(Name = "Unit Number")]
        public int UnitNumber { get; set; }


        /// <summary>
        /// This is the property for accessing the request explanation field of a database entry.
        /// </summary>
        [Required]
        [Display(Name = "Request Explanation")]
        public string RequestExplanation { get; set; }


        /// <summary>
        /// This is the property for accessing the permission field of a database entry.
        /// </summary>
        [Required]
        public bool Permission { get; set; }


        /// <summary>
        /// This is the property for accessing the data and time of request field of a database entry.
        /// </summary>
        [Required]
        public DateTime DateTimeOfRequest { get; set; }


        /// <summary>
        /// This an override ToString method.
        /// </summary>
        /// <returns>returns a string that represents the database fields</returns>
        public override string ToString()
        {
            return $"{base.ToString()}: {FirstName} {LastName} {PhoneNumber} {ApartmentName} {UnitNumber} {RequestExplanation} {Permission} {DateTimeOfRequest}";
        }
    }
}