using ServiceApi.Models;
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
            return new List<ProjectCat>() { new ProjectCat(), new ProjectCat() };
        }


        public BeautyItem GetProject(int id)
        {
            return new BeautyItem();
        }

        public List<BeautyItem> GetProjectList()
        {
            return new List<BeautyItem>() { new BeautyItem(), new BeautyItem(), new BeautyItem(), new BeautyItem() };
        }

        public List<BeautyItem> GetProjectList(int catId)
        {
            return new List<BeautyItem>(){ new BeautyItem(),new BeautyItem()};
        }
    }
}