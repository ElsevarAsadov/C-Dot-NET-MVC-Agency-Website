using Business.Services.Interfaces;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService CategoryService)
        {

            _categoryService = CategoryService;

        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllCategories());
        }

        public async Task<IActionResult> Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Category model)
        {
            if (! ModelState.IsValid) return View();
        

            await _categoryService.CreateNewCategory(model);

            return RedirectToAction(nameof(Index));


        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) {

            await _categoryService.DeleteCategory(id);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            Category? old = await _categoryService.GetById(id);

            if(old is null) return BadRequest();
           
            return View(old);


        }
        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Name", "Name Error");
                return View(category);
            };

            await _categoryService.UpdateCategory(category);

            return RedirectToAction(nameof(Index));
        }
    }
}
