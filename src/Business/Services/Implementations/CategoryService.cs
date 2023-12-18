using Business.Services.Interfaces;
using Core.Models;
using Core.Respositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository _repo;

        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;            
        }

        public async Task CreateNewCategory(Category entity)
        {
            await _repo.AddAsync(entity);
            await _repo.CommitAsync();
        }

        public async Task DeleteCategory(int id)
        {
            Category old = await _repo.GetByIdAsync(x=>x.Id == id);

            //validate

            _repo.Delete(old);
            await _repo.CommitAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _repo.GetAllAsync();
          
        }

        public async Task UpdateCategory(Category category)
        {
            _repo.Update(category);
            await _repo.CommitAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _repo.GetByIdAsync(x=>x.Id == id);
        }
    }
}
