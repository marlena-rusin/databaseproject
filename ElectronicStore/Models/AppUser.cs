using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicStore.Models
{
    public class AppUser : IdentityUser
    {
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address Address { get; set; }
     }
} 