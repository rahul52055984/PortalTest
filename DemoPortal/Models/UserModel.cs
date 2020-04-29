using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DemoPortal.Models
{
    public class UserModel
    {
        


        public int UserId { get; set; }
        [Required(ErrorMessage = "Field required.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Field required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field required.")]
        public string MobileNumber { get; set; }
        [Required(ErrorMessage = "Field required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Field required.")]
        public string Password { get; set; }

        public bool Status { get; set; }
        [Required(ErrorMessage = "Field required.")]
        public int RoleId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdateedDate { get; set; }
        public Nullable<int> UpdateddBy { get; set; }
        public string Role { get; set; }
    }
}