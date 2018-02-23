using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApi.Controllers.RequestBody
{
    /// <summary>
    /// 获取项目目录分类
    /// </summary>
    public class GetProjectCatTypeRequestForm : RequestBodyForm
    {
        public string Guid { get; set; }
    }

    /// <summary>
    /// 新增项目分类请求参数
    /// </summary>
    public class AddProjectCatTypeRequestForm : RequestBodyForm
    {
        public string ParentGuid { get; set; }
        public string Name { get; set; }
    }
    /// <summary>
    /// 更新项目分类请求参数
    /// </summary>
    public class UpdateProjectCatTypeRequestForm : RequestBodyForm
    {
        public string Guid { get; set; }
        public string Name { get; set; }
    }


    /// <summary>
    /// 获取项目列表请求参数
    /// </summary>
    public class GetProjectDetailListRequestForm : RequestBodyForm
    {
        public string CatGuid { get; set; }
    }

    /// <summary>
    /// 获取项目详情请求参数
    /// </summary>
    public class GetProjectDetailRequestForm : RequestBodyForm
    {
        public int Id { get; set; }
    }




    /// <summary>
    /// 更新项目详情请求参数
    /// </summary>
    public class UpdateProjectDetailRequestForm : RequestBodyForm
    {
        public int Id { get; set; }
    }

    /// <summary>
    /// 更新项目详情请求参数
    /// </summary>
    public class AddProjectDetailRequestForm : RequestBodyForm
    {
        public string ParentCat { get; set; }                  //目录分类
        public string Name { get; set; }                          //名称
        public string Desc { get; set; }                          //描述
        public string OperationWay { get; set; }                  //手术手段（方式）
        public string OperationProcess { get; set; }              //手术过程
        public string FitPersons { get; set; }                    //适宜人群
        public string OperationTimeSpan { get; set; }             //治疗时长
        public string OperationEffect { get; set; }               //手术效果
        public string ChaiXian { get; set; }                      //拆线说明
        public string HaveRest { get; set; }                      //术后休息
        public string IsInHospital { get; set; }                  //是否住院
        public string GoodPoint { get; set; }                     //优点
        public string BadPoint { get; set; }                      //缺点

    }


}