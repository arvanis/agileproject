using System;
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
    [RoutePrefix("api/hobbies")]
    [EnableCors(headers: "*", methods: "*", origins: "*")]

    public class HobbyController : ApiController
    {
        // GET api/<controller>

        public HobbyService HobbyService = new HobbyService(new HobbyRepository(Database.DbContext));

        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(HobbyService.GetAllHobby());
        }

        // GET api/<controller>/5
        [Route("{id}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(HobbyService.GetHobby(id));
        }

        [Route("add/{name}")]
        [HttpGet]
        public IHttpActionResult Post([FromUri] string name)
        {
            HobbyService.AddNew(name);
            return Ok();
        }
    }
}