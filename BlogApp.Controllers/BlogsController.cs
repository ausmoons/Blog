using AutoMapper;
using BlogApp.Controllers.Helpers;
using BlogApp.Data.Models;
using BlogApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace BlogApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Users/{userId}/[controller]")]
    public class BlogsController : ControllerBase
    {
        private IBlogService _blogService;
        private IMapper _mapper;

        public BlogsController(
            IBlogService blogService,
            IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var blogs = _blogService.GetAll();
            var model = _mapper.Map<IList<BlogModel>>(blogs);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var blog = _blogService.GetById(id);
            return Ok(blog);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddBlog([FromBody]CreateBlogModel model)
        {
            var blog = _mapper.Map<Blog>(model);

            try
            {
                _blogService.Create(blog);
                return Ok(blog);
            }
            catch (Helpers.AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateBlogModel model)
        {
            var blog = _mapper.Map<Blog>(model);
            blog.Id = id;

            try
            {
                _blogService.Update(blog);
                return Ok();
            }
            catch (Helpers.AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogService.Delete(id);
            return Ok();
        }
    }
}
