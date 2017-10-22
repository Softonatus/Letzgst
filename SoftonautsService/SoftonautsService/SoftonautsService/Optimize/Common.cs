using SoftonautsService.CResponse;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SoftonautsService.Optimize
{
    public static class Common<TS,TD>
    {

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="classSerialize"></param>
        /// <param name="classDeSerialize"></param>
        /// <param name="spName"></param>
        /// <returns></returns>
        public static TD Serialize_Deserialize(TS classSerialize, TD classDeSerialize, string spName)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        var classTypeS = classSerialize.GetType();
                        con.Open();
                        return Serialize(classDeSerialize, Deserialize(classTypeS, cmd, classSerialize));
                    }
                }
            }
            catch (Exception ex) { }
            return classDeSerialize;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classTypeS"></param>
        /// <param name="cmd"></param>
        /// <param name="classSerialize"></param>
        /// <returns></returns>
        public static SqlCommand Deserialize(Type classTypeS, SqlCommand cmd, TS classSerialize)
        {
            var classPropertyS = classTypeS.GetProperties();
           
            for (int i = 0; i < classPropertyS.Count(); i++)
            {
                var propertyName = classPropertyS[i].Name;
                if (classPropertyS[i].PropertyType.FullName.Contains(StaticConst.SYSTEMLISTTYPE))
                {

                    DataTable resultDatatable = new DataTable();
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add(propertyName);
                    DataRow row;
                    var listItem = (IEnumerable)classPropertyS[i].GetValue(classSerialize, null);
                    foreach (var item in listItem)
                    {
                        row = dataTable.NewRow();
                        row[propertyName] = item;
                        dataTable.Rows.Add(row);
                    }
                    cmd.Parameters.Add(new SqlParameter(StaticConst.ATTHERATE + propertyName, dataTable));
                }
                else if (classPropertyS[i].PropertyType.FullName.Contains(StaticConst.System))
                {
                    var propertyvalue = classPropertyS[i].GetValue(classSerialize, null);
                    cmd.Parameters.Add(new SqlParameter(StaticConst.ATTHERATE + propertyName, propertyvalue));
                }
                else
                {
                    var checkClassType = Type.GetType(classPropertyS[i].PropertyType.FullName);
                    var checkClassProperties = checkClassType.GetProperties();
                    for (int j = 0; j < checkClassProperties.Count(); j++)
                    {
                        var propertyNamecheckClass = checkClassProperties[j].Name;
                        var propertyvalueCheckClass = checkClassProperties[j].GetValue(checkClassType, null);
                        cmd.Parameters.Add(new SqlParameter(StaticConst.ATTHERATE + propertyName, propertyvalueCheckClass));
                    }
                }
            }

            return cmd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classDeSerialize"></param>
        /// <param name="cmd"></param>
        /// <returns></returns>
        public static TD Serialize(TD classDeSerialize, SqlCommand cmd)
        {
            #region Serialization
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    var classTypeD = classDeSerialize.GetType();
                    var classPropertyD = classTypeD.GetProperties();
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        for (int i = 0; i < classPropertyD.Count(); i++)
                        {
                            try
                            {
                                var propertyName = classPropertyD[i].Name;
                                dynamic value = String.Empty;
                                if (dt.Columns.Contains(propertyName))
                                {
                                    if (String.IsNullOrEmpty(Convert.ToString(dt.Rows[j][propertyName])))
                                        value = String.Empty;
                                    else value = dt.Rows[j][propertyName];
                                    classPropertyD[i].SetValue(classDeSerialize, ((Convert.IsDBNull(dt.Rows[j][propertyName]) ? null : value)), null);
                                }
                                }
                            catch (Exception ex) { }
                            }
                    }
                }
            }
            catch (Exception ex)
            { }

            return classDeSerialize;
            #endregion
        }

     

    }
}


