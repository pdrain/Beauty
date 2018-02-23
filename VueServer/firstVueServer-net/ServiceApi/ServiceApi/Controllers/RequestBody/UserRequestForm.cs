using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApi.Controllers.RequestBody
{
    /// <summary>
    /// 登录
    /// </summary>
    public class LoginRequestForm : RequestBodyForm
    {
        public string Account { get; set; }

        public string Password { get; set; }
    }

    /// <summary>
    /// 注册
    /// </summary>
    public class RegUserRequestForm : RequestBodyForm
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string OpenId { get; set; }
        
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    public class UpdatePasswordForm : RequestBodyForm
    {
        public int ID { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
    }
    /// <summary>
    /// 修改用户头像
    /// </summary>
    public class UpdateUserHeadImgForm : RequestBodyForm
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
    }
    /// <summary>
    /// 根据ID获取用户信息
    /// </summary>
    public class GetUserInfoForm : RequestBodyForm
    {
        public int ID { get; set; }
    }

    /// <summary>
    /// 根据微信OpenID获取用户信息
    /// </summary>
    public class GetUserInfoByOpenIdForm : RequestBodyForm
    {
        public string OpenID { get; set; }
    }

    /// <summary>
    /// 根据微信OpenID获取用户信息
    /// </summary>
    public class SalesUpgradeForm : RequestBodyForm
    {
        public int UserID { get; set; }

        public int Lever { get; set; }
    }
    
    
    
    
}