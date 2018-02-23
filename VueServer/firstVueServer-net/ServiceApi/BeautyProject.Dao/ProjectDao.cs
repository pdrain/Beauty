using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeautyProject.Dao.Common;
using BeautyProjectModes;
using System.Data.SqlClient;
using System.Data;

namespace BeautyProject.Dao
{
    public class ProjectDao : BaseDao
    {
        public void ClearData()
        {
            try
            {
                string sql = "delete from ProjectCat";
                sqlHelper.ExecuteScalar(CommandType.Text, sql);

                sql = "delete from ProjectDetail";
                sqlHelper.ExecuteScalar(CommandType.Text, sql);

            }
            catch (Exception ex)
            {
                throw new Exception("清除数据失败");
            }
        }

        public void Insert(ProjectCat project)
        {
            try
            {
                string sql = @"insert into ProjectCat 
                           (Guid, ParentGuid, Name, Icon, DisplayOrder, Description, Keywords, ComplexRate, SafetyRate, FocusRate) 
                           values 
                           (@Guid, @ParentGuid, @Name, @Icon, @DisplayOrder, @Description, @Keywords, @ComplexRate, @SafetyRate, @FocusRate)";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "Guid", Value = project.Guid });
                parameters.Add(new SqlParameter() { ParameterName = "ParentGuid", Value = project.ParentGuid ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "Name", Value = project.Name ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "Icon", Value = project.Icon ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "DisplayOrder", Value = project.DisplayOrder });
                parameters.Add(new SqlParameter() { ParameterName = "Description", Value = project.Description ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "Keywords", Value = project.Keywords ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ComplexRate", Value = project.ComplexRate });
                parameters.Add(new SqlParameter() { ParameterName = "SafetyRate", Value = project.SafetyRate });
                parameters.Add(new SqlParameter() { ParameterName = "FocusRate", Value = project.FocusRate });

                sqlHelper.ExecuteScalar(CommandType.Text, sql, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("插入项目目录失败；guid:{0},name:{1}", project.Guid, project.Name));
            }


        }

        public void Update(ProjectCat project)
        {
            try
            {
                string sql = @"update  ProjectCat  set
                           Guid=@Guid, ParentGuid=@ParentGuid, Name=@Name, Icon=@Icon, DisplayOrder=@DisplayOrder, Description=@Description, 
                            Keywords=@Keywords, ComplexRate=@ComplexRate, SafetyRate=@SafetyRate, FocusRate=@FocusRate
                            where ID=@ID";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "Guid", Value = project.Guid });
                parameters.Add(new SqlParameter() { ParameterName = "ParentGuid", Value = project.ParentGuid ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "Name", Value = project.Name ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "Icon", Value = project.Icon ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "DisplayOrder", Value = project.DisplayOrder });
                parameters.Add(new SqlParameter() { ParameterName = "Description", Value = project.Description ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "Keywords", Value = project.Keywords ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ComplexRate", Value = project.ComplexRate });
                parameters.Add(new SqlParameter() { ParameterName = "SafetyRate", Value = project.SafetyRate });
                parameters.Add(new SqlParameter() { ParameterName = "FocusRate", Value = project.FocusRate });
                parameters.Add(new SqlParameter() { ParameterName = "ID", Value = project.ID });

                sqlHelper.ExecuteScalar(CommandType.Text, sql, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("插入项目目录失败；guid:{0},name:{1}", project.Guid, project.Name));
            }


        }

        public List<ProjectCat> GetProjectCats()
        {
            string sql = "select *  from ProjectCat";
            var dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql);
            return base.ConvertDataReaderToEntiies<ProjectCat>(dataReader);
        }
        public List<ProjectCat> GetProjectCatByParentId(string parentGuid)
        {
            string sql = "select *  from ProjectCat where ParentGuid=@ParentGuid";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { ParameterName = "ParentGuid", Value = parentGuid ?? string.Empty });
            var dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());

            if (dataReader.HasRows)
            {
                dataReader.Read();
                return base.ConvertDataReaderToEntiies<ProjectCat>(dataReader);
            }
            else
            {
                return new List<ProjectCat>();
            }
        }

        public ProjectCat GetProjectCatById(string guid)
        {
            string sql = "select *  from ProjectCat where Guid=@Guid";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter() { ParameterName = "Guid", Value = guid ?? string.Empty });
            var dataReader = sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());
            if (dataReader.HasRows)
            {
                dataReader.Read();
                return base.ConvertDataReaderRowToEntity<ProjectCat>(dataReader);
            }
            else
            {
                return new ProjectCat();
            }
        }

