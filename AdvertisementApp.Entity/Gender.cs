﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementApp.Entity
{
    public class Gender
    {
        public int Id { get; set; }
        public string Definition { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
