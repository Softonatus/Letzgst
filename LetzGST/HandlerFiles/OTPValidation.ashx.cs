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
    /// Summary description for OTPValidation
    /// </summary>
    public class OTPValidation : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/json";
                string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                MakeRequest generateReq = new MakeRequest();

                ReqOtpValidate OTPReqValidate = new ReqOtpValidate();
                OTPReqValidate = generateReq.Deserialize<ReqOtpValidate>(strJson);
                string url = generateReq.generateUrl("ValidateOtp");

                var OTPresponse = MakeRequest.getServiceObject(url, OTPReqValidate, "reqValidateOtp", "POST", typeof(ResCommon));

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