using LetzGST.Common;
using LetzGST.letzGST_Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace LetzGST.HandlerFiles.Manage
{
    /// <summary>
    /// Summary description for InsertBrsPayment
    /// </summary>
    public class InsertBrsPayment : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            bool isInsert = false;
            try
            {
                if (context.Session["UserDetails"] != null)
                {
                    ResLogin UserDetails = new ResLogin();
                    MakeRequest generateReq = new MakeRequest();

                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        string sessionName = "company_" + context.Request.QueryString["cmp_id"];
                        UserDetails = (ResLogin)context.Session[sessionName];
                    }
                    else
                    {
                        UserDetails = (ResLogin)context.Session["UserDetails"];
                    }
                    string url = "";
                    if (Convert.ToString(context.Request.QueryString["insertType"]).ToLower() == "insert")
                    {
                        url = generateReq.generateUrl("InsertBrsPayment");
                        isInsert = true;
                    }
                    else
                    {
                        url = generateReq.generateUrl("UpdateBrsPayment");
                    }
                    

                     
                    ReqBrsPaymentList request = new ReqBrsPaymentList();
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    request = generateReq.Deserialize<ReqBrsPaymentList>(strJson);
                    var vendorResponse = MakeRequest.getServiceObject(url, request, isInsert ? "reqBrsPayment": "reqUpdateBrsPayment", "POST", typeof(ResCommon));
                    if (vendorResponse != null)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(vendorResponse));
                    }
                    else
                    {
                        ResCommon timeOut = new ResCommon();
                        timeOut.ResponseCode = -102;
                        timeOut.ResponseMessage = "No Response from server";
                        context.Response.Write(JsonConvert.SerializeObject(timeOut));
                    }

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