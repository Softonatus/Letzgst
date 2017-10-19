using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using LetzGST.letzGST_Service;
using LetzGST.Common;
using System.Web.SessionState;

namespace LetzGST.HandlerFiles.Dashboard
{
    /// <summary>
    /// Summary description for CreateCompanySession
    /// </summary>
    public class CreateCompanySession : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            try
            {
                // string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                int UserId = Convert.ToInt32(context.Request.QueryString["userId"]);
                ResLogin UserDetails = new ResLogin();
                ResLogin CompanyDetails = new ResLogin();
                if (context.Session["UserDetails"] != null)
                {
                    UserDetails = (ResLogin)context.Session["UserDetails"];
                    string _Cmpname = "company_"+ UserId;
                    CompanyDetails.ParentId = UserDetails.ParentId;
                    CompanyDetails.UserId = UserId;
                    CompanyDetails.UserRoleAuth = null;
                    CompanyDetails.UserType = 4;

                    ReqUserId fetchprofile = new ReqUserId();
                    fetchprofile.UserId = Convert.ToInt32(UserId);
                    MakeRequest generateReq = new MakeRequest();
                    string url = generateReq.generateUrl("GetProfile");
                    var resProfileDetails = MakeRequest.getServiceObject(url, fetchprofile, "reqUserId", "POST", typeof(ResProfile));
                    ResProfile profDetails = new ResProfile();
                    profDetails = (ResProfile)resProfileDetails;
                    string redirect = "profile";
                    if(profDetails.PanNo != null)
                    {
                        CompanyDetails.ResponseCode = 0;
                        redirect = "dashboard";
                    }

                    context.Session.Add(_Cmpname, CompanyDetails);

                    ResCommon sessionCreate = new ResCommon();
                    sessionCreate.ResponseCode = 0;
                    sessionCreate.ResponseMessage = redirect;
                    context.Response.Write(JsonConvert.SerializeObject(sessionCreate));
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