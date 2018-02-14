using BeautyProject.Dao.Common;
using BeautyProjectModes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace BeautyProject.Dao
{
    public class UserDao : BaseDao
    {
        public void Insert(User user)
        {
            try
            {
                string sql = "insert into UserInfo (OpenId, UserHeadImg, Account, Password, TitleType, RegDate, LastLoginTime, ParentId) " +
                             "   values " +
                             " (@OpenId, @UserHeadImg, @Account, @Password, @TitleType, @RegDate, @LastLoginTime, @ParentId)";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "OpenId", Value = user.OpenId });
                parameters.Add(new SqlParameter() { ParameterName = "UserHeadImg", Value = user.UserHeadImg ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "Account", Value = user.Account ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "PassWord", Value = user.PassWord ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "RegDate", Value = user.RegDate });
                parameters.Add(new SqlParameter() { ParameterName = "LastLoginTime", Value = user.LastLoginTime });
                parameters.Add(new SqlParameter() { ParameterName = "TitleType", Value = user.TitleType });
                parameters.Add(new SqlParameter() { ParameterName = "ParentId", Value = user.ParentId });

                sqlHelper.ExecuteScalar(CommandType.Text, sql, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("插入用户信息失败");
            }
        }

        public void Update(User user)
        {
            try
            {
                string sql = "update UserInfo  set UserHeadImg=@UserHeadImg, Account=@Account, Password=@Password, TitleType=@TitleType, RegDate=@RegDate, LastLoginTime=@LastLoginTime, ParentId=@ParentId,UpdateUser=@UpdateUser,UpdateTime=@UpdateTime " +
                                "  where ID=@ID ";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "OpenId", Value = user.OpenId });
                parameters.Add(new SqlParameter() { ParameterName = "UserHeadImg", Value = user.UserHeadImg ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "Account", Value = user.Account ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "PassWord", Value = user.PassWord ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "RegDate", Value = user.RegDate });
                parameters.Add(new SqlParameter() { ParameterName = "LastLoginTime", Value = user.LastLoginTime });
                parameters.Add(new SqlParameter() { ParameterName = "TitleType", Value = user.TitleType });
                parameters.Add(new SqlParameter() { ParameterName = "ParentId", Value = user.ParentId });
                parameters.Add(new SqlParameter() { ParameterName = "UpdateTime", Value = user.UpdateTime });
                parameters.Add(new SqlParameter() { ParameterName = "UpdateUser", Value = user.UpdateUser });
                parameters.Add(new SqlParameter() { ParameterName = "ID", Value = user.ID });

                sqlHelper.ExecuteScalar(CommandType.Text, sql, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception("更新用户信息失败");
            }
        }

        public User GetUser(long id)
        {
            try
            {
                var sql = "select * from UserInfo where ID=@ID";
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter() { ParameterName = "ID", Value = id });

                var dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    return base.ConvertDataReaderRowToEntity<User>(dataReader);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("查询用户信息失败");
            }
        }

        public User GetUserByOpenId(string openId)
        {
            try
            {
                var sql = "select * from UserInfo where OpenId=@OpenId";
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter() { ParameterName = "OpenId", Value = openId });

                var dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    return base.ConvertDataReaderRowToEntity<User>(dataReader);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("查询用户信息失败");
            }
        }

        public User GetUserByAccount(string account)
        {
            try
            {
                var sql = "select * from UserInfo where Account=@Account";
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter() { ParameterName = "Account", Value = account });

                var dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    return base.ConvertDataReaderRowToEntity<User>(dataReader);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("查询用户信息失败");
            }
        }

        public User GetUserByAccountAndPassword(string account,string password)
        {
            try
            {
                var sql = "select * from UserInfo where Account=@Account and Password=@Password";
                List<SqlParameter> parameters = new List<SqlParameter>();

                parameters.Add(new SqlParameter() { ParameterName = "Account", Value = account });
                parameters.Add(new SqlParameter() { ParameterName = "Password", Value = password });

                var dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());

                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    return base.ConvertDataReaderRowToEntity<User>(dataReader);
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("查询用户信息失败");
            }
        }

    }
}
