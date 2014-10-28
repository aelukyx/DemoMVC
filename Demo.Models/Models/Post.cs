using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String Comments { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


    }
}