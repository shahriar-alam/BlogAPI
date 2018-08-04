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
    [RoutePrefix("api/comments")]
    public class CommentController : ApiController
    {
        ICommentRepository crepo = new CommentRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(crepo.GetAll());
        }

        [Route("{id}", Name = "GetTopic")]
        public IHttpActionResult Get(int id)
        {
            return Ok(crepo.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Comment comment)
        {
            crepo.Insert(comment);
            string url = Url.Link("GetTopic", new { id = comment.Id });
            return Created(url, comment);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody]Comment comment, [FromUri]int id)
        {
            Comment c = crepo.Get(id);

            if (c != null)
            {
                crepo.Update(comment);
                return Ok(comment);
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            crepo.Delete(crepo.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
