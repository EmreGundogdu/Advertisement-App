using AdvertisementApp.DataAccess.Concrete;
using AdvertisementApp.DataAccess.Context;
using AdvertisementApp.DataAccess.Interface;
using AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdvertiesmentContext _context;

        public UnitOfWork(AdvertiesmentContext context)
        {
            _context = context;
        }
        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new GenericRepository<T>(_context);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
