using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ImNew.Domain.Repositories;
using ImNew.Infrastructure;
using ImNew.Models;

namespace ImNew.Controllers
{
	[RoutePrefix("api/roles")]
	[EnableCors(headers: "*", methods: "*", origins: "*")]
	public class RoleController : ApiController
    {
		public RoleService RoleService = new RoleService(new RoleRepository(Database.DbContext));

		[Route("")]
		public IHttpActionResult Get()
		{
			return Ok(RoleService.GetAllRoles());
		}

		[Route("add/{name}")]
		[HttpGet]
		public IHttpActionResult Post([FromUri]string name)
		{
			RoleService.AddRole(name);
			return Ok();
		}
	}
}
