using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using ImNew.Domain.Model;
using ImNew.Domain.Repositories;
using ImNew.Infrastructure;
using ImNew.Models;

namespace ImNew.Controllers
{
	[RoutePrefix("api/technologies")]
	[EnableCors(headers: "*", methods: "*", origins: "*")]
	public class TechnologyController : ApiController
    {
        // GET api/<controller>

        public TechnologyService TechnologyService = new TechnologyService(new TechnologyRepository(Database.DbContext));

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(TechnologyService.GetAllTechnology());
        }

        // GET api/<controller>/5
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(TechnologyService.GetTechnology(id));
        }

		[Route("add/{name}")]
		[HttpGet]
		public IHttpActionResult Post([FromUri] string name)
	    {
		    TechnologyService.AddNew(name);
		    return Ok();
	    }
    }
}