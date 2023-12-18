using Core.Models;
using Core.Respositories.Interfaces;
using Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        public DbContext _context { get; set; }

        public DbSet<TEntity> Table;
        public async Task<int> CommitAsync() => await _context.SaveChangesAsync();

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            Table = _context.Set<TEntity>();
        }

        public async  Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public async void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, string[]? includes = null)
        {
            IQueryable<TEntity> query = GetIncludedQuery(includes);


            return expression is not null ? await query.Where(expression).ToListAsync() : await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, string[]? includes = null)
        {
            IQueryable<TEntity> query = GetIncludedQuery(includes);


            return expression is not null ? await query.Where(expression).FirstOrDefaultAsync() : await query.FirstOrDefaultAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }


        private IQueryable<TEntity> GetIncludedQuery(string[]? includes = null)
        {
            var query = Table.AsQueryable();

            if(includes is not null)
            {
                foreach(string tableName in includes)
                {
                    query.Include(tableName); 
                }
            }

            return query;
        }



    }
}
