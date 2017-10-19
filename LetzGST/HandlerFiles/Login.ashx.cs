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

namespace LetzGST.HandlerFiles
{
    /// <summary>
    /// Summary description for Login
    /// </summary>
    public class Login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/json";
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                MakeRequest generateReq = new MakeRequest();

                ReqLogin loginRequest = new ReqLogin();
                loginRequest = generateReq.Deserialize<ReqLogin>(strJson);
                string url = generateReq.generateUrl("Login");
                
                var LoginResponse = MakeRequest.getServiceObject(url, loginRequest, "reqLogin", "POST", typeof(ResLogin));
                if (LoginResponse != null)
                {
                    string serRes = JsonConvert.SerializeObject(LoginResponse);
                    ResLogin login = new ResLogin();
                    login = generateReq.Deserialize<ResLogin>(serRes);
                    //login = generateReq.generateDummyLogin();
                    context.Session.Add("UserDetails", login);
                    context.Response.Write(serRes);
                }
                else
                {
                    ResCommon timeOut = new ResCommon();
                    timeOut.ResponseCode = -102;
                    timeOut.ResponseMessage = "No Response from server";
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