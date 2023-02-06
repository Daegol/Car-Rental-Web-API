using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoDabiServiceAPI.Data;
using EasyCaching.Core;
using Microsoft.EntityFrameworkCore;

namespace AutoDabiServiceAPI.Repositories
{
    public class GenericRepository <TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly IEasyCachingProviderFactory _easyCachingProviderFactory;

        public GenericRepository(ApplicationDbContext context, IEasyCachingProviderFactory easyCachingProviderFactory)
        {
            _context = context;
            _easyCachingProviderFactory = easyCachingProviderFactory;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var entityName = typeof(TEntity).Name;
            string cacheKey = entityName;
            var cache = _easyCachingProviderFactory.GetCachingProvider("default");

            var result = await cache.GetAsync(cacheKey, async () => await _context.Set<TEntity>().ToListAsync(), TimeSpan.FromSeconds(5));

            return result?.Value;
        }

        public async Task<TEntity> GetById<TKey>(TKey id)
        {
            var entityName = typeof(TEntity).Name;
            string cacheKey = entityName + $"{id}";
            var cache = _easyCachingProviderFactory.GetCachingProvider("default");

            var result = await cache.GetAsync(cacheKey, async () => await _context.Set<TEntity>().FindAsync(id), TimeSpan.FromSeconds(5));
            return result?.Value;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {    
                _context.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;
            }
            
        }


    }
}