        public void InsertDetail(ProjectDetail detail)
        {
            try
            {
                string sql = @"insert into ProjectDetail 
                           (CatGuid, ProjectContent, Price, ShouShu, ShouShuWay, ShouShuLiaoCheng, ZhiLiao, ZhiLiaoRenQun, ZhiLiaoXiaoGuo, ZhiLiaoShiChang, KangFu, ChaiXianShijian, IsZhuYuan, ShuHouXiuXi, YouDian, QuanDian, CreateTime) 
                           values 
                           (@CatGuid, @ProjectContent, @Price, @ShouShu, @ShouShuWay, @ShouShuLiaoCheng, @ZhiLiao, @ZhiLiaoRenQun, @ZhiLiaoXiaoGuo, @ZhiLiaoShiChang, @KangFu, @ChaiXianShijian, @IsZhuYuan, @ShuHouXiuXi, @YouDian, @QuanDian, @CreateTime)";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "CatGuid", Value = detail.CatGuid });
                parameters.Add(new SqlParameter() { ParameterName = "ProjectContent", Value = detail.ProjectContent ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "Price", Value = detail.Price ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ShouShu", Value = detail.ShouShu ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ShouShuWay", Value = detail.ShouShuWay ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ShouShuLiaoCheng", Value = detail.ShouShuLiaoCheng ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ZhiLiao", Value = detail.ZhiLiao ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ZhiLiaoRenQun", Value = detail.ZhiLiaoRenQun ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ZhiLiaoXiaoGuo", Value = detail.ZhiLiaoXiaoGuo ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ZhiLiaoShiChang", Value = detail.ZhiLiaoShiChang ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "KangFu", Value = detail.KangFu ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "IsZhuYuan", Value = detail.IsZhuYuan ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ChaiXianShijian", Value = detail.ChaiXianShijian ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ShuHouXiuXi", Value = detail.ShuHouXiuXi ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "YouDian", Value = detail.YouDian ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "QuanDian", Value = detail.QuanDian ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "CreateTime", Value = detail.CreateTime });

                sqlHelper.ExecuteScalar(CommandType.Text, sql, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("插入项目目录失败；guid:{0}", detail.CatGuid));
            }


        }

        public void UpdateDetail(ProjectDetail detail)
        {
            try
            {
                string sql = @"update  ProjectDetail  set 
                           CatGuid=@CatGuid, ProjectContent=@ProjectContent, Price=@Price, ShouShu=@ShouShu, ShouShuWay=@ShouShuWay, ShouShuLiaoCheng=@ShouShuLiaoCheng, 
                            ZhiLiao=@ZhiLiao, ZhiLiaoRenQun=@ZhiLiaoRenQun, ZhiLiaoXiaoGuo=@ZhiLiaoXiaoGuo, ZhiLiaoShiChang=@ZhiLiaoShiChang, KangFu=@KangFu,
                            ChaiXianShijian=@ChaiXianShijian, IsZhuYuan=@IsZhuYuan, ShuHouXiuXi=@ShuHouXiuXi, YouDian=@YouDian, QuanDian=@QuanDian, CreateTime=@CreateTime  
                            where ID=@ID";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "CatGuid", Value = detail.CatGuid });
                parameters.Add(new SqlParameter() { ParameterName = "ProjectContent", Value = detail.ProjectContent ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "Price", Value = detail.Price ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ShouShu", Value = detail.ShouShu ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ShouShuWay", Value = detail.ShouShuWay ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ShouShuLiaoCheng", Value = detail.ShouShuLiaoCheng ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ZhiLiao", Value = detail.ZhiLiao ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ZhiLiaoRenQun", Value = detail.ZhiLiaoRenQun ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ZhiLiaoXiaoGuo", Value = detail.ZhiLiaoXiaoGuo ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ZhiLiaoShiChang", Value = detail.ZhiLiaoShiChang ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "KangFu", Value = detail.KangFu ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "IsZhuYuan", Value = detail.IsZhuYuan ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ChaiXianShijian", Value = detail.ChaiXianShijian ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "ShuHouXiuXi", Value = detail.ShuHouXiuXi ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "YouDian", Value = detail.YouDian ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "QuanDian", Value = detail.QuanDian ?? string.Empty });
                parameters.Add(new SqlParameter() { ParameterName = "CreateTime", Value = detail.CreateTime });
                parameters.Add(new SqlParameter() { ParameterName = "ID", Value = detail.ID });

                sqlHelper.ExecuteScalar(CommandType.Text, sql, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("插入项目目录失败；guid:{0}", detail.CatGuid));
            }
        }
        
        public ProjectDetail GetProjectDetail(int id)
        {
            try
            {
                string sql = "select * from ProjectDetail where ID=@ID";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "ID", Value = id });
                SqlDataReader dataReader = base.sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    return base.ConvertDataReaderRowToEntity<ProjectDetail>(dataReader);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("获取项目失败。");

            }
        }

        public List<ProjectDetail> GetProjectDetailList(string guid)
        {
            try
            {
                string sql = "select * from ProjectDetail where CatGuid=@CatGuid";

                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter() { ParameterName = "CatGuid", Value = guid });
                SqlDataReader dataReader = base.sqlHelper.ExecuteReader(CommandType.Text, sql, parameters.ToArray());
               
                    return base.ConvertDataReaderToEntiies<ProjectDetail>(dataReader);
                
            }
            catch (Exception ex)
            {
                throw new Exception("获取项目失败。");

            }
        }
    }
}
