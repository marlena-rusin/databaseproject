using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronicStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("AppUser")]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
