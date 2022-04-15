using System;
using System.Collections.Generic;

namespace AdvertisementApp.Entity
{
    public class Advertisement : BaseEntity
    {
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        //default olarak değer ile oluşsun istiyorsak -> = DateTime.Now
        public List<AdvertisementAppUser> AdvertisementAppUsers { get; set; }
    }
}
