using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ElectronicStore.Models
{
    public class Address
    {
        [AllowNull]
        public int Id { get; set; }
        public string City { get; set; }    
        public string Street { get; set; }
        [MaxLength(6)]
        public string PostalCode { get; set; }
        public int HouseNumber {  get; set; }
    }
}
