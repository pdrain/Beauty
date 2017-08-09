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
        public ApiResult SaveProjectCat(ProjectCat cat)
        {
            ProjectCatDao projectCatDao = new ProjectCatDao();
            bool resultFlag = false;
            string msg = string.Empty;
            if (cat.ID == 0)
            {
                resultFlag = projectCatDao.Insert(cat);
                if (!resultFlag)
                {
                    msg = "添加美容项目分类失败。";
                }
            }
            else
            {
                resultFlag = projectCatDao.Update(cat);
                if (!resultFlag)
                {
                    msg = "更新美容项目分类失败。";
                }
            }
            return new ApiResult() { Code = resultFlag ? 0 : 1, Message = msg };
        }

        public ApiResult DeleteProject(int id)
        {
            ProjectCatDao projectCatDao = new ProjectCatDao();
            try
            {
                bool result = projectCatDao.Delete(id);
                if (!result)
                {
                    throw new Exception("删除失败。");
                }
                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }

        public ApiResult GetProjectCat(int id)
        {
            ProjectCatDao projectCatDao = new ProjectCatDao();
            try
            {
                if (id == 0)
                {
                    return new ApiResult() { Code = 0, Result = new ProjectCat() };
                }
                else
                {

                    ProjectCat cat = projectCatDao.GetProjectCat(id);
                    return new ApiResult() { Code = 0, Result = cat };
                }
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }


        }

        public ApiResult GetProjectCats()
        {
            ProjectCatDao projectCatDao = new ProjectCatDao();


            try
            {
                var list = projectCatDao.GetProjectCats();
                return new ApiResult() { Code = 0, Result = list };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }


        public ApiResult GetProject(int id)
        {
            ProjectDao projectDao = new ProjectDao();

            try
            {
                if (id == 0) {
                    
                    return new ApiResult() { Code = 0, Result = new BeautyItem() };
                }
                else
                {
                    var project = projectDao.GetProject(id);
                    return new ApiResult() { Code = 0, Result = project };

                }
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }

        public ApiResult GetProjectList()
        {
            ProjectDao projectDao = new ProjectDao();

            try
            {
                var list = projectDao.GetProjectList();
                return new ApiResult() { Code = 0, Result = list };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }

        public ApiResult GetProjectList(int catId)
        {

            ProjectDao projectDao = new ProjectDao();

            try
            {
                var list = projectDao.GetProjectList(catId);
                return new ApiResult() { Code = 0, Result = list };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }
    }
}