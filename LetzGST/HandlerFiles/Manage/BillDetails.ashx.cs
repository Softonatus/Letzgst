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
    /// Summary description for BillDetails
    /// </summary>
    public class BillDetails : IHttpHandler, IRequiresSessionState
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
                    string url = generateReq.generateUrl("GetUserBillList");
                    ReqUserId request = new ReqUserId();
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        request.UserId = Convert.ToInt32(UserDetails.UserId);
                    }
                    else
                    {
                        request.UserId = Convert.ToInt32(UserDetails.ParentId);
                    }
                    var POResponse = MakeRequest.getServiceObject(url, request, "reqUserId", "POST", typeof(ResBillList));
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
                    ReqBill reqBill = new ReqBill();
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    reqBill = generateReq.Deserialize<ReqBill>(strJson);
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        reqBill.UserId = Convert.ToInt32(UserDetails.UserId);
                    }
                    else
                    {
                        reqBill.UserId = Convert.ToInt32(UserDetails.ParentId);
                    }

                    string DueDate = reqBill.DueDate;
                    string PoDate = reqBill.BillDate;
                    string EndDate = reqBill.EndDate;
                    IFormatProvider culture = new CultureInfo("en-US", true);

                    DateTime dueDateVal = DateTime.ParseExact(DueDate, "dd/MM/yyyy", null);
                    DateTime poDateVal = DateTime.ParseExact(PoDate, "dd/MM/yyyy", null);
                    if(reqBill.EndDate != null)
                    {
                        DateTime endDateVal = DateTime.ParseExact(EndDate, "dd/MM/yyyy", null);
                        reqBill.EndDate = endDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    }

                    reqBill.DueDate = dueDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    reqBill.BillDate = poDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    string url = generateReq.generateUrl("InsertBill");
                    var insertResponse = MakeRequest.getServiceObject(url, reqBill, "reqBill", "POST", typeof(ResCommon));

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
                    //SNServiceClient client = new SNServiceClient();
                    //client.UpdateBill
                    ReqBill reqUpdatePurchase = new ReqBill();
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    reqUpdatePurchase = generateReq.Deserialize<ReqBill>(strJson);
                    if (Convert.ToString(context.Request.QueryString["usertype"]) != null)
                    {
                        reqUpdatePurchase.UserId = Convert.ToInt32(UserDetails.UserId);
                    }
                    else
                    {
                        reqUpdatePurchase.UserId = Convert.ToInt32(UserDetails.ParentId);
                    }

                    string DueDate = reqUpdatePurchase.DueDate;
                    string PoDate = reqUpdatePurchase.BillDate;
                    string EndDate = reqUpdatePurchase.EndDate;
                    IFormatProvider culture = new CultureInfo("en-US", true);

                    DateTime dueDateVal = DateTime.ParseExact(DueDate, "dd/MM/yyyy", null);
                    DateTime poDateVal = DateTime.ParseExact(PoDate, "dd/MM/yyyy", null);

                    if (reqUpdatePurchase.EndDate != null)
                    {
                        DateTime endDateVal = DateTime.ParseExact(EndDate, "dd/MM/yyyy", null);
                        reqUpdatePurchase.EndDate = endDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    }

                    reqUpdatePurchase.DueDate = dueDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");
                    reqUpdatePurchase.BillDate = poDateVal.ToString("yyyy-MM-dd HH':'mm':'ss");

                    string url = generateReq.generateUrl("UpdateBill");
                    var updateResponse = MakeRequest.getServiceObject(url, reqUpdatePurchase, "reqBill", "POST", typeof(ResCommon));

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
                else if (operType == "delete")
                {
                    ReqId reqId = new ReqId();
                    string strJson = new StreamReader(context.Request.InputStream).ReadToEnd();
                    reqId = generateReq.Deserialize<ReqId>(strJson);


                    string url = generateReq.generateUrl("DeleteBill");
                    var insertResponse = MakeRequest.getServiceObject(url, reqId, "reqBillId", "POST", typeof(ResCommon));

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
                    string url = "";;
                    if (Convert.ToString(context.Request.QueryString["act"]) != null)
                    {
                        url = generateReq.generateUrl("GetBillDetail");
                        var insertResponse = MakeRequest.getServiceObject(url, reqPODetails, "reqId", "POST", typeof(ReqBill));
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
                    else
                    {
                        url = generateReq.generateUrl("GetPurchaseDetail");
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