using AdvertisementApp.Dtos.Interfaces;
using System;

namespace AdvertisementApp.Dtos
{
    public class AdvertiesementListDto : IDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
