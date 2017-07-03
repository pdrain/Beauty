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
        [HttpGet]
        public ApiResult Get()
        {
            ProjectService projectService = new ProjectService();
            return projectService.GetProjectCats();
        }

        // GET api/ProjectCat/5
        [HttpGet]
        public ApiResult Get(int id)
        {
            ProjectService projectService = new ProjectService();
            return projectService.GetProjectCat(id);
        }

        // POST api/ProjectCat
        [HttpPost]
        public void Save([FromBody]string value)
        {
            ProjectCat projectCat = new ProjectCat();

            ProjectService projectService = new ProjectService();
            projectService.SaveProjectCat(projectCat);
        }



        // DELETE api/ProjectCat/5
        [HttpPost]
        public void Delete(int id)
        {
            ProjectService projectService = new ProjectService();
        }
    }
}