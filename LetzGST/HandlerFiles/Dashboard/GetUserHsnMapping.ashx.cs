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
    /// Summary description for GetUserHsnMapping
    /// </summary>
    public class GetUserHsnMapping : IHttpHandler, IRequiresSessionState
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

                    ReqUserId request = new ReqUserId();

                    if (Convert.ToString(context.Request.QueryString["usertype"]) == null)
                    {
                        if (UserDetails.UserType == 4)
                        {
                            request.UserId = (int)UserDetails.UserId;
                        }
                        else
                        {
                            request.UserId = (int)UserDetails.ParentId;
                        }
                       
                    }
                    else
                    {
                        request.UserId = (int)UserDetails.UserId;
                    }
                    

                    ResUserHsnHscCode resp = new ResUserHsnHscCode();
                    string url = generateReq.generateUrl("GetUserHsnHscCode");
                    var response = MakeRequest.getServiceObject(url, request, "reqUserId", "POST", typeof(ResUserHsnHscCode));

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