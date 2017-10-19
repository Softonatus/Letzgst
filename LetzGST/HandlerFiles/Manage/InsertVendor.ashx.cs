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
    /// Summary description for InsertVendor
    /// </summary>
    public class InsertVendor : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
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

                    string operType = Convert.ToString(context.Request.QueryString["opertype"]);
                    if (operType == "get")
                    {
                        string url = generateReq.generateUrl("GetVendorList");
                        ReqUserId request = new ReqUserId();
                        if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                        {
                            request.UserId = Convert.ToInt32(UserDetails.UserId);
                        }
                        else
                        {
                            request.UserId = Convert.ToInt32(UserDetails.ParentId);
                        }
                        var vendorResponse = MakeRequest.getServiceObject(url, request, "reqUserId", "POST", typeof(ResVendorList));
                        if(vendorResponse != null)
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
                    else if (operType == "getVendorDetail")
                    {
                        //SNServiceClient client = new SNServiceClient();
                        //client.GetCustomerDetail
                        string url = generateReq.generateUrl("GetVendorDetail");
                        string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                        ReqId reqCust = new ReqId();
                        reqCust = generateReq.Deserialize<ReqId>(strJson);

                        var insertResponse = MakeRequest.getServiceObject(url, reqCust, "reqVendorId", "POST", typeof(ResVendorDetail));

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
                        string url = generateReq.generateUrl("UpdateVendor");
                        string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                        ReqVendorUpdate reqCust = new ReqVendorUpdate();
                        reqCust = generateReq.Deserialize<ReqVendorUpdate>(strJson);
                        
                        var insertResponse = MakeRequest.getServiceObject(url, reqCust, "reqVendorUpdate", "POST", typeof(ResCommon));

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
                        ReqVendor requestINS = new ReqVendor();
                        string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                        requestINS = generateReq.Deserialize<ReqVendor>(strJson);

                        if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                        {
                            requestINS.UserId = Convert.ToInt32(UserDetails.UserId);
                        }
                        else
                        {
                            requestINS.UserId = Convert.ToInt32(UserDetails.ParentId);
                        }

                        string url = generateReq.generateUrl("InsertVendor");
                        var insertResponse = MakeRequest.getServiceObject(url, requestINS, "reqVendor", "POST", typeof(ResId));

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
                else
                {
                    ResCommon timeOut = new ResCommon();
                    timeOut.ResponseCode = -100;
                    timeOut.ResponseMessage = "Session Timed Out";
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