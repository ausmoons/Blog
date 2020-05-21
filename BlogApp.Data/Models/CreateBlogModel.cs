using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Data.Models
{
    public class CreateBlogModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Content { get; set; }
       /* [Required]
        public byte[] Picture { get; set; }*/
        [Required]
        public string Author { get; set; }
        [Required]
        public int UserId { get; set; }

    }
}
