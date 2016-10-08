using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ImNew.Domain.Repositories;
using ImNew.Infrastructure;

namespace ImNew.Controllers
{
	[RoutePrefix("api/users")]
	public class UserController : ApiController
    {
		// GET api/<controller>
		public UserService UserService = new UserService(new UserRepository());
		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok(UserService.GetAllUsers());
		}

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
	        return string.Empty;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}