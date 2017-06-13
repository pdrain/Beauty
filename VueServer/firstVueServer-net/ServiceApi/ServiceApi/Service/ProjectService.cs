using ServiceApi.Models;
using ServiceApi.Service.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApi.Service
{
    public class ProjectService
    {
        
        public ProjectCat GetProjectCat(int id)
        {
            return new ProjectCat();
        }

        public List<ProjectCat> GetProjectCats()
        {
            ProjectCatDao projectCatDao = new ProjectCatDao();
           return  projectCatDao.GetProjectCats();
        }


        public BeautyItem GetProject(int id)
        {
            ProjectDao projectDao = new ProjectDao();
            return projectDao.GetProject(id);
        }

        public List<BeautyItem> GetProjectList()
        {
            return new List<BeautyItem>() { new BeautyItem(), new BeautyItem(), new BeautyItem(), new BeautyItem() };
        }

        public List<BeautyItem> GetProjectList(int catId)
        {

            ProjectDao projectDao = new ProjectDao();
            return projectDao.GetProjectList(catId);
        }
    }
}