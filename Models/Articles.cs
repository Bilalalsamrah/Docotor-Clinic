using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace AwpDemo.Models
{
    [Table("tbleArticle")]
    public class Articles
    {

        public int Visitor { get; set; }
       
        public string ArticleAdress { get; set; }
        [DataType(DataType.MultilineText)]
        
        public string Article { get; set; }
        public int Id { get; set; }
        [Display (Name =" Path Of Image")]
        public string ImageName { get; set; }
    }
}