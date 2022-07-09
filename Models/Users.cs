using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AwpDemo.Models
{
    [Table("tblUser")]
    public class Users
    {
        public int Id { get; }
        [Required(ErrorMessage ="Required Field")]
        [Display(Name="User Name")]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        //
        [Required(ErrorMessage = "Required Field")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
        public string City{ get; set; }
        public string Phone{ get; set; }



    }
}