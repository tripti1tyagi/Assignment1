using System;
using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    [MetadataType(typeof(ContactQueryMetadata))]
    public partial class ContactQuery
    {
        // Leave this empty. EF uses this to apply metadata.
    }

    public class ContactQueryMetadata
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Contact No must be 10 digits")]
        public string ContactNo { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailId { get; set; }

        [Required]
        [MinLength(50, ErrorMessage = "Query must be at least 100 characters")]
        public string QueryText { get; set; }

        [DataType(DataType.Date)]
        public DateTime SubmitDate { get; set; }
    }
}
