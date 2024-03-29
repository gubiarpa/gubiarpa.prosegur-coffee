﻿using System.ComponentModel.DataAnnotations;

namespace gubiarpa.prosegur_coffee.web_api.Models
{
    public class User
    {
        [Key]
        public Guid IDUser { get; set; }
        public string DocumentNumber { get; set; }
        public string Fullname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
