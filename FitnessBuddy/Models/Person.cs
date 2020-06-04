﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FitnessBuddy.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "The Name Is Required!")]
        [StringLength(255)]
        [Display(Name = "Enter Your Full Name")]
        public string Full_Name { get; set; }

        [Required(ErrorMessage = "Birthdate Field Is Required!")]
        public DateTime Birthdate { get; set; }

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Your Weight!")]
        [Display(Name = "Current Weight in Kg.")]
        public int CurrentWeight { get; set; }

        [Required(ErrorMessage = "Tell Us Your Goal Please!")]
        [Display(Name = "Goal You Wanna Acheive(Shred, Bulk)")]
        public string Goal { get; set; }


    }
}