using Elhoot_HomeDevices.Data;

namespace Elhoot_HomeDevices.ViewModels
{
    public class OrderDetailsViewModel
    {
        public Order Order { get; set; }
        public List<OrderViewModel> OrderViewModels { get; set; }
    }
}

