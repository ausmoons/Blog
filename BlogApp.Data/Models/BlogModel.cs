using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Models
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public string Content { get; set; }

        //public byte[] Picture { get; set; }

        public string Author { get; set; }

        public int UserId { get; set; }
    }
}
