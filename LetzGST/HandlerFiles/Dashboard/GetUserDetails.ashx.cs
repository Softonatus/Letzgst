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
    /// Summary description for GetUserDetails
    /// </summary>
    public class GetUserDetails : IHttpHandler, IRequiresSessionState
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
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        string sessionName = "company_" + context.Request.QueryString["cmp_id"];
                        UserDetails = (ResLogin)context.Session[sessionName];
                    }
                    else
                    {
                        UserDetails = (ResLogin)context.Session["UserDetails"];
                    }

                    ReqListUserCACompany request = new ReqListUserCACompany();
                    if(strJson != "")
                    {
                        request = generateReq.Deserialize<ReqListUserCACompany>(strJson);
                    }
                    if (Convert.ToString(context.Request.QueryString["usertype"]) == null)
                    {
                        if(UserDetails.UserType == 4)
                        {
                            request.ParentId = Convert.ToInt32(UserDetails.UserId);
                        }
                        else
                        {
                            request.ParentId = Convert.ToInt32(UserDetails.ParentId);
                        }                        
                    }
                    else
                    {
                        request.ParentId = Convert.ToInt32(UserDetails.UserId);
                    }    

                    #region User Type
                    /* 1= CA; 3= CA User; */
                    if (UserDetails.UserType != null && (UserDetails.UserType == 1 || UserDetails.UserType == 3))
                    {
                        request.UserType = 3;
                    }
                    else if (UserDetails.UserType != null && (UserDetails.UserType == 2))
                    {
                        // 5 = company user
                        request.UserType = 5;
                    }
                    else if (UserDetails.UserType != null && UserDetails.UserType == 4)
                    {
                        request.UserType = 6;
                    }
                    #endregion
                    string url = generateReq.generateUrl("GetListUserCACompany");
                    ResUserListCACompany resp = new ResUserListCACompany();
                    var response = MakeRequest.getServiceObject(url, request, "reqListUserCACompany", "POST", typeof(ResUserListCACompany));
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