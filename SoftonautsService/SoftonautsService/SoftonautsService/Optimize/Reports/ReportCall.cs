using Newtonsoft.Json;
using SoftonautsService.CRequest;
using SoftonautsService.CResponse;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SoftonautsService.Optimize.Reports
{
    public class ReportCall
    {
        public static ResReportsList GetReportList(ReqReports reqReport, string spName)
        {
            ResReportsList resReportsList = new ResReportsList();
            ResReports ResReports = new ResReports();
            List<ResReports> _resReportsList = new List<ResReports>();
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(StaticConst.connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, con))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.Add(new SqlParameter("@UserId", reqReport.UserId));
                        cmd.Parameters.Add(new SqlParameter("@tableName", reqReport.tableName));
                        cmd.Parameters.Add(new SqlParameter("@StartDate", reqReport.StartDate));
                        cmd.Parameters.Add(new SqlParameter("@EndDate", reqReport.EndDate));
                        cmd.Parameters.Add(new SqlParameter("@VendorCustomerId", reqReport.VendorCustomerId));
                        cmd.Parameters.Add(new SqlParameter("@CurrentUserId", reqReport.CurrentUserId));
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                string JSONString = string.Empty;
                                JSONString = JsonConvert.SerializeObject(dt);
                                _resReportsList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ResReports>>(JSONString);
                                resReportsList.resReportsList = _resReportsList;

                                resReportsList.ResponseCode = 0;
                                resReportsList.ResponseMessage = "Detail fetched successfully";
                            }
                            else
                            {
                                resReportsList.ResponseCode = 0;
                                resReportsList.ResponseMessage = "No Records Found";
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

            }

            return resReportsList;
        }

    }
}