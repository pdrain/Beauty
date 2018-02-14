using BeautyProject.Dao;
using BeautyProjectModes;
using ServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceApi.Service
{
    public class UserService
    {
        private UserDao userDao = new UserDao();

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        public ApiResult Login(string account, string password)
        {
            try
            {

                if (string.IsNullOrEmpty(account)) throw new Exception("登录账号不能为空。");
                if (string.IsNullOrEmpty(password)) throw new Exception("登录密码不能为空。");
                var existUser = this.userDao.GetUserByAccountAndPassword(account, password);

                if (existUser == null) throw new Exception("用户名或密码错误。");

                ApplicationContext.Current.UserId = existUser.ID;
                ApplicationContext.Current.OpenId = existUser.OpenId;
                ApplicationContext.Current.SalesOpenId = existUser.SalesOpenID;
                ApplicationContext.Current.UserHeadImg = existUser.UserHeadImg;

                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public ApiResult Logout()
        {
            try
            {
                ApplicationContext.Current.ClearSession();

                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }


        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="user"></param>
        public ApiResult RegUser(User user, string password2)
        {
            try
            {
                if (string.IsNullOrEmpty(user.Account)) throw new Exception("登录账号不能为空。");
                if (string.IsNullOrEmpty(user.PassWord)) throw new Exception("登录密码不能为空。");
                if (user.PassWord.Length < 6) throw new Exception("密码长度不能少于6位。");

                if (user.PassWord != password2) throw new Exception("两次输入的密码不匹配。");


                var existUser = this.userDao.GetUserByAccount(user.Account);
                if (existUser != null) throw new Exception("用户名已被注册，请尝试其他。");

                user.RegDate = DateTime.Now;
                user.LastLoginTime = DateTime.Now;
                this.userDao.Insert(user);

                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        public ApiResult UpdatePassword(long Id, string password, string password2)
        {
            try
            {
                if (string.IsNullOrEmpty(password)) throw new Exception("登录密码不能为空。");
                if (password.Length < 6) throw new Exception("密码长度不能少于6位。");
                if (password != password2) throw new Exception("两次输入的密码不匹配。");

                var existUser = this.userDao.GetUser(Id);
                existUser.PassWord = password;
                this.userDao.Update(existUser);
                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="user"></param>
        public ApiResult UpdateUserHeadImg(long Id, string imgPath)
        {
            try
            {
                var existUser = this.userDao.GetUser(Id);
                existUser.UserHeadImg = imgPath;
                this.userDao.Update(existUser);

                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }

        /// <summary>
        /// 根据用户ID获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public ApiResult GetUserInfo(long userId)
        {
            try
            {
                var user = this.userDao.GetUser(userId);
                return new ApiResult() { Code = 0, Result = user };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }

        /// <summary>
        /// 根据微信OpenID获取用户信息
        /// </summary>
        /// <param name="openId"></param>
        /// <returns></returns>
        public ApiResult GetUserInfoByOpenId(string openId)
        {
            try
            {
                var user = this.userDao.GetUserByOpenId(openId);
                return new ApiResult() { Code = 0, Result = user };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }

        public ApiResult Upgrade(long userId, int userLever)
        {
            try
            {
                UserDao userDao = new UserDao();
                User user = userDao.GetUser(userId);
                user.TitleType = userLever;
                user.UpdateUser = ApplicationContext.Current.UserId;
                user.UpdateTime = DateTime.Now;
                return new ApiResult() { Code = 0 };
            }
            catch (Exception ex)
            {
                return new ApiResult() { Code = 1, Message = ex.Message };
            }
        }
    }
}