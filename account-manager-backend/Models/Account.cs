﻿using System.ComponentModel.DataAnnotations;

namespace account_manager_backend.Models
{
    public class Account
    {   
        [Key]
        public int AccountId { get; set; }
        public string? Name { get; set; }
    }
}
