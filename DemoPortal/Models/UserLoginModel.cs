using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoPortal.Models
{
    public class UserLoginModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Field required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field required.")]
        public string Password { get; set; }
       
        public string FullName { get; set; }
      
        public int RoleId { get; set; }
    }
}