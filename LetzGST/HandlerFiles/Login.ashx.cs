using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using LetzGST.letzGST_Service;
using LetzGST.Common;

namespace LetzGST.HandlerFiles
{
    /// <summary>
    /// Summary description for Login
    /// </summary>
    public class Login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                //SNServiceClient client = new SNServiceClient();
                //client.Login
                context.Response.ContentType = "text/json";
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                MakeRequest generateReq = new MakeRequest();

                ReqLogin loginRequest = new ReqLogin();
                loginRequest = generateReq.Deserialize<ReqLogin>(strJson);
                string url = generateReq.generateUrl("Login");
                
                var LoginResponse = MakeRequest.getServiceObject(url, loginRequest, "reqLogin", "POST", typeof(ResLogin));

                if (LoginResponse != null)
                {
                    context.Response.Write(JsonConvert.SerializeObject(LoginResponse));
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