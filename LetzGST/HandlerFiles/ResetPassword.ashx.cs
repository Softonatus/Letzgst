using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using LetzGST.letzGST_Service;
using LetzGST.Common;

namespace LetzGST.HandlerFiles
{
    /// <summary>
    /// Summary description for ResetPassword
    /// </summary>
    public class ResetPassword : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/json";
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                MakeRequest generateReq = new MakeRequest();

                ReqUpdatePassword ReqUpdatePwd = new ReqUpdatePassword();
                ReqUpdatePwd = generateReq.Deserialize<ReqUpdatePassword>(strJson);

                if (Convert.ToString(context.Request.QueryString["type"]) != null)
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
                        ReqUpdatePwd.UserId = UserDetails.UserId;
                    }
                }
                string url = generateReq.generateUrl("UpdatePassword");

                ResCommon responseOTP = new ResCommon();
                var OTPresponse = MakeRequest.getServiceObject(url, ReqUpdatePwd, "reqUpdatePassword", "POST", typeof(ResCommon));

                if (OTPresponse != null)
                {
                    context.Response.Write(JsonConvert.SerializeObject(OTPresponse));
                }
                else
                {
                    context.Response.Write("No Data");
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