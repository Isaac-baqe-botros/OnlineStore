using Elhoot_HomeDevices.Data;

namespace Elhoot_HomeDevices.ViewModels
{
    public class CategoryWithProductsViewModel
    {
        public Category category { get; set; }  
       public List<Product> products { get; set; }    
    }
}
