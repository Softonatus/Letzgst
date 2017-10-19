using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using LetzGST.letzGST_Service;
using LetzGST.Common;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace LetzGST.HandlerFiles.Manage
{
    /// <summary>
    /// Summary description for manageCustomers
    /// </summary>
    public class manageCustomers : IHttpHandler, IRequiresSessionState
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
                if (operType == "get")
                {
                    string url = generateReq.generateUrl("GetCustomerList");
                    ReqUserId request = new ReqUserId();
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        request.UserId = Convert.ToInt32(UserDetails.UserId);
                    }
                    else
                    {
                        request.UserId = Convert.ToInt32(UserDetails.ParentId);
                    }
                    var vendorResponse = MakeRequest.getServiceObject(url, request, "reqUserId", "POST", typeof(ResCustomerList));
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
                else if (operType == "getCustDetail")
                {
                    //SNServiceClient client = new SNServiceClient();
                    //client.GetCustomerDetail
                    string url = generateReq.generateUrl("GetCustomerDetail");
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    ReqId reqCust = new ReqId();
                    reqCust = generateReq.Deserialize<ReqId>(strJson);

                    var insertResponse = MakeRequest.getServiceObject(url, reqCust, "reqCustomerId", "POST", typeof(ResCustomerDetail));

                    if (insertResponse != null)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(insertResponse));
                    }
                    else
                    {
                        ResCommon timeOut = new ResCommon();
                        timeOut.ResponseCode = -102;
                        timeOut.ResponseMessage = "No Response from server";
                        context.Response.Write(JsonConvert.SerializeObject(timeOut));
                    }
                }
                else if (operType == "update")
                {
                    string url = generateReq.generateUrl("UpdateCustomer");
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    ReqCustomerUpdate reqCust = new ReqCustomerUpdate();
                    reqCust = generateReq.Deserialize<ReqCustomerUpdate>(strJson);

                    var insertResponse = MakeRequest.getServiceObject(url, reqCust, "reqCustomerUpdate", "POST", typeof(ResCommon));

                    if (insertResponse != null)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(insertResponse));
                    }
                    else
                    {
                        ResCommon timeOut = new ResCommon();
                        timeOut.ResponseCode = -102;
                        timeOut.ResponseMessage = "No Response from server";
                        context.Response.Write(JsonConvert.SerializeObject(timeOut));
                    }
                }
                else if (operType == "insert")
                {
                    string url = generateReq.generateUrl("InsertCustomer");
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    ReqCustomer reqCust = new ReqCustomer();
                    reqCust = generateReq.Deserialize<ReqCustomer>(strJson);
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        reqCust.UserId = Convert.ToInt32(UserDetails.UserId);
                    }
                    else
                    {
                        reqCust.UserId = Convert.ToInt32(UserDetails.ParentId);
                    }
                    var insertResponse = MakeRequest.getServiceObject(url, reqCust, "reqCustomer", "POST", typeof(ResId));

                    if (insertResponse != null)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(insertResponse));
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