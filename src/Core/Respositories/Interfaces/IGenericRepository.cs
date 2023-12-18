using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Respositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public DbContext _context { get; set; }
        public Task<int> CommitAsync();

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, string[]? includes = null);

        public Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, string[]? includes = null);


        public Task AddAsync(TEntity entity);

        public void Update(TEntity entity);
 

        public void Delete(TEntity entity);
    }
}
