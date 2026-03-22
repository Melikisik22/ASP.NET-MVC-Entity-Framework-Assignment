using System;
using System.ComponentModel.DataAnnotations;

namespace InsuranceQuoteApp.Models
{
    public class Insuree
    {
        public int Id { get; set; }

        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required][EmailAddress] public string EmailAddress { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public int CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }

        public bool DUI { get; set; }
        public int SpeedingTickets { get; set; }
        public bool FullCoverage { get; set; }

        public decimal Quote { get; set; }
    }
}
