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
        public IEnumerable<BeautyItem> Get()
        {
            ProjectService projectService = new ProjectService();
            return projectService.GetProjectList();
        }

        public IEnumerable<BeautyItem> Get(int id)
        {
            ProjectService projectService = new ProjectService();
            return projectService.GetProjectList(id);
        }
    }
}
