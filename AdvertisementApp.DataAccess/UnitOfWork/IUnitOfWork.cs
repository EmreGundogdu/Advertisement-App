using AdvertisementApp.DataAccess.Interface;
using AdvertisementApp.Entity;
using System.Threading.Tasks;

namespace AdvertisementApp.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChangesAsync();
    }
}
