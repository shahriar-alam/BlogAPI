﻿using BlogEntity;
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
    [RoutePrefix("api/users")]
    public class UserController : ApiController
    {
        IUserRepository urepo = new UserRepository();

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(urepo.GetAll());
        }

        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(urepo.Get(id));
        }

        [Route("")]
        public IHttpActionResult Post(User user)
        {
            User user1 = urepo.GetUserByEmail(user.Email);
            if (user1 != null)
            {
                urepo.Insert(user);
                string url = Url.Link("Get", new { id = user.Id });
                return Created(url, user);
            }

            else
                return StatusCode(HttpStatusCode.Forbidden);
        }

        [Route("{id}")]
        public IHttpActionResult Put([FromBody]User user, [FromUri]int id)
        {
            User user1 = urepo.GetUserByEmail(user.Email);
            if (user1 != null)
            {
                user.Id = id;
                urepo.Update(user);
                return Ok(urepo.Get(id));
            }
            else
                return StatusCode(HttpStatusCode.Forbidden);
        }

        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            urepo.Delete(urepo.Get(id));
            return StatusCode(HttpStatusCode.NoContent);
        }

        [Route("{id}/posts")]
        public IHttpActionResult GetOwnPost(int id)
        {
            return Ok(urepo.GetPostByUserId(id));
        }

        [Route("{id}/posts")]
        public IHttpActionResult GetAllPost()
        {
            return Ok(urepo.GetAllPost());
        }
    }
}