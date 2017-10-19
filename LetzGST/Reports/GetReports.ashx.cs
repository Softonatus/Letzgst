using LetzGST.Common;
using LetzGST.letzGST_Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace LetzGST.Reports
{
    /// <summary>
    /// Summary description for GetReports
    /// </summary>
    public class GetReports : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            try
            {
                if (context.Session["UserDetails"] != null)
                {
                    ResLogin UserDetails = new ResLogin();
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        string sessionName = "company_" + context.Request.QueryString["cmp_id"];
                        UserDetails = (ResLogin)context.Session[sessionName];
                    }
                    else
                    {
                        UserDetails = (ResLogin)context.Session["UserDetails"];
                    }

                    MakeRequest generateReq = new MakeRequest();

                    ReqReports request = new ReqReports();
                    

                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    //MakeRequest generateReq = new MakeRequest();

                    //ResBrsList request = new ResBrsList();
                    request = generateReq.Deserialize<ReqReports>(strJson);
                    request.UserId = (int)UserDetails.UserId;
                    ResReportsList resp = new ResReportsList();
                    string url = generateReq.generateUrl("GetReportList");
                    var response = MakeRequest.getServiceObject(url, request, "reqReport", "POST", typeof(ResReportsList));

                    if (response != null)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(response));
                    }
                    else
                    {
                        ResCommon timeOut = new ResCommon();
                        timeOut.ResponseCode = -102;
                        timeOut.ResponseMessage = "No Response from server";
                        context.Response.Write(JsonConvert.SerializeObject(timeOut));
                    }
                }
                else
                {
                    ResCommon timeOut = new ResCommon();
                    timeOut.ResponseCode = -100;
                    timeOut.ResponseMessage = "Session Timed Out";
                    context.Response.Write(JsonConvert.SerializeObject(timeOut));

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {

            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}