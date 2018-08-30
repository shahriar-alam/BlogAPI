using BlogEntity;
using BlogInterface;
using System;
using System.Net;
using System.Web.Http;

namespace BlogAPP.Controllers
{
    [RoutePrefix("api/comments")]
    public class CommentController : ApiController
    {
        ICommentRepository crepo;

        public CommentController(ICommentRepository crepo)
        {
            this.crepo = crepo;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(crepo.GetAll());
        }

        [Route("{id}", Name = "GetComment")]
        public IHttpActionResult Get(int id)
        {
            return Ok(crepo.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Comment comment)
        {
            //comment.DateTime = DateTime.Today;
            crepo.Insert(comment);
            string url = Url.Link("GetComment", new { id = comment.Id });
            comment.CommentId = comment.Id;
            crepo.Update(comment);
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
