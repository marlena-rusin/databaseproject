using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElectronicStore.ViewModels
{
    public class OrderViewModel
    {
        public int ProductId { get; set; }
        public SelectList Products { get; set; }
    }
}
