using Business.Services.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using MVC.ViewModels;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllProducts()) ;
        }

        public async Task<IActionResult> Create()
        {
            return View(new ProductCreateViewModel() { 
                Categories = await _categoryService.GetAllCategories()
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel entity)
        {

            await _productService.CreateNewProduct(entity.Product);

            if (!ModelState.IsValid) return View(new ProductCreateViewModel
            {
                Categories = await _categoryService.GetAllCategories()
            });


            return RedirectToAction(nameof(Index));
        }
    } 
}
