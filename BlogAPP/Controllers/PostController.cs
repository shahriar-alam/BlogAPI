using BlogEntity;
using BlogInterface;
using System;
using System.Net;
using System.Web.Http;

namespace BlogAPP.Controllers
{
    [RoutePrefix("api/posts")]
    public class PostController : ApiController
    {
        IPostRepository prepo;
        ICommentRepository crepo;

        public PostController(IPostRepository prepo, ICommentRepository crepo)
        {
            this.prepo = prepo;
            this.crepo = crepo;
        }

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
            post.DateTime = DateTime.Now;
            prepo.Insert(post);
            string url = Url.Link("GetPost", new { id = post.Id });
            post.PostId = post.Id;
            prepo.Update(post);
            return Created(url, post);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromBody]Post post, [FromUri]int id)
        {
            Post p = prepo.Get(id);

            if (p != null)
            {
                prepo.Update(post);
                return Ok(post);
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            prepo.Delete(prepo.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}/comments")]
        public IHttpActionResult GetComments( [FromUri]int id)
        {

            return Ok(crepo.GetCommentsByPost(id));

        }
    }
}
