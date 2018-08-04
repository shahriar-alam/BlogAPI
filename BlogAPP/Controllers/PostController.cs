using BlogEntity;
using BlogInterface;
using BlogRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogAPP.Controllers
{
    [RoutePrefix("api/posts")]
    public class PostController : ApiController
    {
        IPostRepository prepo = new PostRepository(); 

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(prepo.GetAll());
        }

        [Route("{id}", Name = "GetPost")]
        public IHttpActionResult Get(int id)
        {
            return Ok(prepo.Get(id));
        }

        [Route("")]
        public IHttpActionResult PostNew(Post post)
        {
            prepo.Insert(post);
            string url = Url.Link("GetPost", new { id = post.Id });
            return Created(url, post);
        }

    }
}
