﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab26Tom.Models
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime DestinyBirthday { get; set; }
    }
}
