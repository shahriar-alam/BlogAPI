using BlogEntity;
using BlogInterface;
using System.Net;
using System.Web.Http;

namespace BlogAPP.Controllers
{
    [RoutePrefix("api/topics")]
    public class TopicController : ApiController
    {
        ITopicRepository trepo;

        public TopicController(ITopicRepository trepo)
        {
            this.trepo = trepo;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(trepo.GetAll());
        }

        [Route("{id}", Name = "GetTopic")]
        public IHttpActionResult Get(int id)
        {
            return Ok(trepo.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(Topic topic)
        {
            trepo.Insert(topic);
            string url = Url.Link("GetTopic", new { id = topic.Id });
            topic.TopicId = topic.Id;
            trepo.Update(topic);
            return Created(url, topic);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody]Topic topic, [FromUri]int id)
        {
            Topic t = trepo.Get(id);

            if (t != null)
            {
                trepo.Update(topic);
                return Ok(topic);
            }
            else
                return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            trepo.Delete(trepo.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
