﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BdPouch.Web.Models
{
    public class LoginViewModel
    {
        [Display(Name ="Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }
        public string IncorrectInput { get; set; }
        public string ReturnUrl { get; set; }
    }
}
