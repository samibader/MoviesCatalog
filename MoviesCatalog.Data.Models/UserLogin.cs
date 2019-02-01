﻿namespace MoviesCatalog.Data.Models
{
    public class UserLogin
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
