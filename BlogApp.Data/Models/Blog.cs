using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Data.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public string Content { get; set; }

        //public byte[] Picture { get; set; }

        public string Author { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
