using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using LetzGST.letzGST_Service;
using LetzGST.Common;

namespace LetzGST.Handlers
{
    /// <summary>
    /// Summary description for Registration
    /// </summary>
    public class Registration : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           try
            {
                context.Response.ContentType = "text/json";
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                MakeRequest generateReq = new MakeRequest();

                ReqRegistration regRequest = new ReqRegistration();
                //deserialize the object
                regRequest = generateReq.Deserialize<ReqRegistration>(strJson);
                regRequest.UserType = 1;
                regRequest.RegisteredDate = DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss");
                regRequest.ExpiryDate = DateTime.Now.AddDays(30).ToString("yyyy-MM-dd HH':'mm':'ss");
                regRequest.IsActive = false;
                string url = generateReq.generateUrl("Registration");
                ResRegistration regResponse = new ResRegistration();
                var response = MakeRequest.getServiceObject(url, regRequest, "reqRegistration", "POST", typeof(ResRegistration));

                

                //regResponse = client.Registration(regRequest);
                if (regResponse != null)
                {
                    context.Response.Write(JsonConvert.SerializeObject(response));
                }
                else
                {
                    context.Response.Write("No Data");
                }
            }
            catch(Exception ex)
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