using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LetzGST.letzGST_Service;
using LetzGST.Common;
using System.Web.SessionState;
using System.IO;
using Newtonsoft.Json;

namespace LetzGST.HandlerFiles.Dashboard
{
    /// <summary>
    /// Summary description for GetClientDetails
    /// </summary>
    public class GetClientDetails : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/json";
                if (context.Session["UserDetails"] != null)
                {
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    MakeRequest generateReq = new MakeRequest();

                    ResLogin UserDetails = new ResLogin();
                    UserDetails = (ResLogin)context.Session["UserDetails"];

                    ReqUserId request = new ReqUserId();
                    if (strJson != "")
                    {
                        request = generateReq.Deserialize<ReqUserId>(strJson);
                    }
                    request.UserId = (int)UserDetails.ParentId;

                    string url = generateReq.generateUrl("GetListCACompany");
                    ResCompanyListCA resp = new ResCompanyListCA();
                    var response = MakeRequest.getServiceObject(url, request, "reqParentId", "POST", typeof(ResCompanyListCA));
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