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
    public class ProjectListController : ApiController
    {
        public ApiResult Get()
        {
            ProjectService projectService = new ProjectService();
            return projectService.GetProjectList();
        }

        public ApiResult Get(int id)
        {
            ProjectService projectService = new ProjectService();
            return projectService.GetProjectList(id);
        }

    }
}
