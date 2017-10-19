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
using System.Globalization;

namespace LetzGST.HandlerFiles.Manage
{
    /// <summary>
    /// Summary description for PODetails
    /// </summary>
    public class PODetails : IHttpHandler, IRequiresSessionState
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
                    string url = generateReq.generateUrl("GetPurchaseList");
                    ReqUserId request = new ReqUserId();
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        request.UserId = Convert.ToInt32(UserDetails.UserId);
                    }
                    else
                    {
                        request.UserId = Convert.ToInt32(UserDetails.ParentId);
                    }
                    var POResponse = MakeRequest.getServiceObject(url, request, "reqUserId", "POST", typeof(ReqPurchaseList));
                    if (POResponse != null)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(POResponse));
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
                    //SNServiceClient client = new SNServiceClient();
                    //client.UpdatePurchase
                    //ReqUpdatePurchase
                    ReqPurchase reqPurchase = new ReqPurchase();
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    reqPurchase = generateReq.Deserialize<ReqPurchase>(strJson);
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        reqPurchase.UserId = Convert.ToInt32(UserDetails.UserId);
                    }
                    else
                    {
                        reqPurchase.UserId = Convert.ToInt32(UserDetails.ParentId);
                    }

                    string DueDate = reqPurchase.DueDate;
                    string PoDate = reqPurchase.PoDate;
                    IFormatProvider culture = new CultureInfo("en-US", true);

                    DateTime dueDateVal = DateTime.ParseExact(DueDate, "dd/MM/yyyy", null);
                    DateTime poDateVal = DateTime.ParseExact(PoDate, "dd/MM/yyyy", null);

                    reqPurchase.DueDate = dueDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    reqPurchase.PoDate = poDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    string url = generateReq.generateUrl("InsertPurchase");
                    var insertResponse = MakeRequest.getServiceObject(url, reqPurchase, "reqPurchase", "POST", typeof(ResCommon));

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
                    ReqPurchase reqUpdatePurchase = new ReqPurchase();
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    reqUpdatePurchase = generateReq.Deserialize<ReqPurchase>(strJson);
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        reqUpdatePurchase.UserId = Convert.ToInt32(UserDetails.UserId);
                    }
                    else
                    {
                        reqUpdatePurchase.UserId = Convert.ToInt32(UserDetails.ParentId);
                    }

                    string DueDate = reqUpdatePurchase.DueDate;
                    string PoDate = reqUpdatePurchase.PoDate;
                    IFormatProvider culture = new CultureInfo("en-US", true);

                    DateTime dueDateVal = DateTime.ParseExact(DueDate, "dd/MM/yyyy", null);
                    DateTime poDateVal = DateTime.ParseExact(PoDate, "dd/MM/yyyy", null);

                    reqUpdatePurchase.DueDate = dueDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    reqUpdatePurchase.PoDate = poDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    string url = generateReq.generateUrl("UpdatePurchase");
                    var updateResponse = MakeRequest.getServiceObject(url, reqUpdatePurchase, "reqUpdatePurchase", "POST", typeof(ResCommon));

                    if (updateResponse != null)
                    {
                        context.Response.Write(JsonConvert.SerializeObject(updateResponse));
                    }
                    else
                    {
                        ResCommon timeOut = new ResCommon();
                        timeOut.ResponseCode = -102;
                        timeOut.ResponseMessage = "No Response from server";
                        context.Response.Write(JsonConvert.SerializeObject(timeOut));
                    }

                }
                else if(operType == "delete")
                {
                    ReqId reqId = new ReqId();
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    reqId = generateReq.Deserialize<ReqId>(strJson);


                    string url = generateReq.generateUrl("DeletePurchase");
                    var insertResponse = MakeRequest.getServiceObject(url, reqId, "reqId", "POST", typeof(ResCommon));

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
                else if (operType == "getPODetails")
                {
                    ReqId reqPODetails = new ReqId();
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    reqPODetails = generateReq.Deserialize<ReqId>(strJson);
                    

                    string url = generateReq.generateUrl("GetPurchaseDetail");
                    var insertResponse = MakeRequest.getServiceObject(url, reqPODetails, "reqId", "POST", typeof(ResPurchase_PurchaseItem));

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