﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertisementApp.Dtos;
using AdvertisementApp.Dtos.AdvertisementAppUserStatusDtos;

namespace AdvertisementApp.Dtos
{
    public class AdvertisementAppUserListDto
    {
        public int Id { get; set; }
        public int AdvertisementId { get; set; }
        public AdvertiesementListDto Advertisement { get; set; }
        public int AppUserId { get; set; }
        public AppUserListDto AppUser { get; set; }
        public int AdvertisementAppUserStatusId { get; set; }
        public AdvertisementAppUserStatusListDto AdvertisementAppUserStatus { get; set; }
        public int MilitaryStatusId { get; set; }
        public MilitaryStatusListDto MilitaryStatus { get; set; }
        public int WorkExperience { get; set; }
        public DateTime? EndDate { get; set; }
        public string CvPath { get; set; }
    }
}
