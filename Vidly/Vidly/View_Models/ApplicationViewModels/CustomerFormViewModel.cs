using System.Collections.Generic;
using Vidly.Models;

namespace Vidly.View_Models.ApplicationViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}