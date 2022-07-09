using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace AwpDemo.Models
{
    [Table("tblUser")]
    public class Users
    {
  
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
     
        public string Gender { get; set; }

      [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong Phone Number")]
         public string Phone { get; set; }
       
        public string City { get; set; }



    }
}