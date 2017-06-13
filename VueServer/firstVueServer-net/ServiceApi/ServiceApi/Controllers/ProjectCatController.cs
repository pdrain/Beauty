using ServiceApi.Models;
using ServiceApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceApi.Controllers
{
    public class ProjectCatController : ApiController
    {
       

        // GET api/ProjectCat
        public IEnumerable<ProjectCat> Get()
        {
            ProjectService projectService = new ProjectService();
            return projectService.GetProjectCats();
        }

        // GET api/ProjectCat/5
        public ProjectCat Get(int id)
        {
            ProjectService projectService = new ProjectService();
            return projectService.GetProjectCat(id);
        }

        // POST api/ProjectCat
        public void Post([FromBody]string value)
        {
            ProjectService projectService = new ProjectService();
        }

        // PUT api/ProjectCat/5
        public void Put(int id, [FromBody]string value)
        {
            ProjectService projectService = new ProjectService();
        }

        // DELETE api/ProjectCat/5
        public void Delete(int id)
        {
            ProjectService projectService = new ProjectService();
        }
    }
}