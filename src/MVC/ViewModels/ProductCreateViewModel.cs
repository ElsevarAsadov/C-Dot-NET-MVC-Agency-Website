using Core.Models;

namespace MVC.ViewModels
{
    public class ProductCreateViewModel
    {
       public Product Product { get; set; } = new Product();
        public List<Category>? Categories { get; set; }
    }
}
