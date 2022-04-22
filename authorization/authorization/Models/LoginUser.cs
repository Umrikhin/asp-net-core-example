using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace authorization.Models
{
    //Class for the user of the application
    public class LoginUser
    {
        [Display(Name = "your name")]
        [Required(ErrorMessage = "Please provide your name.")]
        [StringLength(50, ErrorMessage = "Please enter no more than 50 characters.")]
        public string User { get; set; }

        [Display(Name = "Ваш пароль")]
        [Required(ErrorMessage = "Provide your password.")]
        [StringLength(50, ErrorMessage = "Please enter no more than 50 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter security code.")]
        [StringLength(6)]
        public string CaptchaCode { get; set; }
    }
}
