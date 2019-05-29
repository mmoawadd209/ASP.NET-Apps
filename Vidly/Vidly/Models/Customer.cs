

using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter customer name.")]
        [Display(Name = "Customer Name")]
        public string Name { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        
        public MembershipType MembershipType { get; set; }

        [Required]
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}