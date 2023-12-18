using Core.Models;
using Core.Respositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface ICategoryService
    { 
        Task<List<Category>> GetAllCategories();
        Task CreateNewCategory(Category entity);

        Task DeleteCategory(int id);

        Task UpdateCategory(Category entity);

        Task<Category> GetById(int id);
    }
}
