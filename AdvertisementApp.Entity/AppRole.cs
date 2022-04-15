using System.Collections.Generic;

namespace AdvertisementApp.Entity
{
    public class AppRole : BaseEntity
    {
        public string Definition { get; set; }
        public List<AppUserRole> AppUserRoles { get; set; }
    }
}
