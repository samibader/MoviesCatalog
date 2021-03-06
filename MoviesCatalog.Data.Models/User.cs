﻿using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;

namespace MoviesCatalog.Data.Models
{
    public class User : IUser<int>
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        public virtual bool LockoutEnabled { get; set; }

        public virtual int AccessFailedCount { get; set; }

        public string UserName { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual IList<Movie> Movies { get; set; }

        public User()
        {
            CreateDate = DateTime.Now;
            Movies = new List<Movie>();
        }
    }
}
