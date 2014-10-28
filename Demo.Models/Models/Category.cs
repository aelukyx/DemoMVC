using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo.Models.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }

        public List<Post> Posts { get; set; } 
    }
}