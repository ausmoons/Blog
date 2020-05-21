using BlogApp.Data;
using BlogApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogApp.Services
{

    public interface IBlogService
    {
        IEnumerable<Blog> GetAll();
        Blog GetById(int id);
        Blog Create(Blog blog);
        void Update(Blog blog);
        void Delete(int id);
    }

    public class BlogService : IBlogService
    {
        private DataContext _context;

        public BlogService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Blog> GetAll()
        {
            return _context.Blogs;
        }

        public Blog GetById(int id)
        {
            return _context.Blogs.Find(id);
        }

        
       public Blog Create(Blog blog)
       {


           if (_context.Blogs.Any(x => x.Title == blog.Title))
               throw new AppException("Blog with a title \"" + blog.Title + "\"  already exist");

            blog.Date = DateTime.Now;
           _context.Blogs.Add(blog);
           _context.SaveChanges();

           return blog;
       }

       public void Update(Blog blog)
       {
           var blogToUpdate = _context.Blogs.Find(blog.Id);

           if (blogToUpdate == null)
               throw new AppException("Blog not found");

           _context.Blogs.Update(blogToUpdate);
           _context.SaveChanges();
       }

       public void Delete(int id)
       {
           var blog = _context.Blogs.Find(id);
           if (blog != null)
           {
               _context.Blogs.Remove(blog);
               _context.SaveChanges();
           }
       }
       
    }
}
