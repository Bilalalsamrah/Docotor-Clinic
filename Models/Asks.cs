using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AwpDemo.Models
{[Table("tblAsks")]
    public class Asks
    {
        [Required(ErrorMessage = "Required Field")]
        [DataType(DataType.MultilineText)]

        public string Question { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Required Field")]
        public string Answer { get; set; }
        public string UserName { get; set; }
        public int Id { get; set; }
    }
}