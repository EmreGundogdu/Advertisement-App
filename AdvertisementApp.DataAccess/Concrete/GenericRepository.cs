using AdvertisementApp.DataAccess.Context;
using AdvertisementApp.DataAccess.Interface;
using AdvertisementApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AdvertiesmentContext _context;

        public GenericRepository(AdvertiesmentContext context)
        {
            _context = context;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }
        public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T,TKey>> selector) 
        {
            return await _context.Set<T>().OrderBy(selector).ToListAsync();
        }
    }
}
