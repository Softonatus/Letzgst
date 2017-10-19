using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.SessionState;
using LetzGST.letzGST_Service;
using LetzGST.Common;
using Newtonsoft.Json;

namespace LetzGST.HandlerFiles
{
    /// <summary>
    /// Summary description for UploadLogo
    /// </summary>
    public class UploadLogo : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
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
               // string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                MakeRequest generateReq = new MakeRequest();
                ReqUpdateLogo updateLogo = new ReqUpdateLogo();
                //updateLogo = generateReq.Deserialize<ReqUpdateLogo>(strJson);
                string logoUrl = Convert.ToString(context.Request.QueryString["fName"]);
                updateLogo.UserId = UserDetails.UserId;
                updateLogo.LogoUrl = logoUrl;

                string url = generateReq.generateUrl("UpdateLogo");
                var resUpdateLogo = MakeRequest.getServiceObject(url, updateLogo, "reqUpdateLogo", "POST", typeof(ResCommon));
                if (resUpdateLogo != null)
                {
                    UserDetails.LogoUrl = logoUrl;                                        
                    context.Response.Write(JsonConvert.SerializeObject(resUpdateLogo));
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}