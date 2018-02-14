using BeautyProjectModes;
using ServiceApi.Controllers.RequestBody;
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


        /// <summary>
        /// 获取项目目录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ApiResult GetProjectCats()
        {
            ProjectService projectService = new ProjectService();
            return projectService.GetProjectCats();
        }

        /// <summary>
        /// 获取项目分类
        /// </summary>
        /// <param name="postdata"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult GetProjectCatType(GetProjectCatTypeRequestForm requestForm)
        {
            ProjectService projectService = new ProjectService();
            return projectService.GetProjectCatByParentId(requestForm.Guid);

        }

        /// <summary>
        /// 添加项目分类
        /// </summary>
        /// <param name="postdata" ></param>
        /// <returns></returns>
        public ApiResult AddProjectCatType(AddProjectCatTypeRequestForm requestForm)
        {
            ProjectService projectService = new ProjectService();
            return projectService.AddProjectCatType(requestForm.ParentGuid, requestForm.Name);
        }

        /// <summary>
        /// 更新项目分类
        /// </summary>
        /// <param name="postdata"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult UpdateProjectCatType(UpdateProjectCatTypeRequestForm requestForm)
        {
            ProjectService projectService = new ProjectService();
            return projectService.UpdateProjectCatType(requestForm.Guid, requestForm.Name);
        }

        /// <summary>
        /// 获取项目礼拜
        /// </summary>
        /// <param name="postdata"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult GetProjectDetailList(GetProjectDetailListRequestForm requestForm)
        {
            ProjectService projectService = new ProjectService();
            return projectService.GetProjectList(requestForm.CatGuid);
        }

        /// <summary>
        /// 获取项目详情
        /// </summary>
        /// <param name="postdata"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult GetProjectDetail(GetProjectDetailRequestForm requestForm)
        {
            ProjectService projectService = new ProjectService();
            return projectService.GetProject(requestForm.Id);
        }

        /// <summary>
        /// 更新项目详情
        /// </summary>
        /// <param name="requestForm"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult UpdateProjectDetail(UpdateProjectDetailRequestForm requestForm)
        {
            ProjectService projectService = new ProjectService();
            return projectService.UpdateProjectDetail(requestForm.Id);
        }

        /// <summary>
        /// 新增项目（详情）
        /// </summary>
        /// <param name="requestForm"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult AddProjectDetail(AddProjectDetailRequestForm requestForm)
        {
            
            ProjectDetail projectDetail = new ProjectDetail();
            projectDetail.CatGuid = requestForm.ParentCat;
            projectDetail.ChaiXianShijian = requestForm.ChaiXian;
            projectDetail.IsZhuYuan = requestForm.IsInHospital;
            projectDetail.KangFu = "康复";
            projectDetail.ProjectContent = requestForm.Desc;
            projectDetail.QuanDian = requestForm.BadPoint;
            projectDetail.ShouShu = "手术";
            projectDetail.ShouShuLiaoCheng = requestForm.OperationProcess;
            projectDetail.ShouShuWay = requestForm.OperationWay;
            projectDetail.ShuHouXiuXi = requestForm.HaveRest;
            projectDetail.YouDian = requestForm.GoodPoint;
            projectDetail.ZhiLiao = "治疗";
            projectDetail.ZhiLiaoRenQun = requestForm.FitPersons;
            projectDetail.ZhiLiaoShiChang = requestForm.OperationTimeSpan;
            projectDetail.ZhiLiaoXiaoGuo = requestForm.OperationEffect;

            ProjectService projectService = new ProjectService();
            return projectService.CreateProjectDetail(projectDetail);
        }
    }
}
