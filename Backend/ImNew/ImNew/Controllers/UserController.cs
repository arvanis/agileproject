using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using ImNew.Domain.Repositories;
using ImNew.Infrastructure;
using ImNew.Models;

namespace ImNew.Controllers
{
	[RoutePrefix("api/users")]
	public class UserController : ApiController
    {
		// GET api/<controller>

		public UserService UserService = new UserService(new UserRepository(Database.DbContext));

		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok(UserService.GetAllUsers());
		}

        // GET api/<controller>/5
		[Route("{id}")]
        public IHttpActionResult Get(int id)
        {
	        return Ok(UserService.GetUser(id));
        }

        // POST api/<controller>
		[HttpPost]
        public void Post(DtoUserDetails value)
		{
			
		}

        // PUT api/<controller>/5
		[HttpPut]
        public void Put(int id, [FromBody]DtoUserDetails value)
        {
        }

        // DELETE api/<controller>/5
		[HttpDelete]
        public void Delete(int id)
        {
        }
    }
}