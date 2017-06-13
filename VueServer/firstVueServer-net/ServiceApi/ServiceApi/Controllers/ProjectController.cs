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
    public class ProjectController : ApiController
    {

        //  api/project/1
        public BeautyItem Get(int id)
        {
            ProjectService projectService = new ProjectService();
            return projectService.GetProject(id);
        } 
    }
}
