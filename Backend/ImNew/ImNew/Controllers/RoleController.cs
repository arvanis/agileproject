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

		[HttpPost]
		[Route]
		public IHttpActionResult Post([FromBody]string value)
		{
			RoleService.AddRole(value);
			return Ok();
		}

		[Route("init")]
		[HttpGet]
		public IHttpActionResult InitData()
	    {
		    RoleService.AddRole("Senior Developer");
			RoleService.AddRole("Scrum Master");
			RoleService.AddRole("Product Owner");
			RoleService.AddRole("Medium Developer");
			RoleService.AddRole("People");
			RoleService.AddRole("Growth");
			RoleService.AddRole("Businnes Managment");
			RoleService.AddRole("Software Development Manager");
			RoleService.AddRole("Bussines Owner");
		    return Ok();
	    }
	}
}
