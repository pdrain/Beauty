using BeautyProject.Dao;
using BeautyProjectModes;
using ServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApi.Service
{
    public class ProjectService
    {


        public ApiResult GetProjectCat(string guid)
        {
            ProjectDao projectDao = new ProjectDao();
            try
            {
                if (string.IsNullOrEmpty(guid))
                {
                    return new ApiResult() { Code = 0, Result = new ProjectCat() };
                }
                else
                {
                    ProjectCat cat = projectDao.GetProjectCatById(guid);
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
            ProjectDao projectDao = new ProjectDao();


            try
            {
                var list = projectDao.GetProjectCats();
                return new ApiResult() { Code = 0, Result = list };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }

        public ApiResult GetProjectCatByParentId(string guid)
        {
            ProjectDao projectDao = new ProjectDao();


            try
            {
                var list = projectDao.GetProjectCatByParentId(guid);
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
                ProjectDetail detail = projectDao.GetProjectDetail(id);
                return new ApiResult() { Code = 0, Result = detail };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }
        public ApiResult GetProjectList(string guid)
        {
            ProjectDao projectDao = new ProjectDao();

            try
            {
                List<ProjectDetail> details = projectDao.GetProjectDetailList(guid);
                return new ApiResult() { Code = 0, Result = details };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }


        /// <summary>
        /// 新增项目目录分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ApiResult AddProjectCatType(string parentGuid, string name)
        {
            ProjectDao projectDao = new ProjectDao();

            try
            {
                ProjectCat projectCat = new ProjectCat();
                projectCat.Guid = Guid.NewGuid().ToString();
                projectCat.ParentGuid = parentGuid;
                projectCat.Name = name;
                projectDao.Insert(projectCat);
                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }

        /// <summary>
        /// 更新项目目录分类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ApiResult UpdateProjectCatType(string guid, string name)
        {
            ProjectDao projectDao = new ProjectDao();

            try
            {
                ProjectCat cat = projectDao.GetProjectCatById(guid);
                projectDao.Update(cat);
                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }

        /// <summary>
        /// 更新项目明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ApiResult UpdateProjectDetail(int id)
        {
            ProjectDao projectDao = new ProjectDao();

            try
            {
                ProjectDetail detail = projectDao.GetProjectDetail(id);
                projectDao.UpdateDetail(detail);
                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }

        /// <summary>
        /// 新增项目
        /// </summary>
        /// <param name="projectDetail"></param>
        /// <returns></returns>
        public ApiResult CreateProjectDetail(ProjectDetail projectDetail)
        {
            ProjectDao projectDao = new ProjectDao();

            try
            {
                projectDao.InsertDetail(projectDetail);
                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }
    }
}