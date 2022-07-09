using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AwpDemo.Models
{
    [Table("tblAsk")]
    public class Ask
    {
        public string Quistion { get; set; }
        public string Answar { get; set; }
        public int UserId { get; set; }

    }
}