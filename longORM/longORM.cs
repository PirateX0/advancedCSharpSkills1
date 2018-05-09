using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MySql.Data.MySqlClient;
using System.Data;
using longLibrary;

namespace LongORM
{
    /// <summary>
    /// 约定：
    /// 1、主键id，且id自增
    /// 2、类名和表名对应，属性和列名对应
    /// </summary>
    class LongORM
    {
        //old写法
        //public static int Insert(object o)
        //{
        //    //insert into Person(Name,Age) values(@Name,@age)
        //    StringBuilder sb = new StringBuilder();
        //    Type t = o.GetType();
        //    PropertyInfo[] pros = t.GetProperties();
        //    string[] propNames = new string[pros.Length - 1];
        //    string[] propNameParameters = new string[pros.Length - 1];
        //    MySqlParameter[] parameters = new MySqlParameter[pros.Length - 1];
        //    //去掉id属性
        //    int count = 0;
        //    foreach (PropertyInfo pro in pros)
        //    {
        //        if (pro.Name != "Id")
        //        {
        //            propNames[count] = pro.Name;
        //            propNameParameters[count] = "@" + pro.Name;

        //            MySqlParameter parameter = new MySqlParameter();
        //            parameter.ParameterName = "@" + pro.Name;
        //            parameter.Value = pro.GetValue(o);
        //            parameters[count] = parameter;

        //            count++;
        //        }
        //    }
        //    sb.Append("insert into " + t.Name + "(" + string.Join(",", propNames) + ")")
        //        .Append(" values(" + string.Join(",", propNameParameters) + ")");

        //   return longLibrary.MySqlHelper.ExecuteNonQuery(sb.ToString(), parameters);
        //}

        public static int Insert(object o)
        {
            //insert into Person(Name,Age) values(@Name,@age)
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(@"insert into {0}({1}) values({2})",GetTableName(o),GetPart1ForInsert(o),GetPart2ForInsert(o));
            return longLibrary.MySqlHelper.ExecuteNonQuery(sb.ToString(), GetMySqlParametersForInsert(o));
        }

        public static string GetTableName(object o)
        {
            return o.GetType().Name;
        }

        //返回格式：Name,Age
        public static string GetPart1ForInsert(object o)
        {
            Type t = o.GetType();
            PropertyInfo[] propertyListExceptId = t.GetProperties().Where(x=>!x.Name.ToLower().Contains("id")).ToArray<PropertyInfo>();
            List<string> prosExceptId = propertyListExceptId.Select(x => x.Name).ToList<string>();
            return string.Join(",", prosExceptId);
        }

        //返回格式：@Name,@age
        public static string GetPart2ForInsert(object o)
        {
            Type t = o.GetType();
            PropertyInfo[] propertyListExceptId = t.GetProperties().Where(x => !x.Name.ToLower().Contains("id")).ToArray<PropertyInfo>();
            List<string> prosExceptId = propertyListExceptId.Select(x => "@"+x.Name).ToList<string>();
            return string.Join(",", prosExceptId);
        }

        public static MySqlParameter[] GetMySqlParametersForInsert(object o)
        {
            Type t = o.GetType();
            PropertyInfo[] propertyListExceptId = t.GetProperties().Where(x => !x.Name.ToLower().Contains("id")).ToArray<PropertyInfo>();
            MySqlParameter[] parameters = new MySqlParameter[propertyListExceptId.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@" + propertyListExceptId[i].Name;
                parameter.Value = propertyListExceptId[i].GetValue(o);

                parameters[i] = parameter;
            }
            return parameters;
        }

        public static T SelectById<T>(int Id) where T : new()
        {
            //使用参数化查询

            //select * from Person where Id=@Id
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from " + typeof(T).Name + " where Id=@Id");
            DataTable table = longLibrary.MySqlHelper.ExecuteQuery(sb.ToString(), new MySqlParameter { ParameterName = "Id", Value = Id });
            if (table.Rows.Count <= 0)
            {
                return default(T);
            }
            DataRow row = table.Rows[0];
            T t = new T();
            PropertyInfo[] pros = typeof(T).GetProperties();
            foreach (PropertyInfo pro in pros)
            {
                pro.SetValue(t, row[pro.Name]);
            }
            return t;
        }
        public static int DeleteById<T>(int Id)
        {
            //delete from Person where Id=@Id
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from " + typeof(T).Name + " where Id=@Id");
            return longLibrary.MySqlHelper.ExecuteNonQuery(sb.ToString(), new MySqlParameter("Id", Id));
        }

        //old写法
        //public static int Update(object o)
        //{
        //    //update person  set name=@name,age=@age where id=@id
        //    StringBuilder sb = new StringBuilder();
        //    Type t = o.GetType();
        //    PropertyInfo[] pros = t.GetProperties();
        //    string[] strs = new string[pros.Length - 1];
        //    MySqlParameter[] parameters=new MySqlParameter[pros.Length];
        //    int Id;
        //    int count = 0;
        //    int Allcount=0;
        //    foreach (PropertyInfo pro in pros)
        //    {
        //        if (pro.Name == "Id")
        //        {
        //            Id = int.Parse(pro.GetValue(o).ToString());
        //            MySqlParameter parameter = new MySqlParameter();
        //            parameter.ParameterName = "Id";
        //            parameter.Value = Id;
        //            parameters[Allcount] = parameter;
        //            Allcount++;
        //            continue;
        //        }
        //        strs[count] = pro.Name + "=@" + pro.Name;
        //        MySqlParameter parameter2 = new MySqlParameter();
        //        parameter2.ParameterName = pro.Name;
        //        parameter2.Value = pro.GetValue(o);
        //        parameters[Allcount] = parameter2;
        //        count++;
        //        Allcount++;
        //    }
        //    sb.Append("update " + t.Name + " set ");
        //    sb.Append(string.Join(",", strs) + " where id=@id");

        //    return longLibrary.MySqlHelper.ExecuteNonQuery(sb.ToString(),parameters);
        //}

        public static int Update(object o)
        {
            //update person  set name=@name,age=@age where id=@id
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("update {0} set {1} where id=@id",GetTableName(o),GetPartForUpdate(o));
            return longLibrary.MySqlHelper.ExecuteNonQuery(sb.ToString(), GetMySqlParametersFoUpdate(o));
        }

        //返回格式：name=@name,age=@age
        public static string GetPartForUpdate(object o)
        {
            Type t = o.GetType();
            PropertyInfo[] propertyListExceptId = t.GetProperties().Where(x => !x.Name.ToLower().Contains("id")).ToArray<PropertyInfo>();
            List<string> prosExceptId = propertyListExceptId.Select(x => x.Name+"="+"@" + x.Name).ToList<string>();
            return string.Join(",", prosExceptId);
        }

        public static MySqlParameter[] GetMySqlParametersFoUpdate(object o)
        {
            Type t = o.GetType();
            PropertyInfo[] props = t.GetProperties();
            MySqlParameter[] parameters = new MySqlParameter[props.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                MySqlParameter parameter = new MySqlParameter();
                parameter.ParameterName = "@" + props[i].Name;
                parameter.Value = props[i].GetValue(o);

                parameters[i] = parameter;
            }
            return parameters;
        }
    }
}
