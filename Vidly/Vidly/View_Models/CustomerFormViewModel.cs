
using System.Collections.Generic;

using Vidly.Models;

namespace Vidly.View_Models
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
    }
}