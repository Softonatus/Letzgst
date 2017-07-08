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
    /// Summary description for GenerateOTP
    /// </summary>
    public class GenerateOTP : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/json";
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                MakeRequest generateReq = new MakeRequest();

                ReqOtp OTPReq = new ReqOtp();
                OTPReq = generateReq.Deserialize<ReqOtp>(strJson);
                string url = generateReq.generateUrl("SendOtp");

                ResOtp responseOTP = new ResOtp();
                var OTPresponse = MakeRequest.getServiceObject(url, OTPReq, "reqOtp", "POST", typeof(ResOtp));

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