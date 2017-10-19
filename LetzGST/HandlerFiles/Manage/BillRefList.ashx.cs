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

namespace LetzGST.HandlerFiles.Manage
{
    /// <summary>
    /// Summary description for BillRefList
    /// </summary>
    public class BillRefList : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            try
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
                string operType = Convert.ToString(context.Request.QueryString["opertype"]);
                string url = "";
                if (operType == "bill")
                {
                    url = generateReq.generateUrl("GetBillRef");
                }
                else if (operType == "invoice")
                {
                    url = generateReq.generateUrl("GetInvoiceRef");
                }

                ReqUserId request = new ReqUserId();
                if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                {
                    request.UserId = Convert.ToInt32(UserDetails.UserId);
                }
                else
                {
                    request.UserId = Convert.ToInt32(UserDetails.ParentId);
                }
                var Response = MakeRequest.getServiceObject(url, request, "reqUserId", "POST", typeof(ResrefIdList));
                if (Response != null)
                {
                    context.Response.Write(JsonConvert.SerializeObject(Response));
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