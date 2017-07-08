using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using LetzGST.letzGST_Service;
using LetzGST.Common;

namespace LetzGST.HandlerFiles.Dashboard
{
    /// <summary>
    /// Summary description for Profile
    /// </summary>
    public class Profile : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                //SNServiceClient client = new SNServiceClient();
                //client = client.InsertProfile();
                context.Response.ContentType = "text/json";
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                MakeRequest generateReq = new MakeRequest();

                ReqProfile profileReq = new ReqProfile();
                profileReq = generateReq.Deserialize<ReqProfile>(strJson);
                string url = generateReq.generateUrl("InsertProfile");

                ResCommon responseOTP = new ResCommon();
                var OTPresponse = MakeRequest.getServiceObject(url, profileReq, "reqProfile", "POST", typeof(ResCommon));

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