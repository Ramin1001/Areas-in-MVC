using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace P208_ASP_Front.Models
{
    public class ChangePassword
    {
        [Required(ErrorMessage = "Old password should be filled")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New password should be filled")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password should be at least 8 long")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm password should be filled")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }
    }
}