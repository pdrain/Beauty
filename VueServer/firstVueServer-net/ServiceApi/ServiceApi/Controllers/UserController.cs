using BeautyProjectModes;
using ServiceApi.Common;
using ServiceApi.Controllers.RequestBody;
using ServiceApi.Models;
using ServiceApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ServiceApi.Controllers
{

    public class UserController : ApiController
    {

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        [HttpPost]
        public ApiResult Login(LoginRequestForm requestForm)
        {  
            UserService userService = new UserService();
            return userService.Login(requestForm.Account, requestForm.Password);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        [HttpGet]
        public ApiResult Logout()
        {
            UserService userService = new UserService();
            return userService.Logout();
        }


        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public ApiResult RegUser(RegUserRequestForm requestForm)
        {
            UserService userService = new UserService();
            User user = new User();
            user.OpenId = Convert.ToString(requestForm.OpenId);
            user.Account = Convert.ToString(requestForm.Account);
            user.PassWord = Convert.ToString(requestForm.Password);
            return userService.RegUser(user, requestForm.Password2);
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public ApiResult UpdatePassword(UpdatePasswordForm requestForm)
        {
            UserService userService = new UserService();
            return userService.UpdatePassword(requestForm.ID, requestForm.Password, requestForm.Password2);
        }

        /// <summary>
        /// 修改用户头像
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public ApiResult UpdateUserHeadImg(UpdateUserHeadImgForm requestForm)
        {
            UserService userService = new UserService();
            return userService.UpdateUserHeadImg(requestForm.ID, requestForm.ImagePath);
        }

        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult GetUserInfo(GetUserInfoForm requestForm)
        {
            UserService userService = new UserService();
            return userService.GetUserInfo(requestForm.ID);
        }

        /// <summary>
        /// 根据微信OpenID获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult GetUserInfoByOpenId(GetUserInfoByOpenIdForm requestForm)
        {
            UserService userService = new UserService();
            return userService.GetUserInfoByOpenId(requestForm.OpenID);
        }

        /// <summary>
        /// 业务员申请升级
        /// </summary>
        /// <param name="postdata"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult Upgrade(SalesUpgradeForm requestForm)
        {
            UserService userService = new UserService();
            return userService.Upgrade(requestForm.UserID, requestForm.Lever);
        }

    }
}
