using System;

namespace AdvertisementApp.Entity
{
    public class ProvidedServices : BaseEntity
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
