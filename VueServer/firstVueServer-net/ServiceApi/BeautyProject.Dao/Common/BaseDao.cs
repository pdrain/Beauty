using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Reflection;


namespace BeautyProject.Dao.Common
{
    public class BaseDao
    {
        protected SqlHelper sqlHelper = new SqlHelper();
        protected List<T> ConvertDataReaderToEntiies<T>(SqlDataReader dataReader)
        {
            List<T> results = new List<T>();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    var entiry = ConvertDataReaderRowToEntity<T>(dataReader);
                    results.Add(entiry);
                }
            }


            return results;
        }

        protected T ConvertDataReaderRowToEntity<T>(SqlDataReader dataReader)
        {
            

            Type type = typeof(T);

            object entity = type.Assembly.CreateInstance(type.FullName);

            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (!property.CanWrite) continue;
                var fieldValue = dataReader[property.Name];

                if (IsType(property.PropertyType, "System.Nullable`1[System.DateTime]"))
                {
                    if (!string.IsNullOrEmpty(fieldValue.ToString()))
                    {
                        property.SetValue(entity, fieldValue, null);
                    }
                    else
                    {
                        property.SetValue(entity, null, null);
                    }

                }
                else if (IsType(property.PropertyType, "System.Nullable`1[System.Int64]"))
                {
                    if (!string.IsNullOrEmpty(fieldValue.ToString()))
                    {
                        property.SetValue(entity, fieldValue, null);
                    }
                    else
                    {
                        property.SetValue(entity, null, null);
                    }

                }
                else if (IsType(property.PropertyType, "System.String"))
                {

                    if (string.IsNullOrEmpty(fieldValue.ToString()))
                    {
                        property.SetValue(entity, string.Empty, null);
                    }
                    else
                    {
                        property.SetValue(entity, fieldValue, null);

                    }
                }
                else if (IsType(property.PropertyType, "System.Double"))
                {
                    if (!string.IsNullOrEmpty(fieldValue.ToString()))
                    {
                        property.SetValue(entity, fieldValue, null);
                    }
                    else
                    {
                        property.SetValue(entity, 0, null);
                    }

                }
                else
                {
                    property.SetValue(entity, fieldValue, null);
                }
            }

            return (T)entity;
        }

        /// <summary>
        /// 类型匹配
        /// </summary>
        /// <param name="type"></param>
        /// <param name="typeName"></param>
        /// <returns></returns>
        private bool IsType(Type type, string typeName)
        {
            if (type.ToString() == typeName)
                return true;
            if (type.ToString() == "System.Object")
                return false;

            return IsType(type.BaseType, typeName);
        }
    }
}