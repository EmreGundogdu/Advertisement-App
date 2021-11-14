using AdvertisementApp.DataAccess.Context;
using AdvertisementApp.DataAccess.Interface;
using AdvertisementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
