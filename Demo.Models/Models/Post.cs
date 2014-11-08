using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models.Models
{
    public class Post
    {       
        public int Id { get; set; }
        
        public String Title { get; set; }
        
        public String Body { get; set; }      
       

        public String Email { get; set; }

        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}