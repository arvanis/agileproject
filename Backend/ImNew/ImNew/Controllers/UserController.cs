﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using ImNew.Domain.Repositories;
using ImNew.Infrastructure;
using ImNew.Models;

namespace ImNew.Controllers
{
	[RoutePrefix("api/users")]
	[EnableCors(headers: "*", methods: "*", origins: "*")]
	public class UserController : ApiController
    {
		// GET api/<controller>

		public UserService UserService = new UserService(new UserRepository(Database.DbContext));

		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok(UserService.GetAllUsers());
		}

		[Route("search")]
		public IHttpActionResult Get([FromUri]string name, [FromUri]string surname, [FromUri]string role)
		{
			int roleId;
			if (!int.TryParse(role, out roleId))
				roleId = 0;
			return Ok(UserService.GetUsers(name, surname, roleId));
	    }

        // GET api/<controller>/5
		[Route("{id}")]
        public IHttpActionResult Get(int id)
        {
	        return Ok(UserService.GetUserDetails(id));
        }

        // POST api/<controller>
		[HttpPost]
        public void Post([FromBody] DtoUserDetails value)
		{
			UserService.AddUser(value);
		}

        // PUT api/<controller>/5
		[HttpPut]
        public void Put(int id, [FromBody]DtoUserDetails value)
        {
			UserService.EditUser(value);
        }

        // DELETE api/<controller>/5
		[HttpDelete]
        public void Delete(int id)
        {
        }
    }
}