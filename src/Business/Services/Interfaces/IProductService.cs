using Core.Models;
using Core.Respositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IProductService
    {

        Task<List<Product>> GetAllProducts();
        Task CreateNewProduct(Product entity);

        Task DeleteProduct(int id);

        Task UpdateProduct(Product entity);

        Task<Product> GetById(int id);

    }
}
